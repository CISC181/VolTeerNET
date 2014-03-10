using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;
using VolTeer.DataAccessLayer.VT;

namespace VolTeer.BusinessLogicLayer.VT
{
    public class SkillBLL
    {
        private SkillDAL DAL = new SkillDAL();

        public List<Skill_DM> ListSkills()
        {
            return DAL.ListSkills();
        }
    }
}
