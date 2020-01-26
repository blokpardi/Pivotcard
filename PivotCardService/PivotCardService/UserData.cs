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
        /// <summary>
        /// Checks the user based on username.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns>bool</returns>
        public static bool checkUser(string userName)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();
            int userExists = (int)db.GetCheckUser(userName).ReturnValue;
            return Convert.ToBoolean(userExists); 
        }

        /// <summary>
        /// Checks the user based on username and password.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>bool</returns>
        public static bool checkUser(string userName, string password)
        {
            bool retVal = false; 
            try
            {
                retVal = Membership.Providers["SqlProvider"].ValidateUser(userName, password);
            }
            catch
            {
                retVal = false;  
            }
            return retVal; 
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
                MembershipCreateStatus foo = new MembershipCreateStatus();
                Membership.Providers["SqlProvider"].CreateUser(UserName, Password, null, null, null, true, null, out foo);
                PivotCard1DataContext db = new PivotCard1DataContext();
                int userLogin = (int)db.SetUpdateUser(PivotName, UserName, FirstName);
                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates user password and/or PivotName. Username is required. Other fields can contain null.  
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassWord"></param>
        /// <param name="pivotName"></param>
        /// <returns></returns>
        public static bool updateUserInfo(string UserName, string oldPassword, string newPassWord, string pivotName)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();

            MembershipUser u;
            u = Membership.GetUser(UserName);
            if (u != null && (oldPassword != null && newPassWord != null))
            {
                try
                {
                    u.ChangePassword(oldPassword, newPassWord);
                }
                catch
                {
                    return false;
                }
            }

            if (pivotName != null)
            {
                try
                {
                    int retVal = db.SetUpdatePivot(pivotName, UserName);
                    if (retVal == 0)
                        return false; 
                }
                catch
                {
                    return false; 
                }
            }

            return true;
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

        public static bool deleteUser(string UserName)
        {
            try
            {
                Membership.Providers["SqlProvider"].DeleteUser(UserName, true);

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}