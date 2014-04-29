using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_VolSkill_CON
    {
        void DeleteVolSkillALL(Guid? VolID);
        void InsertVolSkill(Guid? VolID, Guid? SkillID);
        List<sp_VolSkill_DM> ListVolSkills(Guid VolID);
    }
}
