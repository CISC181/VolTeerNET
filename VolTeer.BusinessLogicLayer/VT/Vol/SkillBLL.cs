using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;

namespace VolTeer.BusinessLogicLayer.VT.Vol
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
