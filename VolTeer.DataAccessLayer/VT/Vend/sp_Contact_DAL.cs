using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_Contact_DAL : sp_Contact_CON
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

        public sp_Contact_DM ListContacts(Guid? contactid)
        {
            List<sp_Contact_DM> list = new List<sp_Contact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Contact_Select(contactid)
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
            return list.FirstOrDefault();
        }
        #endregion

        #region Insert Statement
        public void InsertContactContext(ref sp_Contact_DM contact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewContact = new tblContact
                {
                    ContactFirstName = contact.ContactFirstName,
                    ContactMiddleName = contact.ContactMiddleName,
                    ContactLastName = contact.ContactLastName,
                    ActiveFlg = contact.ActiveFlg

                };
                context.tblContacts.Add(NewContact);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statement
        public void UpdateContactContext(sp_Contact_DM contact)
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
        public void DeleteContactContext(Guid? ContactID)
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
