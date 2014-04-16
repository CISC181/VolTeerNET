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

namespace VolTeer.Common.WebControls
{
    public partial class ucSkillSearch : System.Web.UI.UserControl
    {
        sp_Skill_BLL SkillsBLL = new sp_Skill_BLL();
        sp_VolSkill_BLL VolSkillBLL = new sp_VolSkill_BLL();

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

            //Delete all associated VolSkills for the given volid
            VolSkillBLL.DeleteVolSkillALL(VolID);

            AutoCompleteBoxEntryCollection entries = this.rACSkills.Entries;
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].Value == string.Empty)
                {
                    // Skill doesn't exist, insert new Skill, return SkillID through domain model
                    sp_Skill_DM SkillsDM = new sp_Skill_DM();
                    SkillsDM.SkillName = entries[i].Text.ToString();
                    SkillsDM.MstrSkillID = null;
                    SkillsBLL.InsertSkillContext(ref SkillsDM);


                    // write the existing skill to VolSkill
                    VolSkillBLL.InsertVolSkill(VolID, SkillsDM.SkillID);
                    Response.Write("New Skill:" + entries[i].Text);
                }
                else
                {
                    //Skill does exist, use existing SkillID to insert into VolSkill
                    Guid? SkillID = new Guid(entries[i].Value);

                    // write the existing skill to VolSkill
                    VolSkillBLL.InsertVolSkill(VolID, SkillID);
                    //Response.Write("Existing Skill: " + entries[i].Text + entries[i].Value);
                }
            }
        }

        protected void rbAutoComplete_CheckedChanged(object sender, EventArgs e)
        {
            pnlAutoComplete.Visible = true;
            pnlTree.Visible = false;

        }

        protected void rbTreeControl_CheckedChanged(object sender, EventArgs e)
        {
            pnlTree.Visible = true;
            pnlAutoComplete.Visible = false;
        }



    }
}