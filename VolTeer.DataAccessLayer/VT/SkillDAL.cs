using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;


namespace VolTeer.DataAccessLayer.VT
{
    public class SkillDAL
    {
        public List<Skill_DM> ListSkills()
        {
            List<Skill_DM> list = new List<Skill_DM>();
            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.tblSkills 
                        select new Skill_DM
                        {
                            SkillID = result.SkillID,
                            SkillName = result.SkillName,
                            MstrSkillID = result.MstrSkillID

                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }
    }
}
