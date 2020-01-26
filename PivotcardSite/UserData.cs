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

namespace PivotcardSite
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
            
            XDocument usersDoc = UserFile.getUserFile();// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            bool nodeExists = usersDoc.Descendants("UserName")
                .Where(x => x.Value == identifier).Any();

            return nodeExists;
        }

        public static bool checkPivot(string pname)
        {
            
            XDocument usersDoc = UserFile.getUserFile();// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            bool nodeExists = usersDoc.Descendants("PivotName")
                .Where(x => x.Value.ToLowerInvariant() == pname.ToLowerInvariant()).Any();

            return nodeExists;
        }

        public static string getPivotName(string uname)
        {
            XDocument usersDoc = UserFile.getUserFile();// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            XElement userNode =
                   usersDoc.Element("Users")
                        .Elements("User")
                        .Descendants("UserName")
                        .Where(x => x.Value == uname).First();

            XElement pivotNode = userNode.Parent.Descendants("PivotName").First();
            string pname = pivotNode.Value;
            return pname;
        }

        public static string loginUser(string UserName, string Password, string PivotName, string FirstName)
        {
            XDocument usersDoc = UserFile.getUserFile();// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            bool nodeExists = usersDoc.Descendants("UserName")
                .Where(x => x.Value == UserName).Any();

            if (nodeExists)
                return "success";
            else
            {
                usersDoc.Root.Add(new XElement("User",
                    new XElement("UserName", UserName),
                    new XElement("Password", Password),
                    new XElement("PivotName", PivotName),
                    new XElement("FirstName", FirstName)));
                UserFile.setUserFile(usersDoc); //usersDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                return usersDoc.ToString();
            }
        }

        public static string janrainLogin(string token)
        {
            var rpx = new Rpx("38b726baa689dd1afdcb82e91f905101e660d73a", "https://rpxnow.com");
            var authInfo = rpx.AuthInfo(token);
            var doc = XDocument.Load(new XmlNodeReader(authInfo));
            return (doc.Root.Descendants("identifier").First().Value);
        }

        public static bool addUserToDB(string UserName, string PivotName, string jrType)
        {
            try
            {
                Membership.CreateUser(UserName, jrType);
                XDocument tmpDoc = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                HttpRuntime.Cache.Insert("userDoc", tmpDoc, null, DateTime.Now.AddHours(1), TimeSpan.Zero);

                XDocument usersDoc = UserFile.getUserFile();// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                XElement userNode =
                   usersDoc.Element("Users")
                        .Elements("User")
                        .Descendants("UserName")
                        .Where(x => x.Value == UserName).First();
                userNode.Parent.Add(new XElement("PivotName", PivotName));
                //userNode.Parent.Add(new XElement("Pivots"));
                UserFile.checkPivotFile(PivotName);
                UserFile.setUserFile(usersDoc); //usersDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                return true;
            }
            catch
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
            val = val.Replace("!pcqm!", "?");
            val = val.Replace("!pce!", "=");
            return val;
        }
    }
}