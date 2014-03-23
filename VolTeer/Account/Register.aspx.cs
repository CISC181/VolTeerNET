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
            sp_Volunteer_DM vol = new sp_Volunteer_DM();

            vol.VolID = (Guid)user.ProviderUserKey;
            vol.VolFirstName = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("rTXTFirstName") as RadTextBox).Text.Trim();
            vol.VolMiddleName  = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("rTXTMiddleName") as RadTextBox).Text.Trim();
            vol.VolLastName = (CreateUserWizardStep1.ContentTemplateContainer.FindControl("rTXTLastName") as RadTextBox).Text.Trim();
            vol.ActiveFlg = true;


            BLL.InsertVolunteerContext(vol);

            cMail.SendMessage("test@test.com", (CreateUserWizardStep1.ContentTemplateContainer.FindControl("Email") as RadTextBox).Text.Trim(), "VolTeer Registration", "Please click link to confirm");

            string continueUrl = "~/";
            Response.Redirect(continueUrl);
            
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        //protected void btnRegisterUser_Click(object sender, EventArgs e)
        //{
        //    MembershipCreateStatus createStatus;
        //    MembershipUser newUser = Membership.CreateUser(RegisterUser.UserName, RegisterUser.Password, RegisterUser.Email, "question", "answer", true, out createStatus);
        //    switch (createStatus)
        //    {
        //        case MembershipCreateStatus.Success:
        //            lblError.Text = "The user account was successfully created!";
        //            break;
        //        case MembershipCreateStatus.DuplicateUserName:
        //            lblError.Text = "There already exists a user with this username.";
        //            break;
        //        case MembershipCreateStatus.DuplicateEmail:
        //            lblError.Text = "There already exists a user with this email address.";
        //            break;
        //        case MembershipCreateStatus.InvalidEmail:
        //            lblError.Text = "There email address you provided in invalid.";
        //            break;
        //        case MembershipCreateStatus.InvalidAnswer:
        //            lblError.Text = "There security answer was invalid.";
        //            break;
        //        case MembershipCreateStatus.InvalidPassword:
        //            lblError.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
        //            break;
        //        default:
        //            lblError.Text = "There was an unknown error; the user account was NOT created.";
        //            break;
        //    }

        //    Roles.AddUserToRole(RegisterUser.UserName, ConfigurationManager.AppSettings["DefaultVolRole"]);
                        
        //    if (createStatus == MembershipCreateStatus.Success)
        //    {
        //        // Log the user in
        //        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

        //        sp_Volunteer_BLL BLL = new sp_Volunteer_BLL();
        //        AspNetViewsBLL ASPBLL = new AspNetViewsBLL();
        //        vw_aspnet_MembershipUsers_DM aspUser = new vw_aspnet_MembershipUsers_DM();
        //        sp_Volunteer_DM vol = new sp_Volunteer_DM();



        //        aspUser = ASPBLL.ListUser(RegisterUser.UserName);

        //        vol.VolID = aspUser.UserId;
        //        vol.ActiveFlg = true;


        //        BLL.InsertVolunteerContext(vol);


        //        string continueUrl = "~/";
        //        Response.Redirect(continueUrl);



        //    }
        //}

    }
}