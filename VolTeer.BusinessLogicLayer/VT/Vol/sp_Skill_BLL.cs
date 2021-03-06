﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;

namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_Skill_BLL : sp_Skills_CON 
    {
         sp_Skill_DAL DAL = new sp_Skill_DAL();

        public List<sp_Skill_DM> ListSkills()
        {
            return DAL.ListSkills();
        }
        public sp_Skill_DM ListSingleSkill(Guid? Skill)
        {
            return DAL.ListSkills(Skill).Single();
        }

        public void InsertSkillContext(ref sp_Skill_DM _cSkill)
        {
            DAL.InsertSkillContext(ref _cSkill);
        }

        public void UpdateSampleAddressContext(sp_Skill_DM _cSkill)
        {
            DAL.UpdateSampleAddressContext(_cSkill);
        }

        public void DeleteSkillContext(sp_Skill_DM _cSkill)
        {
            DAL.DeleteSkillContext(_cSkill);
        }

        public List<sp_Skill_DM> ListSkills(bool showNullMstrSkill)
        {
            return DAL.ListSkills(showNullMstrSkill);
        }


        List<sp_Skill_DM> sp_Skills_CON.ListSkills()
        {
            throw new NotImplementedException();
        }

        List<sp_Skill_DM> sp_Skills_CON.ListSkills(Guid? Skill)
        {
            throw new NotImplementedException();
        }
    }
}
