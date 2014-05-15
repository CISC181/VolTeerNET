using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_VendContact_CON
    {
        List<sp_VendContact_DM> ListVendContacts();
        List<sp_VendContact_DM> ListVendContacts(Guid? vendorid, Guid? contactid);
        sp_VendContact_DM ListVendContact(Guid vendorid, Guid contactid);

        void InsertVendContactContext(sp_VendContact_DM vendcontact);
        void UpdateVendContactContext(sp_VendContact_DM vendcontact);
        void DeleteVendContactContext(sp_VendContact_DM vendcontact);
    }
}
