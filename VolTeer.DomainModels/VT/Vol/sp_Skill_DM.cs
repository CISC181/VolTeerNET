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

    }
}
