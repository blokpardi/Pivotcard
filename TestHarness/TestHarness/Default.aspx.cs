using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PivotCardService; 

namespace TestHarness
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //bool pwchange = PivotCardService.UserData.updateUserInfo("paultest", "pardipf1", "P@ssw0rd", "paultest1");

            string retval = PivotCardService.UserData.checkUser("paultest", "P@ssw0rd").ToString();
            retval = retval + PivotCardService.UserData.checkUser("paultest").ToString(); 
            this.TextBox1.Text = retval.ToString();  

            PivotCardService.UserData.checkUser(

            //bool ret = PivotCardService.UserData.deleteUser("paulp"); 
            //bool myPivot = PivotCardService.UserData.addUserToDB("billp",null,"billpardi","P@ssw0rd");
            
        //    BrowserInfo bi = new BrowserInfo(); 
        //    bi = bi.GetBrowserInfo(Request);
        //    Console.Write("here");

        //    string s = "Browser Capabilities\n"
        //+ "Type = " + bi.browserType + "\n"
        //+ "Name = " + bi.browserName + "\n"
        //+ "Version = " + bi.browserVersion + "\n"
        //+ "Major Version = " + bi.browserMajorVersion + "\n"
        //+ "Minor Version = " + bi.browserMinorVersion + "\n"
        //+ "Platform = " + bi.browserPlatform + "\n"
        //+ "Is Beta = " + bi.browserIsBeta + "\n"
        //+ "Is Crawler = " + bi.browserIsCrawler + "\n"
        //+ "Is AOL = " + bi.browserIsAOL + "\n"
        //+ "Is Win16 = " + bi.browserIsWin16 + "\n"
        //+ "Is Win32 = " + bi.browserIsWin32 + "\n"
        //+ "Supports Frames = " + bi.browserSupportsFrames + "\n"
        //+ "Supports Tables = " + bi.browserSupportsTables + "\n"
        //+ "Supports Cookies = " + bi.browserSupportsCookies + "\n"
        //+ "Supports VBScript = " + bi.browserSupportsVB + "\n"
        //+ "Supports JavaScript = " +
        //    bi.browserSupportsJavascript + "\n"
        //+ "Supports Java Applets = " + bi.browserSupportsJava + "\n"
        //+ "Supports ActiveX Controls = " + bi.browserSupportsAX
        //      + "\n"
        //+ "Supports JavaScript Version = " +
        //    bi.browserVersion + "\n" +
        //    "Mobile = " + bi.IsMobileDevice + "\n" +
        //    "Supports HTML5 = " + bi.SupportsHTML5; 

        //    this.TextBox1.Text = s; 

            

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
