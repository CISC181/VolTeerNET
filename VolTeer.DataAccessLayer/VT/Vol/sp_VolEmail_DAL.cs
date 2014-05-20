using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.Contracts.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_VolEmail_DAL : sp_VolEmail_CON
    {
        #region Select Statements
        /// <summary>
        /// Return a list or single email for a given volunteer 
        /// </summary>
        /// <returns></returns>
        public List<sp_Email_DM> ListEmails(sp_Email_DM cVolEmail)
        {
            List<sp_Email_DM> list = new List<sp_Email_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Email_Select(cVolEmail.VolID, cVolEmail.EmailID, null)
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


        public sp_Email_DM ListPrimaryEmail(sp_Email_DM cVolEmail)
        {
            sp_Email_DM item = new sp_Email_DM();            
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    item = (from result in context.sp_Vol_Email_Select(cVolEmail.VolID, null, true)
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
        public void InsertEmailContext(ref sp_Email_DM _cEmail)
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

                _cEmail.EmailID = cEmail.EmailID;
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
                var cEmail = context.tblVolEmails.Find(_cEmail.EmailID, _cEmail.VolID);

                if (cEmail != null)
                {
                    cEmail.EmailID = _cEmail.EmailID;
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
                //context.tblVolEmails.Remove(EmailsToRemove);
                EmailsToRemove.ActiveFlg = false;
                context.sp_Vol_Email_Update(EmailsToRemove.EmailID, EmailsToRemove.VolID, EmailsToRemove.EmailAddr, 
                    EmailsToRemove.ActiveFlg, EmailsToRemove.PrimaryFlg);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
