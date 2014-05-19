using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Vend.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChangePassword1.ContinueDestinationPageUrl = ConfigurationManager.AppSettings["HomePage"].ToString();
        }

        protected void ChangePassword1_ChangingPassword(Object sender, LoginCancelEventArgs e)
        {
            if (ChangePassword1.CurrentPassword.ToString() == ChangePassword1.NewPassword.ToString())
            {
                LabelChangePassword.Visible = true;
                LabelChangePassword.Text = "Old password and new password must be different.  Please try again.";
                e.Cancel = true;
            }
            else
            {
                //This line prevents the error showing up after a first failed attempt.
                LabelChangePassword.Visible = false;
            }
        }

        protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
        {

        }

        protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
        {

        }

    }
}