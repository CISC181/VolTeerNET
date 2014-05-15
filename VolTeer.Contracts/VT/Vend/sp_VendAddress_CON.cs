using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_VendAddress_CON
    {
        List<sp_VendAddress_DM> ListAddresses(int AddrID);
        List<sp_VendAddress_DM> ListAddresses();
        int InsertAddressContext(sp_VendAddress_DM InputAddress);
        void UpdateAddressContext(sp_VendAddress_DM InputAddress);
        void DeleteAddressContext(sp_VendAddress_DM InputAddress);
    }
}
