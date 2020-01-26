using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Hosting;
using System.Web.Caching;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace PivotcardSite
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataService
    {

        [OperationContract]
        [WebGet(UriTemplate = "checkUser/{UserName}", ResponseFormat = WebMessageFormat.Json)]
        public bool checkUser(string UserName)
        {
            UserName = PCDecode(UserName);
            return (PivotCardService.UserData.checkUser(UserName)!=true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "checkPivot/{PivotName}?un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public bool checkPivot(string PivotName, string un, string token)
        {
            return (PivotCardService.UserData.checkPivot(PivotName)!=true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "getPivotName/{uName}?un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public string getPivotName(string uName, string un, string token)
        {
            uName = PCDecode(uName);
            string retVal = "error";
            if(isValidUser(uName, token))
                retVal = PivotCardService.UserData.getPivotName(uName);
            return retVal;
        }

        [OperationContract]
        [WebGet(UriTemplate = "getPivotData/{pName}?un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public List<PivotCardService.PivotData> getPivotData(string pName, string un, string token)
        {

            if (isValidUser(un, token))
                return PivotCardService.PivotData.getPivots(pName).ToList();
            else
                return null;
        }

        [OperationContract]
        [WebGet(UriTemplate = "getSinglePivot/{pName}/{pId}?un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public List<PivotCardService.PivotData> getSinglePivot(string pName, string pId, string un, string token)
        {
            if (isValidUser(un, token)) 
                return PivotCardService.PivotData.getPivot(pName, pId).ToList();
            else
                return null;
        }

        [OperationContract]
        [WebGet(UriTemplate = "deleteSinglePivot/{pName}/{pId}?un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public bool deleteSinglePivot(string pName, string pId, string un, string token)
        {
            if (isValidUser(un, token)) 
                return PivotCardService.PivotData.deletePivot(pName, pId);
            else
                return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "addUserToDB/{uName}/{pName}/{pw}", ResponseFormat = WebMessageFormat.Json)]
        public List<LoginResult> addUserToDB(string uName, string pName, string pw)
        {
            uName = PCDecode(uName);
            pw = Base64Decode(pw);
            string sToken = null, strStatus = null;
            if (!PivotCardService.UserData.checkUser(uName))
            {
                bool auSuccess = PivotCardService.UserData.addUserToDB(uName, null, pName, pw);
                if (auSuccess)
                {
                    sToken = System.Guid.NewGuid().ToString();
                    HttpRuntime.Cache.Insert(uName, sToken, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                    strStatus = "ok";
                }
            }
            return new List<LoginResult>() { new LoginResult() { status = strStatus, username = uName, token = sToken } };
        }

        [OperationContract]
        [WebGet(UriTemplate = "pcLogin/{un}/{pw}", ResponseFormat = WebMessageFormat.Json)]
        public List<LoginResult> pcLogin(string un, string pw)
        {
            un = PCDecode(un);
            pw = Base64Decode(pw);
            string sToken = System.Guid.NewGuid().ToString();
            string strStatus = "unknown";
            if (PivotCardService.UserData.checkUser(un))
            {
                HttpRuntime.Cache.Insert(un, sToken, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                strStatus = "ok";
            }
            return new List<LoginResult>() { new LoginResult() { status = strStatus, username = un, token = sToken } };
        }

        [OperationContract]
        [WebGet(UriTemplate = "checkToken/{uName}/{token}", ResponseFormat = WebMessageFormat.Json)]
        public bool checkToken(string uName, string token)
        {
            uName = PCDecode(uName);
            string cVal = "";
            try
            {
                cVal = HttpRuntime.Cache[uName].ToString();
            }
            catch{}
            if(cVal != token)
                HttpRuntime.Cache.Add(uName, token, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            return true;
        }

        [OperationContract]
        [WebGet(UriTemplate = "savePivot/{pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}?un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public bool savePivot(string pName, string pCode, string pId, string pContent, string pType, string pDefault, string un, string token)
        {
            if (isValidUser(un, token))
            {
                PivotCardService.PivotData p = new PivotCardService.PivotData();
                p.PivotCode = pCode;
                if (pId == "null")
                    pId = genID().ToString();
                p.PivotId = pId;
                p.PivotContent = PCDecode(pContent);
                p.PivotType = pType;
                p.PivotDefault = pDefault;
                return PivotCardService.PivotData.savePivot(pName, p);
            }
            else
                return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "savePagePivot/{pName}/{pCode}/{pId}/{pType}/{pDefault}?content={pContent}&un={un}&tk={token}", ResponseFormat = WebMessageFormat.Json)]
        public bool savePagePivot(string pName, string pCode, string pId, string pContent, string pType, string pDefault, string un, string token)
        {
            if (isValidUser(un, token))
            {
                PivotCardService.PivotData p = new PivotCardService.PivotData();
                p.PivotCode = pCode;
                if (pId == "null")
                    pId = genID().ToString();
                p.PivotId = pId;
                if (pType == "pl")
                    p.PivotContent = PCDecode(pContent);
                else
                    p.PivotContent = pContent;
                p.PivotType = pType;
                p.PivotDefault = pDefault;
                return PivotCardService.PivotData.savePivot(pName, p);
            }
            else
                return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "decryptVal/{eStr}", ResponseFormat = WebMessageFormat.Json)]
        public string decryptVal(string eStr)
        {
            return Base64Decode(eStr);
        }

        private bool isValidUser(string un, string token)
        {
            un = PCDecode(un);
            string tkVal = HttpRuntime.Cache[un].ToString();
            bool retval = (tkVal == token);
            return retval;
        }

        private static int genID()
        {
            Random rand = new Random();
            return (rand.Next(1000, 9999));
        }

        public static string PCDecode(string val)
        {
            val = val.Replace("!pcfs!", "/");
            val = val.Replace("!pcd!", ".");
            val = val.Replace("!pcc!", ":");
            val = val.Replace("!pca!", "@");
            val = val.Replace("!pcp!", "#");
            val = val.Replace("!pcbs!", "\\");
            val = val.Replace("!pcqm!", "?");
            val = val.Replace("!pce!", "=");
            return val;
        }

        public static string Base64Decode(string val)
        {
            byte[] b = Convert.FromBase64String(val);
            string retVal = System.Text.Encoding.UTF8.GetString(b);
            return retVal;
        }

    }
}