using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_VolEmail_DAL
    {
        #region Select Statements
        /// <summary>
        /// Return a list of Sample addresses using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Email_DM> ListEmails()
        {
            List<sp_Email_DM> list = new List<sp_Email_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Email_Select(null)
                            select new sp_Email_DM
                            {
                                EmailID = result.EmailID,
                                EmailAddr = result.EmailAddr,
                                VolID = result.VolID,
                                ActiveFlg = result.ActiveFlg,
                                PrimaryFlg = result.PrimaryFlg

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        public List<sp_Email_DM> ListEmails(int EmailIds)
        {
            List<sp_Email_DM> list = new List<sp_Email_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Email_Select(EmailIds)
                            select new sp_Email_DM
                            {
                                EmailID = result.EmailID,
                                EmailAddr = result.EmailAddr,
                                VolID = result.VolID,
                                ActiveFlg = result.ActiveFlg,
                                PrimaryFlg = result.PrimaryFlg
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }
        /*
        public sp_Email_DM ListEmails(Guid? Volunteer)
        {
            List<sp_Email_DM> list = new List<sp_Email_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Email_Select(Volunteer)
                            select new sp_Email_DM
                            {
                                EmailID = result.EmailID,
                                EmailAddr = result.EmailAddr,
                                VolID = result.VolID,
                                ActiveFlg = result.ActiveFlg,
                                PrimaryFlg = result.PrimaryFlg

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list.FirstOrDefault();

        }
        */
        public sp_Email_DM ListPrimaryEmail(int EmailIds)
        {
            sp_Email_DM item = new sp_Email_DM();            
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    item = (from result in context.sp_Vol_Email_Select(EmailIds)
                            select new sp_Email_DM
                            {
                                EmailID = result.EmailID,
                                EmailAddr = result.EmailAddr,
                                VolID = result.VolID,
                                ActiveFlg = result.ActiveFlg,
                                PrimaryFlg = result.PrimaryFlg
                            }).FirstOrDefault();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return item;

        }

        #endregion


        #region Insert Statements


        /// <summary>
        /// InsertEmailContext - Will insert a record into Volunteer Email table via SProc
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void InsertEmailContext(sp_Email_DM _cEmail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cEmail = new tblVolEmail
                {
                    VolID = _cEmail.VolID,
                    EmailID = _cEmail.EmailID,
                    EmailAddr = _cEmail.EmailAddr,
                    ActiveFlg = _cEmail.ActiveFlg,
                    PrimaryFlg = _cEmail.PrimaryFlg
                    
                };
                context.tblVolEmails.Add(cEmail);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateEmailAddr - Will update a given Email Address record by EmailID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void UpdateEmailAddr(sp_Email_DM _cEmail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cEmail = context.tblVolEmails.Find(_cEmail.EmailID);

                if (cEmail != null)
                {
                    cEmail.EmailAddr = _cEmail.EmailAddr;
                    cEmail.VolID = _cEmail.VolID;
                    cEmail.ActiveFlg = _cEmail.ActiveFlg;
                    cEmail.PrimaryFlg = _cEmail.PrimaryFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements

        /// <summary>
        /// DeleteEmailsContext - Will do a soft delete (make inactive) by EmailID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void DeleteEmailsContext(sp_Email_DM _cEmail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var EmailsToRemove = (from n in context.tblVolEmails where n.EmailID == _cEmail.EmailID select n).FirstOrDefault();
                context.tblVolEmails.Remove(EmailsToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
