using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_VendAddress_BLL
    {
        sp_VendAddress_DAL DAL = new sp_VendAddress_DAL();

        public List<sp_VendAddress_DM> ListAddresses()
        {
            return DAL.ListAddresses();
        }

        public sp_VendAddress_DM ListAddresses(int AddrID)
        {
            return DAL.ListAddresses(AddrID).Single();
        }

        public int InsertAddressContext(sp_VendAddress_DM InputAddress)
        {
            return DAL.InsertAddressContext(InputAddress);
        }

        public void UpdateAddressContext(sp_VendAddress_DM InputAddress)
        {
            DAL.UpdateAddressContext(InputAddress);
        }

        public void DeleteAddressContext(sp_VendAddress_DM InputAddress)
        {
            DAL.DeleteAddressContext(InputAddress);
        }
    }
}
