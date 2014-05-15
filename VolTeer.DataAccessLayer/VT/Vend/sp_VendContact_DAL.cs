using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_VendContact_DAL : sp_VendContact_CON
    {
        #region Select Statements
        public List<sp_VendContact_DM> ListVendContacts()
        {
            List<sp_VendContact_DM> list = new List<sp_VendContact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vend_Contact_Select(null, null)
                            select new sp_VendContact_DM
                            {
                                VendorID = result.VendorID,
                                ContactID = result.ContactID,
                                PrimaryContact = result.PrimaryContact
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }

        public List<sp_VendContact_DM> ListVendContacts(Guid? vendorid, Guid? contactid)
        {
            List<sp_VendContact_DM> list = new List<sp_VendContact_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vend_Contact_Select(vendorid, contactid)
                            select new sp_VendContact_DM
                            {
                                VendorID = result.VendorID,
                                ContactID = result.ContactID,
                                PrimaryContact = result.PrimaryContact
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }

        public sp_VendContact_DM ListVendContact(Guid vendorid, Guid contactid)
        {
            List<sp_VendContact_DM> list = ListVendContacts(vendorid, contactid);
            return list.FirstOrDefault();
        }
        #endregion

        #region Insert Statement
        public void InsertVendContactContext(sp_VendContact_DM vendcontact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewVendContact = new tblVendContact
                {
                    VendorID = vendcontact.VendorID,
                    ContactID = vendcontact.ContactID,
                    PrimaryContact = vendcontact.PrimaryContact
                };
                context.tblVendContacts.Add(NewVendContact);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statement
        public void UpdateVendContactContext(sp_VendContact_DM vendcontact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ExistingVendContact = context.tblVendContacts.Find(vendcontact.VendorID, vendcontact.ContactID);
                if (ExistingVendContact != null)
                {
                    ExistingVendContact.PrimaryContact = vendcontact.PrimaryContact;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statement
        public void DeleteVendContactContext(sp_VendContact_DM vendcontact)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendContacttoRemove = (from n in context.tblVendContacts where n.ContactID == vendcontact.ContactID & n.VendorID == vendcontact.VendorID select n).FirstOrDefault();
                context.tblVendContacts.Remove(VendContacttoRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}