using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;

namespace  VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_VolSkill_BLL : sp_VolSkill_CON 
    {
        sp_VolSkill_DAL DAL = new sp_VolSkill_DAL();

        public List<sp_VolSkill_DM> ListVolSkills(Guid VolID)
        {
            return DAL.ListVolSkills(VolID);
        }
        public void InsertVolSkill(Guid? VolID, Guid? SkillID)
        {
            DAL.InsertVolSkill(VolID, SkillID);
        }

        public void DeleteVolSkillALL(Guid? VolID)
        {
            DAL.DeleteVolSkillALL(VolID);
        }

    }
}
