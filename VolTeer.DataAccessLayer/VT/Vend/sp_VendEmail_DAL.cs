using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_VendEmail_DAL : sp_VendEmail_CON
    {

        #region Select Statements
        public sp_VendEmail_DM ListEmails(int EmailID)
        {
            List<sp_VendEmail_DM> list = new List<sp_VendEmail_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vend_Email_Select(EmailID,true)
                            select new sp_VendEmail_DM
                            {
                                EmailID = result.EmailID,
                                EmailAddr = result.EmailAddr,
                                ActiveFlg = result.ActiveFlg
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list.FirstOrDefault();
        }

        public List<sp_VendEmail_DM> ListEmails()
        {
            return ListEmails();
        }
        #endregion

        #region Insert Statements
        public int InsertEmailContext(sp_VendEmail_DM InputEmail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewEmail = new tblVendEmail
                {
                    EmailAddr = InputEmail.EmailAddr,
                    ActiveFlg = InputEmail.ActiveFlg
                };
                context.tblVendEmails.Add(NewEmail);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewEmail.EmailID;
            }
        }
        #endregion

        #region Update Statements
        public void UpdateEmailContext(sp_VendEmail_DM InputEmail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingEmail = context.tblVendEmails.Find(InputEmail.EmailID);

                if (InputEmail != null)
                {
                    existingEmail.EmailAddr = InputEmail.EmailAddr;
                    existingEmail.ActiveFlg = InputEmail.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteEmailContext(sp_VendEmail_DM InputEmail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendEmailToRemove = (from n in context.tblVendEmails where n.EmailID == InputEmail.EmailID select n).FirstOrDefault();
                context.tblVendEmails.Remove(VendEmailToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}