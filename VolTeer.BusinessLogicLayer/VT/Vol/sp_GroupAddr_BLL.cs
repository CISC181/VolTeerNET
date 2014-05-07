using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_GroupAddr_BLL : sp_GroupAddr_CON
    {
        sp_GroupAddr_DAL DAL = new sp_GroupAddr_DAL();

        public List<sp_GroupAddr_DM> ListAddresses(sp_GroupAddr_DM cGroupAddr)
        {
            return DAL.ListAddresses(cGroupAddr);
        }

        public sp_GroupAddr_DM ListAddress(sp_GroupAddr_DM cGroupAddr)
        {
            return DAL.ListAddress(cGroupAddr);
        }

        public List<sp_GroupAddr_DM> ListAddresses(int? GroupID, int? Address)
        {
            return DAL.ListAddresses(GroupID, Address);
        }

        public sp_GroupAddr_DM ListPrimaryAddress(sp_GroupAddr_DM cGroupAddr)
        {
            return DAL.ListPrimaryAddress(cGroupAddr);
        }

        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr)
        {
            DAL.DeleteAddressContext(_cAddress, _cGroupAddr);
        }

        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr)
        {
            DAL.UpdateAddressContext(_cAddress, _cGroupAddr);
        }

        public void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_GroupAddr_DM _cGroupAddr)
        {
            DAL.InsertAddressContext(ref _cAddress, ref _cGroupAddr);
        }
    }
}
