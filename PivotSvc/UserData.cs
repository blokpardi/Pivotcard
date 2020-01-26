using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Xml;
using System.Xml.Linq;
using System.Web.Caching;
using System.Text;

namespace PivotCardService
{

    public class UserData
    {
        public string UserName { get; set; }
        public string PivotName { get; set; }
        public string Password { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }

        public static bool checkUser(string identifier)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();
            int userExists = (int)db.GetCheckUser(identifier).ReturnValue;
            return Convert.ToBoolean(userExists); 
        }

        public static bool checkPivot(string pname)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();
            int userExists = (int)db.GetCheckPivot(pname).ReturnValue;
            return Convert.ToBoolean(userExists);
        }

        public static string getPivotName(string uname)
        {
            string pname = null; 
            PivotCard1DataContext db = new PivotCard1DataContext();
            List<GetPivotNameResult> pivotName = db.GetPivotName(uname).ToList();
            if (pivotName.Count > 0)
            {
                pname = pivotName[0].PivotName.ToString();
            }
           
            return pname;
        }

        //public static bool loginUser(string UserName, string Password, string PivotName, string FirstName)
        //{
        //    PivotCard1DataContext db = new PivotCard1DataContext();
        //    int userLogin = (int)db.SetLoginUser(UserName,Password,PivotName,FirstName).ReturnValue;
        //    return Convert.ToBoolean(userLogin);
        //}

        public static bool addUserToDB(string UserName, string FirstName, string PivotName, string Password)
        {
            try
            {
                Membership.CreateUser(UserName, Password);
                PivotCard1DataContext db = new PivotCard1DataContext();
                int userLogin = (int)db.SetUpdateUser(PivotName, UserName, FirstName);
                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string PCDecode(string val)
        {
            val = val.Replace("!pcfs!","/");
            val = val.Replace("!pcd!",".");
            val = val.Replace("!pcc!",":");
            val = val.Replace("!pca!","@");
            val = val.Replace("!pcp!","#");
            val = val.Replace("!pcbs!","\\");
            return val;
        }
    }
}