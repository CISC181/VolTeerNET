using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_GroupAddr_CON
    {
        List<sp_GroupAddr_DM> ListAddresses(sp_GroupAddr_DM cGroupAddr);
        sp_GroupAddr_DM ListAddress(sp_GroupAddr_DM cGroupAddr);
        List<sp_GroupAddr_DM> ListAddresses(int? GroupID, int? Address);
        sp_GroupAddr_DM ListPrimaryAddress(sp_GroupAddr_DM cGroupAddr);
        void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr);
        void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr);
        void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_GroupAddr_DM _cGroupAddr);
    }
}
