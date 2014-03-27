using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_VendContact_DAL
    {

        #region Select Statements
        public List<sp_VendContact_DM> ListContacts(Guid? ContactID)
        {
            List<sp_VendContact_DM> list = new List<sp_VendContact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Contact_Select(ContactID)
                            select new sp_VendContact_DM
                            {
                                ContactID = result.ContactID,
                                ContactFirstName = result.ContactFirstName,
                                ContactMiddleName = result.ContactMiddleName,
                                ContactLastName = result.ContactLastName,
                                ActiveFlg = result.ActiveFlg
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }

        public List<sp_VendContact_DM> ListContacts()
        {
            return ListContacts(null);
        }
        #endregion

        #region Insert Statements
        public Guid InsertContactContext(sp_VendContact_DM InputContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewContact = new tblContact
                {
                    ContactFirstName = InputContact.ContactFirstName,
                    ContactMiddleName = InputContact.ContactMiddleName,
                    ContactLastName = InputContact.ContactLastName,
                    ActiveFlg = InputContact.ActiveFlg
                };
                context.tblContacts.Add(NewContact);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewContact.ContactID;
            }
        }
        #endregion

        #region Update Statements
        public void UpdateContactContext(sp_VendContact_DM InputContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingContact = context.tblContacts.Find(InputContact.ContactID);

                if (InputContact != null)
                {
                    existingContact.ContactFirstName = InputContact.ContactFirstName;
                    existingContact.ContactMiddleName = InputContact.ContactMiddleName;
                    existingContact.ContactLastName = InputContact.ContactLastName;
                    existingContact.ActiveFlg = InputContact.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteAddressContext(sp_VendContact_DM InputContact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendContactToRemove = (from n in context.tblVendContacts where n.ContactID == InputContact.ContactID select n).FirstOrDefault();
                context.tblVendContacts.Remove(VendContactToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}