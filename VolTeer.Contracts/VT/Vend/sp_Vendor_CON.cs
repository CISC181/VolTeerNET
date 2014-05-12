using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;


namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_Vendor_CON
    {
        List<sp_Vendor_DM> ListVendors();
        sp_Vendor_DM ListVendors(Guid? VendorID);
        sp_Vendor_DM InsertVendorContext(ref sp_Vendor_DM _cVendor);
        void UpdateVolunteerContext(sp_Vendor_DM _cVendor);
        void DeleteVendorContext(sp_Vendor_DM _cVendor);
    }
}
