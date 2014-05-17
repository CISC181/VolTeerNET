using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    public class sp_Skill_DM
    {
        public Guid SkillID { get; set; }
        public string SkillName { get; set; }
        public Guid? MstrSkillID { get; set; }
        public int ActiveFlg { get; set; }
        public bool? ReqCert { get; set; }
        public bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            sp_Skill_DM spskill = (sp_Skill_DM)obj;

            return spskill.ActiveFlg == this.ActiveFlg &&
                   spskill.SkillID.Equals(this.SkillID) &&
                   spskill.SkillName.Equals(this.SkillName) &&
                   spskill.MstrSkillID.Equals(this.MstrSkillID);
        }

    }
}
