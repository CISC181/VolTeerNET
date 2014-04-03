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
using VolTeer.App_Code;


namespace VolTeer.Common.WebControls
{
    
    
    public partial class ucVolBasicInfo : System.Web.UI.UserControl
    {
        internal Guid? UserID;

        /// <summary>
        /// Execute Page Load instructions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserInfo();
            }
        }

        /// <summary>
        /// Load the User Info based on the current Volunteer
        /// </summary>
        protected void LoadUserInfo()
       {
            sp_Volunteer_Cache VolCASH = new sp_Volunteer_Cache();
            sp_Volunteer_DM VolDM = new sp_Volunteer_DM();

            VolDM = VolCASH.ListVolunteers(UserID);

            rTBFirstName.Text = cCommonFunctions.HandleDBNull(VolDM.VolFirstName);
            rTBMiddleName.Text = cCommonFunctions.HandleDBNull(VolDM.VolMiddleName);
            rTBLastName.Text = cCommonFunctions.HandleDBNull(VolDM.VolLastName);
        }

        /// <summary>
        /// SaveUserInfo - Called from parent screen, build a domain model and save the user info
        /// </summary>
        internal void SaveUserInfo()
        {
            sp_Volunteer_Cache VolCASH = new sp_Volunteer_Cache();
            sp_Volunteer_DM VolDM = new sp_Volunteer_DM();

            //  Get the VolID from the parent form
            VolDM.VolID = new Guid(((HiddenField)Parent.FindControl("hdVolID")).Value);

            //  Get the other info from the controls in this container
            VolDM.VolFirstName = cCommonFunctions.SetNullIfEmpty(rTBFirstName.Text.ToString());
            VolDM.VolMiddleName = cCommonFunctions.SetNullIfEmpty(rTBMiddleName.Text.ToString());
            VolDM.VolLastName = cCommonFunctions.SetNullIfEmpty(rTBLastName.Text.ToString());

            VolCASH.UpdateVolunteerContext(VolDM);
        }

    }
}