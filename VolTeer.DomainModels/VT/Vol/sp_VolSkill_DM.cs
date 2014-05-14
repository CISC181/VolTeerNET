using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    public class sp_VolSkill_DM
    {
        public Guid VolID { get; set; }
        public Guid SkillID { get; set; }
        public Guid? MstrSkillID { get; set; }
        public string SkillName { get; set; }

        public bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            sp_VolSkill_DM spvolskill = (sp_VolSkill_DM)obj;

            return spvolskill.MstrSkillID.Equals(this.MstrSkillID) &&
                   spvolskill.SkillID.Equals(this.SkillID) &&
                   spvolskill.SkillName.Equals(this.SkillName) &&
                   spvolskill.VolID.Equals(this.VolID);
        }
    }
}
