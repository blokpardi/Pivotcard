using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PivotcardSite
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpBrowserCapabilities browser = Request.Browser;
            if (Request.Cookies["login"] != null)
                Response.Redirect("my-pivots.aspx");
            else
                Response.Redirect("home.aspx");
        }
    }
}