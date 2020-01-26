using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Routing;
    
namespace PivotcardSite
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{page}.svc");
            routes.Ignore("{page}.axd");
            routes.Ignore("{page}.asax");
            routes.Ignore("{page}.cs");
            routes.Ignore("{page}.aspx");
            routes.Ignore("{page}.html");
            routes.Ignore("pivot/{page}.aspx");
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
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}