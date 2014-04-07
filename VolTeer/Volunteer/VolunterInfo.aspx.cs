using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.Cache.VT.Vol;
using System.Web.Security;
using VolTeer.App_Code;
using System.Web.UI.HtmlControls;




namespace VolTeer.Volunteer
{
    public partial class VolunterInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
     //       throw new InvalidOperationException("An InvalidOperationException " +
     //"occurred in the Page_Load handler on the Default.aspx page.");
            // ucVolAddress.ShowErrorOccurs += new EventHandler(ShowErrors);

            if (!IsPostBack)
            {
                LoadPage();
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