using System;
using System.Collections.Generic;
using System.Linq;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_ContactEmail_DAL : sp_ContactEmail_CON
    {
        #region Select Statements

        public List<sp_ContactEmail_DM> ListContactEmails(Guid? contactid, int? emailid)
        {
            List<sp_ContactEmail_DM> list = new List<sp_ContactEmail_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_ContactEmail_Select(contactid, emailid)
                            select new sp_ContactEmail_DM
                            {
                                ContactID = result.ContactID,
                                EmailID = result.EmailID,
                                PrimaryEmail = result.PrimaryEmail
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }

        public List<sp_ContactEmail_DM> ListContactEmails()
        {
            return ListContactEmails(null, null);
        }

        public sp_ContactEmail_DM ListContactEmails(Guid contactid, int emailid)
        {
            List<sp_ContactEmail_DM> list = new List<sp_ContactEmail_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_ContactEmail_Select(contactid, emailid)
                            select new sp_ContactEmail_DM
                            {
                                ContactID = result.ContactID,
                                EmailID = result.EmailID,
                                PrimaryEmail = result.PrimaryEmail
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list.FirstOrDefault();
        }
        #endregion

        #region Insert Statements
        public void InsertContactEmailContext(sp_ContactEmail_DM contactemail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewContactEmail = new tblContactEmail
                {
                    ContactID = contactemail.ContactID,
                    EmailID = contactemail.EmailID,
                    PrimaryEmail = contactemail.PrimaryEmail
                };
                context.tblContactEmails.Add(NewContactEmail);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statements
        public void UpdateContactEmailContext(sp_ContactEmail_DM contactemail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ExistingContactEmail = context.tblContactEmails.Find(contactemail.ContactID, contactemail.EmailID);
                if (ExistingContactEmail != null)
                {
                    ExistingContactEmail.PrimaryEmail = contactemail.PrimaryEmail;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteContactEmailContext(sp_ContactEmail_DM contactemail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ContactEmailtoRemove = (from n in context.tblContactEmails where n.ContactID == contactemail.ContactID & n.EmailID == contactemail.EmailID select n).FirstOrDefault();
                context.tblContactEmails.Remove(ContactEmailtoRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
