using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using Telerik.Web.UI;
using System.Web.Security;

namespace Vend.Common.WebControls
{
    public partial class ucVendorSearch : System.Web.UI.UserControl
    
        {
        private sp_Skill_BLL SkillsBLL = new sp_Skill_BLL();
        sp_VolSkill_BLL VolSkillBLL = new sp_VolSkill_BLL();
        sp_Volunteer_BLL VOL = new sp_Volunteer_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDataSource();
            if (!IsPostBack)
            {
                pnlAutoComplete.Visible = true;
                pnlTree.Visible = false;
                PaintAutoComplete();
            }
        }

        private void SetDataSource()
        {
            rACSkills.DataSource = SkillsBLL.ListSkills();
            rACSkills.DataTextField = "SkillName";
            rACSkills.DataValueField = "SkillID";
        }

        protected void PaintAutoComplete()
        {
            MembershipUser currentUser = Membership.GetUser();
            Guid VolID = (Guid)currentUser.ProviderUserKey;
            List<sp_VolSkill_DM> dt = VolSkillBLL.ListVolSkills(VolID);

            foreach (sp_VolSkill_DM item in dt)
            {
                AutoCompleteBoxEntry autoItem = new AutoCompleteBoxEntry();
                autoItem.Value = item.SkillID.ToString();
                autoItem.Text = item.SkillName.ToString();
                rACSkills.Entries.Add(autoItem);
            }
        }

        protected void rBTNProcess_Click(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser();
            Guid? VolID = (Guid)currentUser.ProviderUserKey;
            List<sp_Volunteer_DM> VolTeers = VOL.ListVolunteers();
            foreach (sp_Volunteer_DM volDM in VolTeers){
                        // doStuff
            }

        }

        protected void rBTNProcessTree_Click(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser();
            Guid? VolID = (Guid)currentUser.ProviderUserKey;

            TreeListColumnsCollection entries = this.rTLSkills.Columns;
        }


        protected void rbAutoComplete_CheckedChanged(object sender, EventArgs e)
        {
            pnlAutoComplete.Visible = true;
            //pnlTree.Visible = false;

        }

        protected void rbTreeControl_CheckedChanged(object sender, EventArgs e)
        {
            pnlTree.Visible = true;
            pnlAutoComplete.Visible = false;

            MembershipUser currentUser = Membership.GetUser();
            Guid VolID = (Guid)currentUser.ProviderUserKey;
            List<sp_VolSkill_DM> dt = VolSkillBLL.ListVolSkills(VolID);
            rTLSkills.DataSource = dt;

        }

        protected void rTLSkills_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
        {

            MembershipUser currentUser = Membership.GetUser();
            Guid VolID = (Guid)currentUser.ProviderUserKey;
            List<sp_VolSkill_DM> dt = VolSkillBLL.ListVolSkills(VolID);
            rTLSkills.DataSource = dt;
        }


    }
}