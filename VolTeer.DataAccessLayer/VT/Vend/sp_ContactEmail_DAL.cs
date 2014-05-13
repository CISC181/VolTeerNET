using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_ContactEmail_DAL
    {
        #region Select Statements
        public List<sp_ContactEmail_DM> ListContacts(Guid? contactid, int? emailid)
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


        #endregion

        #region Insert Statements
        public void insert(sp_ContactEmail_DM contactemail)
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
        public void update(sp_ContactEmail_DM contactemail)
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
        public void delete(sp_ContactEmail_DM contactemail)
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
