using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_VolSkill_DAL
    {

        public List<sp_VolSkill_DM> ListVolSkills(Guid VolID)
        {
            List<sp_VolSkill_DM> list = new List<sp_VolSkill_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_VolSkill_Select(VolID)
                            select new sp_VolSkill_DM
                            {
                                SkillID = result.SkillID,
                                MstrSkilID = result.MstrSkillID,
                                SkillName = result.SkillName

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;

        }
        public void InsertVolSkill(Guid? VolID, Guid? SkillID)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.Database.ExecuteSqlCommand("vol.sp_VolSkill_Insert {0}, {1}", VolID, SkillID);

            }
        }

        public void DeleteVolSkillALL(Guid? VolID)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.Database.ExecuteSqlCommand("vol.sp_VolSkill_DeleteAll {0}", VolID);

            }
        }
    }
}
