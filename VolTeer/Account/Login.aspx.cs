using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

namespace VolTeer.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = Login1.UserName.ToString();
            string pass = Login1.Password.ToString();
            Label lblErrorMsg = Login1.FindControl("lblErrorMsg") as Label;

            MembershipUser currentUser = Membership.GetUser(uname);

            if (currentUser == null)
            {
                lblErrorMsg.Text = "User Does not Exist";
            }
            else if (currentUser.IsLockedOut)
            {
                lblErrorMsg.Text = "Account is locked";
            }
            else if (currentUser.IsApproved =false)
            {
                lblErrorMsg.Text = "Account is disabled";
            }
            else if (Membership.ValidateUser(uname, pass))
            {
                string continueUrl = ConfigurationManager.AppSettings["HomePage"].ToString();
                if (continueUrl != null)
                {
                    FormsAuthentication.SetAuthCookie(uname, false);
                    Response.Redirect(continueUrl);
                }
                else if (Request.QueryString["ReturnUrl"] != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(uname, false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(uname, false);
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                lblErrorMsg.Text = "Invalid Password";
            }
        }
    }
}