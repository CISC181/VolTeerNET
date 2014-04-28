using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_Skills_CON
    {
        List<sp_Skill_DM> ListSkills();
        List<sp_Skill_DM> ListSkills(Guid? Skill);
        void UpdateSampleAddressContext(sp_Skill_DM _cSkill);
        void InsertSkillContext(ref sp_Skill_DM _cSkill);
        void DeleteSkillContext(sp_Skill_DM _cSkill);
    }
}
