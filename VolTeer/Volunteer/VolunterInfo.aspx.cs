using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.Cache.VT.Vol;
using System.Web.Security;


namespace VolTeer.Volunteer
{
    public partial class VolunterInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            rTBVolID.Text = DataBinder.Eval(VolDM, "VolID").ToString();           
        }


        protected void RadButton1_Click(object sender, EventArgs e)
        {
            UserControl UC = ucVolBasicInfo;
            ucVolBasicInfo.publicstring = "3";
            ucVolBasicInfo.PushButton();
        }

    }
}