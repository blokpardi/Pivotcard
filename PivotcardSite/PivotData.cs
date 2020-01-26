using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.Web.Caching;
using System.Text;

namespace PivotcardSite
{

    public class PivotData
    {

        public string PivotCode { get; set; }
        public string PivotId { get; set; }
        public string PivotContent { get; set; }
        public string PivotType { get; set; }
        public string PivotDefault { get; set; }

        public static IEnumerable<PivotData> getPivots(string pname)
        {
            XDocument pivotDoc = UserFile.getPivotFile(pname);

            XElement pivotNode = pivotDoc.Root;

            foreach (XElement xn in pivotNode.Descendants("Pivot"))
            {
                yield return new PivotData { PivotCode = xn.Descendants("PivotCode").First().Value, 
                    PivotId = xn.Descendants("PivotId").First().Value, 
                    PivotContent = xn.Descendants("PivotContent").First().Value,
                    PivotType = xn.Descendants("PivotType").First().Value,
                    PivotDefault = xn.Descendants("PivotDefault").First().Value
                };
            }
        }

        public static IEnumerable<PivotData> getPivot(string pname, string pid)
        {
            XDocument pivotDoc = UserFile.getPivotFile(pname);// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));

            XElement pivotNode = pivotDoc.Root
                        .Elements("Pivot")
                        .Where(x => x.Descendants("PivotId").First().Value == pid).First();

            yield return new PivotData
                {
                    PivotCode = pivotNode.Descendants("PivotCode").First().Value,
                    PivotId = pivotNode.Descendants("PivotId").First().Value,
                    PivotContent = pivotNode.Descendants("PivotContent").First().Value,
                    PivotType = pivotNode.Descendants("PivotType").First().Value,
                    PivotDefault = pivotNode.Descendants("PivotDefault").First().Value
                };
        }

        public static bool deletePivot(string pname, string pid)
        {
            XDocument pivotDoc = UserFile.getPivotFile(pname);// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));

            XElement pivotNode = pivotDoc.Root
                        .Elements("Pivot")
                        .Where(x => x.Descendants("PivotId").First().Value == pid).First();

            pivotNode.Remove();
            UserFile.setPivotFile(pivotDoc, pname); //usersDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
            return true;
        }

        public static PivotData getPivotRedir(string pname, string pcode, bool bdefault)
        {
            XDocument pivotDoc = UserFile.getPivotFile(pname);// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));

            XElement pivotNode;
            if (!bdefault)
            {
                pivotNode = pivotDoc.Root
                            .Elements("Pivot")
                            .Where(x => x.Descendants("PivotCode").First().Value.ToLowerInvariant() == pcode.ToLowerInvariant()).First();
            }
            else
            {

                XElement firstPivot = pivotNode = pivotDoc.Element("Pivots")
                        .Elements("Pivot").First();

                pivotNode = pivotDoc.Root
                        .Elements("Pivot")
                        .Where(x => x.Descendants("PivotDefault").First().Value.ToLowerInvariant() == "true").DefaultIfEmpty(firstPivot).First();
 
            }

            return new PivotData
            {
                PivotCode = pivotNode.Descendants("PivotCode").First().Value,
                PivotId = pivotNode.Descendants("PivotId").First().Value,
                PivotContent = pivotNode.Descendants("PivotContent").First().Value,
                PivotType = pivotNode.Descendants("PivotType").First().Value,
                PivotDefault = pivotNode.Descendants("PivotDefault").First().Value
            };
        }

        public static bool savePivot(string pName, PivotData p)
        {
            XDocument pivotDoc = UserFile.getPivotFile(pName);// XDocument.Load(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));

            bool nodeExists = p.PivotId != "null";
            XCData pivotContent = new XCData(p.PivotContent);


            if (nodeExists)
            {
                XElement pivotNode = pivotDoc.Root
                        .Elements("Pivot")
                        .Where(x => x.Descendants("PivotId").First().Value == p.PivotId).First();
                pivotNode.Descendants("PivotContent").First().ReplaceNodes(pivotContent);
                pivotNode.Descendants("PivotType").First().Value = p.PivotType;
                pivotNode.Descendants("PivotCode").First().Value = p.PivotCode;

                if (Convert.ToBoolean(p.PivotDefault))
                {
                    IEnumerable<XElement> allPivots = pivotDoc.Descendants("Pivots");

                    foreach (XElement xn in allPivots.Descendants("Pivot"))
                    {
                        xn.Descendants("PivotDefault").First().Value = "false";
                    }
                }

                pivotNode.Descendants("PivotDefault").First().Value = p.PivotDefault;
                UserFile.setPivotFile(pivotDoc, pName); //usersDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                return true;
            }
            else
            {
                int nId = genID();
                XElement pivotNode = pivotDoc.Root;
                pivotNode.Add(new XElement("Pivot",
                    new XElement("PivotCode", p.PivotCode),
                    new XElement("PivotId", nId.ToString()),
                    new XElement("PivotContent", pivotContent),
                    new XElement("PivotType", p.PivotType),
                    new XElement("PivotDefault", p.PivotDefault)));
                UserFile.setPivotFile(pivotDoc, pName); //usersDoc.Save(HostingEnvironment.MapPath("~/App_Data/tblUsers.xml"));
                return false;
            }
        }

        private static int genID()
        {
            Random rand = new Random();
            return(rand.Next(1000, 9999));
        }
    }
}