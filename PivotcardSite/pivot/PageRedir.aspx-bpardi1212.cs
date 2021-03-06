﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PivotcardSite.pivot
{
    public partial class PageRedir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string pCode="", pName=""; bool defaultVal;
            defaultVal = false;
            pName=Page.RouteData.Values["pivotname"] as string;
            pCode=Page.RouteData.Values["pivotcode"] as string;

            if (pCode == null)
                defaultVal=true;
            string redirPth = "~/home.aspx";
                try
                {
                    if (UserData.checkPivot(pName))
                    {
                        PivotData p = PivotData.getPivotRedir(pName, pCode, defaultVal);
                        if (p.PivotType == "pl")
                            redirPth = p.PivotContent;
                        //Server.ClearError();
                    }
                    else
                       redirPth = "~/error.aspx";
                }
                catch (Exception exp)
                { redirPth = "~/error.aspx"; }
            //}
            Response.Redirect(redirPth);
        }
    }
}