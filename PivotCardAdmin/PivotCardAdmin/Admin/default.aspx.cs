using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PivotCardService;

namespace PivotCardAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Length < 1 || tbPivotName.Text.Length < 1 || tbPassword.Text.Length < 1)
            {
                tbError.Text = "One or more fields are blank. Please fill out all fields before you add a user.";
                tbError.Visible = true; 
            }
            else
            {
                bool myPivot = PivotCardService.UserData.addUserToDB(tbUserName.Text, null, tbPivotName.Text, tbPassword.Text);

                if (myPivot == false)
                {
                    tbError.Text = "The user was not added. It could be due to a duplicate username. Try again.";
                    tbError.Visible = true;
                }
                else
                {
                    tbError.Text = "Success!";
                    tbError.Visible = true; 
                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (tbUserNameDel.Text.Length < 1)
            {
                tbError.Text = "One or more fields are blank. Please fill out all fields before you add a user.";
                tbError.Visible = true;
            }
            else
            {
                bool myPivot = PivotCardService.UserData.deleteUser(tbUserNameDel.Text);

                if (myPivot == false)
                {
                    tbError.Text = "The user was not deleted. It could be due to an invalid username. Try again.";
                    tbError.Visible = true;
                }
                else
                {
                    tbError.Text = "Success!";
                    tbError.Visible = true;
                }


            }
        }
    }
}