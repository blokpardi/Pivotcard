﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Net;

namespace PivotcardSite
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataService
    {
        [OperationContract]
        [WebGet(UriTemplate = "checkUser/{UserName}", ResponseFormat = WebMessageFormat.Xml)]
        public bool checkUser(string UserName)
        {
            return UserData.checkUser(UserName);
        }

        [WebInvoke(Method="POST", UriTemplate = "checkPivot/{PivotName}", ResponseFormat = WebMessageFormat.Json)]
        public bool checkPivot(string PivotName)
        {
            return UserData.checkPivot(PivotName);
        }

        [WebInvoke(Method = "POST", UriTemplate = "getPivotName/{uName}", ResponseFormat = WebMessageFormat.Json)]
        public string getPivotName(string uName)
        {
            uName = UserData.PCDecode(uName);
            return UserData.getPivotName(uName);
        }

        [WebInvoke(Method = "POST", UriTemplate = "getPivotData/{pName}", ResponseFormat = WebMessageFormat.Json)]
        public List<PivotData> getPivotData(string pName)
        {
            return PivotData.getPivots(pName).ToList();
        }

        [WebInvoke(Method = "POST", UriTemplate = "getSinglePivot/{pName}/{pId}", ResponseFormat = WebMessageFormat.Json)]
        public List<PivotData> getSinglePivot(string pName, string pId)
        {
            return PivotData.getPivot(pName, pId).ToList();
        }

        [WebInvoke(Method = "POST", UriTemplate = "deleteSinglePivot/{pName}/{pId}", ResponseFormat = WebMessageFormat.Json)]
        public bool deleteSinglePivot(string pName, string pId)
        {
            return PivotData.deletePivot(pName, pId);
        }

        [WebInvoke(Method="POST", UriTemplate = "loginUser/{UserName}/{Password}/{PivotName}/{FirstName}", ResponseFormat = WebMessageFormat.Json)]
        public string loginUser(string UserName, string Password, string PivotName, string FirstName)
        {
            return UserData.loginUser(UserName, Password, PivotName, FirstName);
        }

        //[WebGet(UriTemplate = "janrainLogin/{token}", ResponseFormat = WebMessageFormat.Json)]
        //public string janrainLogin(string token)
        //{
        //    return UserData.janrainLogin(token);
        //}

        [WebInvoke(Method = "POST", UriTemplate = "addUserToDB/{uName}/{pName}/{jrType}", ResponseFormat = WebMessageFormat.Json)]
        public bool addUserToDB(string uName, string pName, string jrType)
        {
            uName = UserData.PCDecode(uName);
            return UserData.addUserToDB(uName, pName, jrType);
        }

        [WebInvoke(Method="POST", UriTemplate = "janrainLogin/{token}", ResponseFormat = WebMessageFormat.Json)]
        public List<LoginResult> janrainLogin(string token)
        {
            var rpx = new Rpx("38b726baa689dd1afdcb82e91f905101e660d73a", "https://rpxnow.com");
            var authInfo = rpx.AuthInfo(token);
            var doc = XDocument.Load(new XmlNodeReader(authInfo));
            string jrIdentifier = doc.Root.Descendants("identifier").First().Value;
            string jrType = doc.Root.Descendants("providerName").First().Value;
            string strStatus = "ok";
            if (!UserData.checkUser(jrIdentifier))
            {
                strStatus = "new";
            }
            return new List<LoginResult>() { new LoginResult() { Status = strStatus, Identifier = jrIdentifier, Type = jrType } };
        }

        [WebInvoke(Method = "POST", UriTemplate = "savePivot/{pName}/{pCode}/{pId}/{pContent}/{pType}/{pDefault}", ResponseFormat = WebMessageFormat.Json)]
        public bool savePivot(string pName,string pCode,string pId,string pContent,string pType,string pDefault)
        {
            PivotData p = new PivotData();
            p.PivotCode = pCode;
            p.PivotId = pId;
            p.PivotContent = UserData.PCDecode(pContent);
            p.PivotType = pType;
            p.PivotDefault = pDefault;
            return PivotData.savePivot(pName,p);
        }

        [WebInvoke(Method = "POST", UriTemplate = "savePagePivot/{pName}/{pCode}/{pId}/{pType}/{pDefault}?content={pContent}", ResponseFormat = WebMessageFormat.Json)]
        public bool savePagePivot(string pName, string pCode, string pId, string pContent, string pType, string pDefault)
        {
            PivotData p = new PivotData();
            p.PivotCode = pCode;
            p.PivotId = pId;
            if (pType == "pl")
                p.PivotContent = UserData.PCDecode(pContent);
            else
                p.PivotContent = pContent;
            p.PivotType = pType;
            p.PivotDefault = pDefault;
            return PivotData.savePivot(pName, p);
        }

    }
}