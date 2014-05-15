using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_ProjectEventContact_DAL {
        #region Select Statements
        public List<sp_ProjectEventContact_DM> ListEventsContacts(Guid? EventID,Guid? ContactID)
        {
            List<sp_ProjectEventContact_DM> list = new List<sp_ProjectEventContact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_ProjectEventContact_Select(EventID,ContactID)
                            select new sp_ProjectEventContact_DM
                            {
                                EventID = result.EventID,
                                ContactID = result.ContactID,
                                PrimaryContact = result.PrimaryContact
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
            return list;
        }

        public List<sp_ProjectEventContact_DM> ListEventsContacts()
        {
            return ListEventsContacts(null,null);
        }
        #endregion

        #region Insert Statements
        public Guid InsertProjectEventContactContext(sp_ProjectEventContact_DM InputProjectEventContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewProjectEventContact = new tblProjectEventContact
                {
                    EventID = InputProjectEventContact.EventID,
                    ContactID = InputProjectEventContact.ContactID,
                    PrimaryContact = InputProjectEventContact.PrimaryContact
                };
                context.tblProjectEventContacts.Add(NewProjectEventContact);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewProjectEventContact.EventID;
            }
        }
        #endregion

        #region Update Statements
        public void UpdateProjectEventContactContext(sp_ProjectEventContact_DM InputProjectEventContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingProjectEventContact = context.tblProjectEventContacts.Find(InputProjectEventContact.EventID);

                if (InputProjectEventContact != null)
                {
                    existingProjectEventContact.EventID = InputProjectEventContact.EventID;
                    existingProjectEventContact.ContactID = InputProjectEventContact.ContactID;
                    existingProjectEventContact.PrimaryContact = InputProjectEventContact.PrimaryContact;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteProjectEventContactContext(sp_ProjectEventContact_DM InputProjectEventContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ProjectEventContactToRemove = (from n in context.tblProjectEventContacts 
                                                   where (n.EventID == InputProjectEventContact.EventID && n.ContactID == InputProjectEventContact.ContactID)
                                                   select n).FirstOrDefault();
                context.tblProjectEventContacts.Remove(ProjectEventContactToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
