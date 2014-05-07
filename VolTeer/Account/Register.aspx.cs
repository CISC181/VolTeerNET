using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DomainModels.AspNet;
using VolTeer.BusinessLogicLayer.AspNet;
using Telerik.Web.UI;
using VolTeer.App_Code;

namespace VolTeer.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //Log the user in
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            // Create Volunteer Record
            RadTextBox userNameTextBox = (RadTextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("UserName");
            MembershipUser user = Membership.GetUser(userNameTextBox.Text);
            sp_Volunteer_BLL BLL = new sp_Volunteer_BLL();
            sp_VolEmail_BLL VolEmailBLL = new sp_VolEmail_BLL();

            sp_Volunteer_DM vol = new sp_Volunteer_DM();
            sp_Email_DM volEmail = new sp_Email_DM();

            vol.VolID = (Guid)user.ProviderUserKey;
            vol.VolFirstName = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("rTXTFirstName") as RadTextBox).Text.Trim();
            vol.VolMiddleName = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("rTXTMiddleName") as RadTextBox).Text.Trim();
            vol.VolLastName = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("rTXTLastName") as RadTextBox).Text.Trim();
            vol.ActiveFlg = true;

            vol = BLL.InsertVolunteerContext(ref vol);


            volEmail.VolID = (Guid)user.ProviderUserKey;
            volEmail.EmailAddr = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("Email") as RadTextBox).Text.Trim(); 
            volEmail.ActiveFlg = true;
            volEmail.PrimaryFlg = true;

            VolEmailBLL.InsertEmailContext(ref volEmail);
            

            cMail.SendMessage("test@test.com", (CreateUserWizardStep1.ContentTemplateContainer.FindControl("Email") as RadTextBox).Text.Trim(), "VolTeer Registration", "Please click link to confirm");

            string continueUrl = "~/";
            Response.Redirect(continueUrl);

        }

        protected void RegisterUser_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {

        }


    }
}