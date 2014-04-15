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
        public Guid? MstrSkilID { get; set; }
        public string SkillName { get; set; }
    }
}
