using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.Web.Caching;
using System.Text;
using System.Xml.Serialization;
using System.IO; 

namespace PivotCardService
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
            //XDocument pivotDoc = UserFile.getPivotFile(pname);
            PivotCard1DataContext db = new PivotCard1DataContext();
            IEnumerable<Pivot> pivData = db.GetPivots(pname);

            foreach (Pivot piv in pivData)
            {
                yield return new PivotData
                {
                    PivotCode = piv.PivotCode,
                    PivotId = piv.ID.ToString(),
                    PivotContent = piv.PivotContent,
                    PivotType = piv.Type.ToString(),
                    PivotDefault = piv.IsDefault.ToString()
                }; 
            }
           
        }

        public static IEnumerable<PivotData> getPivot(string pname, string pid)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();
            IEnumerable<Pivot> pivData = db.GetPivot(pname, Convert.ToInt32(pid));
            List<Pivot> returnval = pivData.ToList();

            if (returnval.Count < 1)
            {
               yield break;
            }

                yield return new PivotData
                {
                    PivotCode = returnval[0].PivotCode,
                    PivotId = returnval[0].ID.ToString(),
                    PivotContent = returnval[0].PivotContent,
                    PivotType = returnval[0].Type.ToString(),
                    PivotDefault = returnval[0].IsDefault.ToString()
                };
          
        }

        public static bool deletePivot(string pname, string pid)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();
            IEnumerable<Pivot> pivData = db.SetDeletePivot(pname, Convert.ToInt32(pid));

            List<Pivot> returnval = pivData.ToList(); 
            if (returnval.Count > 0)
                return true;
            return false; 
        }

        public static PivotData getPivotRedir(string pname, string pcode, bool bdefault)
        {
            PivotCard1DataContext db = new PivotCard1DataContext();
            IEnumerable<Pivot> pivData = db.GetPivotRedir(pname,pcode,bdefault);
            List<Pivot> returnval = pivData.ToList();

            return new PivotData
            {
                PivotCode = returnval[0].PivotCode,
                PivotId = returnval[0].ID.ToString(),
                PivotContent = returnval[0].PivotContent,
                PivotType = returnval[0].Type.ToString(),
                PivotDefault = returnval[0].IsDefault.ToString()
            };
        }

        public static bool savePivot(string pName, PivotData p)
        {
            int pivData = 0;
            PivotCard1DataContext db = new PivotCard1DataContext();
            try
            {
                pivData = (int)db.SetSavePivot(pName, p.PivotCode, Convert.ToInt32(p.PivotId), p.PivotContent, p.PivotType, Convert.ToBoolean(p.PivotDefault)).ReturnValue;
            }
            catch { return false; }
            return Convert.ToBoolean(pivData);  
        }

        private static int genID()
        {
            Random rand = new Random();
            return(rand.Next(1000, 9999));
        }
    }
}