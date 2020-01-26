using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PivotcardSite
{
    public partial class janraintest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var token = Request.Form["token"];
            var rpx = new Rpx("38b726baa689dd1afdcb82e91f905101e660d73a", "https://rpxnow.com");
            var authInfo = rpx.AuthInfo(token);
            var doc = XDocument.Load(new XmlNodeReader(authInfo));
            Response.Write(doc.Root.Descendants("identifier").First().Value);
        }
    }
}