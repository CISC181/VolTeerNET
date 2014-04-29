using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_Vol_Address_CON
    {
        List<sp_Vol_Address_DM> ListAddresses(sp_Vol_Address_DM _cAddress);
        sp_Vol_Address_DM ListAddress(sp_Vol_Address_DM _cAddress);
        void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_Vol_Addr_DM _cVolAddr);
        void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr);
        void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr);
    }
}
