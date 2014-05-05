using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using VolTeer.BusinessLogicLayer.VT.Vend;
using VolTeer.DomainModels.VT.Vend;
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

            sp_Vendor_BLL bll = new sp_Vendor_BLL();
            sp_Vendor_DM venddm = new sp_Vendor_DM();


            venddm.ActiveFlg = true;
            venddm.VendorName = "test";
            venddm.VendorID = (Guid)user.ProviderUserKey;
            venddm = bll.InsertVendorContext(ref venddm);


            cMail.SendMessage("test@test.com", (CreateUserWizardStep1.ContentTemplateContainer.FindControl("Email") as RadTextBox).Text.Trim(), "VolTeer Registration", "Please click link to confirm");

            string continueUrl = "~/";
            Response.Redirect(continueUrl);
            
        }


    }
}