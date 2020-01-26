using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
    
namespace PivotcardSite
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{page}.aspx");
            routes.Ignore("{page}.asax");
            routes.Ignore("{page}.cs");
            routes.Ignore("{page}.axd");
            routes.Ignore("scripts/{script}.js");
            routes.Ignore("stylesheets/{style}.css");
            routes.Ignore("images/{image}.*");
            routes.MapPageRoute("pivots", "{pivotname}/{pivotcode}", "~/pivot/PageRedir.aspx");
            routes.MapPageRoute("pivotdefault", "{pivotname}", "~/pivot/PageRedir.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception exc = Server.GetLastError();

            //// Handle HTTP errors
            
            //string baseURL = Request.Url.GetLeftPart(UriPartial.Authority);
            //string extURL = Request.Url.ToString().Substring(baseURL.Length + 1);
            //string lastChar = extURL.Substring(extURL.Length - 1, 1);
            //if (lastChar == "/")
            //    extURL = extURL.Substring(0, extURL.Length - 1);
            //string[] urlSpl = extURL.Split('/');

            //if (urlSpl.Length > 0 && urlSpl.Length < 3)
            //{
            //    string pCode = "", pName = urlSpl[0]; bool defaultVal;
            //    defaultVal = true;
            //    if(urlSpl.Length > 1)
            //    {
            //        pCode = urlSpl[1];
            //        defaultVal = false;
            //    }
            //    try
            //    {
            //        if (UserData.checkPivot(pName))
            //        {
            //            PivotData p = PivotData.getPivotRedir(pName, pCode, defaultVal);
            //            if (p.PivotType == "pl")
            //                Response.Redirect(p.PivotContent);
            //            Server.ClearError();
            //        }
            //        else 
            //            throw new ApplicationException("Pivot name not found.");
            //    }
            //    catch
            //    {
            //        Response.Redirect("~/home.aspx");
            //    }
            //}

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}