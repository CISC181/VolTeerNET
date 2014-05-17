using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Skill_DAL : sp_Skills_CON 
    {
        #region Select Statements
        public List<sp_Skill_DM> ListSkills()
        {
            List<sp_Skill_DM> list = new List<sp_Skill_DM>();
            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.tblSkills 
                        select new sp_Skill_DM
                        {
                            SkillID = result.SkillID,
                            SkillName = result.SkillName,
                            MstrSkillID = result.MstrSkillID,
                            ActiveFlg = result.ActiveFlg,
                            ReqCert = result.ReqCert

                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }

        public List<sp_Skill_DM> ListSkills(Guid? Skill)
        {
            List<sp_Skill_DM> list = new List<sp_Skill_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Skill_Select(Skill)
                            select new sp_Skill_DM
                            {
                            SkillID = result.SkillID,
                            SkillName = result.SkillName,
                            MstrSkillID = result.MstrSkillID,
                            ActiveFlg = result.ActiveFlg,
                            ReqCert = result.ReqCert
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;



        }

        public List<sp_Skill_DM> ListSkills(bool showNullMstrSkill)
        {
            List<sp_Skill_DM> list = new List<sp_Skill_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Skill_Select_Manage(showNullMstrSkill)
                            select new sp_Skill_DM
                            {
                                SkillID = result.SkillID,
                                SkillName = result.SkillName,
                                MstrSkillID = result.MstrSkillID,
                                ActiveFlg = result.ActiveFlg,
                                ReqCert = result.ReqCert

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;



        }

        #endregion

        #region Insert Statements
        /// <summary>
        /// InsertSkillContext - Will insert a record into Skill table via SProc
        /// </summary>
        /// <param name="_cSkill"></param>
        public void InsertSkillContext(ref sp_Skill_DM _cSkill)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cSkill = new tblSkill
                {
                    SkillName = _cSkill.SkillName,
                    MstrSkillID = _cSkill.MstrSkillID
                };
                context.tblSkills.Add(cSkill);
                context.SaveChanges();
                _cSkill.SkillID = cSkill.SkillID;
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateSampleAddressContext - Will update a given Skill record by SkillID
        /// </summary>
        /// <param name="_cSkill"></param>
        public void UpdateSampleAddressContext(sp_Skill_DM _cSkill)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cSkill = context.tblSkills.Find(_cSkill.SkillID);

                if (cSkill != null)
                {
                    cSkill.SkillID = _cSkill.SkillID;
                    cSkill.SkillName = _cSkill.SkillName;
                    cSkill.MstrSkillID = _cSkill.MstrSkillID;
                    context.SaveChanges();
                }
            }
        }
        #endregion

         #region Delete Statements

        /// <summary>
        /// DeleteSkillContext - Will do a soft delete (make inactive) by SkillID
        /// </summary>
        /// <param name="_cSkill"></param>
        public void DeleteSkillContext(sp_Skill_DM _cSkill)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var SkillToRemove = (from n in context.tblSkills where n.SkillID == _cSkill.SkillID select n).FirstOrDefault();
                context.tblSkills.Remove(SkillToRemove);
                context.SaveChanges();

            }
        }
        #endregion

    }
}
