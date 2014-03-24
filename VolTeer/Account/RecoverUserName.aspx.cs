using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.DomainModels.AspNet;
using VolTeer.BusinessLogicLayer.AspNet;
using Telerik.Web.UI;
using VolTeer.App_Code;

namespace VolTeer.Account
{
    public partial class RecoverUserName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// rBTNSubmit_Click - Find the user's information, then email the user their user name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rBTNSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AspNetViewsBLL ASPBLL = new AspNetViewsBLL();
                vw_aspnet_MembershipUsers_DM aspUser = new vw_aspnet_MembershipUsers_DM();
                aspUser = ASPBLL.ListUserByEmail(rTXTEmailAddress.Text.ToString());

                if (aspUser == null)
                {
                    // user not found by email
                    // already handled in server validate
                }
                else
                {
                    string[,] MergeValues = new string[,] { { "{UserName}", aspUser.UserName } };
                    cMail.SendMessage("noreply@volteer.com", aspUser.Email, "Forgot Password", cMail.PopulateBody("~/Content/EmailTemplates/ForgotUserName.html", MergeValues));
                }
                pnlRecover.Visible = false;
                pnlContinue.Visible = true;
            }
        }

        /// <summary>
        /// valEmail_ServerValidate - Run this validation when the form is posted.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void valEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            AspNetViewsBLL ASPBLL = new AspNetViewsBLL();
            vw_aspnet_MembershipUsers_DM aspUser = new vw_aspnet_MembershipUsers_DM();
            aspUser = ASPBLL.ListUserByEmail(rTXTEmailAddress.Text.ToString());

            args.IsValid = true;
            if (aspUser == null)
            {
                args.IsValid = false;
            }
        }

    }
}