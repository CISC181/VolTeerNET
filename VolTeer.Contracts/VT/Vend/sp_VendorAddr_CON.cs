using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_VendorAddr_CON
    {
        sp_VendorAddr_DM ListAddresses(Guid VendorID);
        List<sp_VendorAddr_DM> ListAddresses();
        int InsertAddressContext(sp_VendorAddr_DM InputAddress);
        void UpdateAddressContext(sp_VendorAddr_DM InputAddress);
        void DeleteAddressContext(sp_VendorAddr_DM InputAddress);
    }
}
