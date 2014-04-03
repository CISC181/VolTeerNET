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


namespace VolTeer.Common.WebControls
{
    public partial class ucVolBasicInfo : System.Web.UI.UserControl
    {
        public string publicstring;

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

            rTBFirstName.Text = IsNullOrEmpty(VolDM.VolFirstName.ToString());
            rTBMiddleName.Text = IsNullOrEmpty(VolDM.VolMiddleName.ToString());
            rTBLastName.Text = IsNullOrEmpty(VolDM.VolLastName.ToString()); 

            //rTBFirstName.Text = DataBinder.Eval(VolDM, "VolFirstName").ToString();
            //rTBMiddleName.Text = DataBinder.Eval(VolDM, "VolMiddleName") != null && !String.IsNullOrEmpty(DataBinder.Eval(VolDM, "VolMiddleName").ToString()) ? DataBinder.Eval(VolDM, "VolMiddleName").ToString() + "," : "";
            //rTBMiddleName.Text = DataBinder.Eval(VolDM, "VolMiddleName").ToString();
          //rTBLastName.Text = (string.IsNullOrEmpty(DataBinder.Eval(VolDM, "VolLastName").ToString()) ? "empty" : "notempty");
        }

        public void PushButton()
        {
            Response.Write("button pushed in subform");
        }

        private string IsNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            else
            {
                return str;
            }
        }
    }
}