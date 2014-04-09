using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_Vol_Address_BLL
    {
        sp_Vol_Address_DAL DAL = new sp_Vol_Address_DAL();

        public List<sp_Vol_Address_DM> ListAddresses(sp_Vol_Address_DM cVolAddr)
        {
            return DAL.ListAddresses(cVolAddr);
        }

        //public sp_Vol_Address_DM ListAddresses(Guid? VolID, int? Address)
        //{
        //    return DAL.ListAddresses(VolID, Address).Single();
        //}

        /// <summary>
        /// ListPrimaryAddress - List the Primary address
        /// </summary>
        /// <param name="cVolAddr"></param>
        /// <returns></returns>
        public sp_Vol_Address_DM ListPrimaryAddress(sp_Vol_Address_DM cVolAddr)
        {
            return DAL.ListPrimaryAddress(cVolAddr);
        }

        public void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_Vol_Addr_DM _cVolAddr)
        {
            DAL.InsertAddressContext(ref _cAddress, ref _cVolAddr);
        }

        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            DAL.UpdateAddressContext(_cAddress, _cVolAddr);
        }

        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            DAL.DeleteAddressContext(_cAddress, _cVolAddr);
        }

    }
}
