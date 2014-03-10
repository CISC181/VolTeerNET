using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT
{
    public class Skill_DM
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public Nullable<int> MstrSkillID { get; set; }

    }
}
