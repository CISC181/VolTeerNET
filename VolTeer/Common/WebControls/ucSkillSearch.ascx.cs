using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using Telerik.Web.UI;


namespace VolTeer.Common.WebControls
{
    public partial class ucSkillSearch : System.Web.UI.UserControl
    {
        sp_Skill_BLL SkillsBLL = new sp_Skill_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDataSource();

        }

        private void SetDataSource()
        {
            rACSkills.DataSource = SkillsBLL.ListSkills();
            rACSkills.DataTextField = "SkillName";
            rACSkills.DataValueField = "SkillID";

        }

        protected void rBTNProcess_Click(object sender, EventArgs e)
        {
            AutoCompleteBoxEntryCollection entries = this.rACSkills.Entries;
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].Value == string.Empty)
                {
                    Response.Write("New Skill:" + entries[i].Text);
                }
                else
                {
                    Response.Write("Existing Skill: " + entries[i].Text + entries[i].Value);
                }
            }
        }



    }
}