using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;


namespace PivotcardSite
{
    public partial class servicetest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Membership.CreateUser("billdad", "shumway");
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            createUser();
        }

        private void createUser()
        {
            string uName = un.Text;
            string pWord = pw.Text;
            Membership.CreateUser(uName, pWord);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser("https://www.google.com/profiles/103196419386017633518", "Google"))
            {
                FormsAuthentication.SetAuthCookie("https://www.google.com/profiles/103196419386017633518", false);
                FormsAuthentication.Authenticate("https://www.google.com/profiles/103196419386017633518", "Google");
            }
        }

        protected void testXdoc_Click(object sender, EventArgs e)
        {
            XDocument usersDoc = XDocument.Load(MapPath("~/App_Data/tblUsers.xml"));
            try
            {
                XElement userNode =
                   usersDoc.Element("Users")
                        .Elements("User")
                        .Descendants("UserName")
                        .Where(x => x.Value == "https://www.google.com/profiles/103196419386017633518").First();
                Response.Write(userNode.Parent.Name.ToString());
            }
            catch
            {
                Response.Write("not there");
            }
            
        }

        protected void mkPF_Click(object sender, EventArgs e)
        {
            string pName = "foobar";
            string pth = "~/App_Data/" + pName + ".xml";
            if (!File.Exists(MapPath(pth)))
            {
                XDocument pivotsDoc = new XDocument();
                pivotsDoc.Add(new XElement("Pivots"));
                pivotsDoc.Save(MapPath(pth));
            }
        }
    }
}