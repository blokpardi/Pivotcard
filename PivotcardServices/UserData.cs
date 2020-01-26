using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.Web.Caching;
using System.Text;

namespace PivotcardServices
{
    public class UserData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }
        
        //public static IEnumerable<UserData> Pivots()
        //{
        //    if (HttpRuntime.Cache["carSeatDoc"] == null)
        //    {
        //        XmlDocument tmpDoc = new XmlDocument();
        //        tmpDoc.Load("http://localhost:53498/DataFiles/CarSeatRatings.xml");
        //        HttpRuntime.Cache.Insert("carSeatDoc", tmpDoc.OuterXml, null, DateTime.Now.AddMonths(6), TimeSpan.Zero);
        //    }

        //    XmlDocument carSeatDoc = new XmlDocument();
        //    carSeatDoc.LoadXml(HttpRuntime.Cache["carSeatDoc"].ToString());

        //    XmlNodeList csNames = carSeatDoc.SelectNodes("//return/manufacturerandModelName");
        //    foreach (XmlNode xn in csNames)
        //    {
        //        yield return new CarSeatData { Name = xn.InnerText.ToString() };
        //    }
        //}

        public static string checkUser(string idenfier)
        {
            if (HttpRuntime.Cache["usersDoc"] == null)
            {
                XDocument tmpDoc = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                HttpRuntime.Cache.Insert("usersDoc", tmpDoc.ToString(), null, DateTime.Now.AddHours(1), TimeSpan.Zero);
            }

            XDocument usersDoc = XDocument.Parse(HttpRuntime.Cache["usersDoc"].ToString());
            bool nodeExists = usersDoc.Descendants("UserName")
                .Where(x => x.Value == idenfier).Any();

            return nodeExists.ToString();
        }


        public static string loginUser(string UserName, string Password, string FirstName)
        {
            XDocument usersDoc = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            bool nodeExists = usersDoc.Descendants("UserName")
                .Where(x => x.Value == UserName).Any();

            if (nodeExists)
                return "success";
            else
            {
                usersDoc.Root.Add(new XElement("User",
                    new XElement("UserName", UserName),
                    new XElement("Password", Password),
                    new XElement("FirstName", FirstName)));
                usersDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
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
    }
}