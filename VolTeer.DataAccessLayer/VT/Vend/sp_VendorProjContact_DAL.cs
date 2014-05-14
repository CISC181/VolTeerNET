using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_VendorProjContact_DAL : sp_VendorProjContact_CON
    {

        #region Select Statements
        public List<sp_VendorProjContact_DM> ListContact(Guid VendorID, Guid ProjectID, Guid ContactID)
        {
            List<sp_VendorProjContact_DM> list = new List<sp_VendorProjContact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_VendorProjContact_Select(VendorID, ProjectID, ContactID)
                            select new sp_VendorProjContact_DM
                            {
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

        public List<sp_VendorProjContact_DM> ListContact()
        {
            return ListContact();
        }
        #endregion

        #region Insert Statements
        public Guid InsertContactContext(sp_VendorProjContact_DM InputContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewContact = new tblVendorProjContact
                {
                    VendorID = InputContact.VendorID,
                    ProjectID = InputContact.ProjectID,
                    ContactID = InputContact.ContactID,
                    PrimaryContact = InputContact.PrimaryContact
                };
                context.tblVendorProjContacts.Add(NewContact);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewContact.ContactID;
            }
        }
        #endregion

        #region Update Statements
        public void UpdateContactContext(sp_VendorProjContact_DM InputContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingContact = context.tblVendorProjContacts.Find(InputContact.VendorID, 
                                                                         InputContact.ProjectID, 
                                                                         InputContact.ContactID,
                                                                         InputContact.PrimaryContact);

                if (InputContact != null)
                {
                    existingContact.VendorID = InputContact.VendorID;
                    existingContact.ProjectID = InputContact.ProjectID;
                    existingContact.ContactID = InputContact.ContactID;
                    existingContact.PrimaryContact = InputContact.PrimaryContact;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteContactContext(sp_VendorProjContact_DM InputContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendorProjContactsToRemove = (from n in context.tblVendorProjContacts where n.VendorID == InputContact.VendorID 
                                                      && n.ProjectID == InputContact.ProjectID
                                                      && n.ContactID == InputContact.ContactID select n).FirstOrDefault();
                context.tblVendorProjContacts.Remove(VendorProjContactsToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
