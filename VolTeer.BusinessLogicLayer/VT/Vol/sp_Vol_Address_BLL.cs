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

        public List<sp_Vol_Address_DM> ListAddresses()
        {
            return DAL.ListAddresses();
        }

        public sp_Vol_Address_DM ListAddresses(int? Address)
        {
            return DAL.ListAddresses(Address).Single();
        }

        public void InsertAddressContext(sp_Vol_Address_DM _cAddress)
        {
            DAL.InsertAddressContext(_cAddress);
        }

        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress)
        {
            DAL.UpdateAddressContext(_cAddress);
        }

        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress)
        {
            DAL.DeleteAddressContext(_cAddress);
        }

    }
}
