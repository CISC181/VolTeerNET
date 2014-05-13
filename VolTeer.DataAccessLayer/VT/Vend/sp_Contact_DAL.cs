using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_Contact_DAL
    {
        #region Select Statements
        public List<sp_Contact_DM> ListContacts()
        {
            List<sp_Contact_DM> list = new List<sp_Contact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Contact_Select(null)
                            select new sp_Contact_DM
                            {
                                ContactID = result.ContactID,
                                ContactFirstName = result.ContactFirstName,
                                ContactMiddleName = result.ContactMiddleName,
                                ContactLastName = result.ContactLastName,
                                ActiveFlg = result.ActiveFlg

                            }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }        
        public List<sp_Contact_DM> ListContacts(Guid? ContactID)
        {
            List<sp_Contact_DM> list = new List<sp_Contact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Contact_Select(ContactID)
                            select new sp_Contact_DM
                            {
                                ContactID = result.ContactID,
                                ContactFirstName = result.ContactFirstName,
                                ContactMiddleName = result.ContactMiddleName,
                                ContactLastName = result.ContactLastName,
                                ActiveFlg = result.ActiveFlg

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

        #region Insert Statement
        public void insert(sp_Contact_DM Contact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewContact = new tblContact
                {
                    ContactFirstName = Contact.ContactFirstName,
                    ContactMiddleName = Contact.ContactMiddleName,
                    ContactLastName = Contact.ContactLastName,
                    ActiveFlg = Contact.ActiveFlg

                };
                context.tblContacts.Add(NewContact);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statement
        public void update(sp_Contact_DM contact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var c = context.tblContacts.Find(contact.ContactID);

                if (c != null)
                {
                    c.ContactFirstName = contact.ContactFirstName;
                    c.ContactMiddleName = contact.ContactMiddleName;
                    c.ContactLastName = contact.ContactLastName;
                    c.ActiveFlg = contact.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statement
        public void delete(Guid? ContactID)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var contact = context.tblContacts.Find(ContactID);

                if (contact != null)
                {
                    contact.ActiveFlg = false;
                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
