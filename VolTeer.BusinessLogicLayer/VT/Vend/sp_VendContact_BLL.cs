using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_VendContact_BLL : sp_VendContact_CON
    {
        sp_VendContact_DAL DAL = new sp_VendContact_DAL();

        public List<sp_VendContact_DM> ListVendContacts()
        {
            return DAL.ListVendContacts();
        }

        public List<sp_VendContact_DM> ListVendContacts(Guid? vendorid, Guid? contactid)
        {
            return DAL.ListVendContacts(vendorid, contactid);
        }

        public sp_VendContact_DM ListVendContact(Guid vendorid, Guid contactid)
        {
            return DAL.ListVendContact(vendorid, contactid);
        }

        public void InsertVendContactContext(sp_VendContact_DM vendcontact)
        {
            DAL.InsertVendContactContext(vendcontact);
        }

        public void UpdateVendContactContext(sp_VendContact_DM vendcontact)
        {
            DAL.UpdateVendContactContext(vendcontact);
        }

        public void DeleteVendContactContext(sp_VendContact_DM vendcontact)
        {
            DAL.DeleteVendContactContext(vendcontact);
        }
    }
}
