using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.Web.Caching;
using System.IO;

namespace PivotcardSite
{
    public class UserFile
    {
        private static object LockHandle = new object(); 

        public static XDocument getUserFile()
        {
            if (HttpRuntime.Cache["userDoc"] == null)
            {
                XDocument tmpDoc = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                HttpRuntime.Cache.Insert("userDoc", tmpDoc, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
            }

            XDocument userDoc = (XDocument)HttpRuntime.Cache["userDoc"];

            //XDocument userDoc = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            return userDoc;
        }

        public static bool setUserFile(XDocument xmlData)
        {
            HttpRuntime.Cache.Insert("userDoc", xmlData, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
            lock (LockHandle)
            {
                try{

                    XDocument userDoc = (XDocument)HttpRuntime.Cache["userDoc"];
                    userDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                    return true;
                }
                catch {
                    return false;
                }
            } 
        }

        public static XDocument getPivotFile(string pName)
        {
            string pth = "~/App_Data/" + pName + ".xml"; 
            XDocument pivDoc = XDocument.Load(HostingEnvironment.MapPath(pth));
            return pivDoc;
        }

        public static bool setPivotFile(XDocument xmlData, string pname)
        {
            lock (LockHandle)
            {
                try
                {
                    string pth = "~/App_Data/" + pname + ".xml";
                    XDocument pivotDoc = xmlData;
                    pivotDoc.Save(HostingEnvironment.MapPath(pth));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static void checkPivotFile(string pName)
        {
            string pth = "~/App_Data/" + pName + ".xml";
            if (!File.Exists(HostingEnvironment.MapPath(pth)))
            {
                XDocument pivotsDoc = new XDocument();
                pivotsDoc.Add(new XElement("Pivots"));
                pivotsDoc.Save(HostingEnvironment.MapPath(pth));
            }
        }
    }

}