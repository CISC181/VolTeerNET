using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.Cache.VT.Vol;
using System.Web.Security;
using VolTeer.App_Code;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;




namespace VolTeer.Volunteer
{
    public partial class VolunterInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // ucVolAddress.ShowErrorOccurs += new EventHandler(ShowErrors);



            if (!IsPostBack)
            {
                LoadPage();
            }

            try
            {

                //RadMultiPage rMP = (RadMultiPage)Page.FindControl("ucVolAddress");
                //UserControl = ucVolAddress
                RadGrid rGridAddress = (RadGrid)ucVolAddress.FindControl("rGridAddress");
                RadAjaxManager1.AjaxSettings.AddAjaxSetting(rGridAddress, rGridAddress);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }


        protected void LoadPage()
        {
            MembershipUser currentUser = Membership.GetUser();
            Guid? UserID = (Guid)currentUser.ProviderUserKey;

            sp_Volunteer_Cache VolCASH = new sp_Volunteer_Cache();
            sp_Volunteer_DM VolDM = new sp_Volunteer_DM();

            VolDM = VolCASH.ListVolunteers(UserID);

            hdVolID.Value = DataBinder.Eval(VolDM, "VolID").ToString();
            hdEditView.Value = "1";

            //Handle ucVolBasicInfo parameters
            ucVolBasicInfo.UserID = UserID;
        }


        protected void RadButton1_Click(object sender, EventArgs e)
        {
            ucVolBasicInfo.SaveUserInfo();

        }

    }


}