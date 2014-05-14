using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_VendorAddr_BLL
    {
        sp_VendorAddr_DAL DAL = new sp_VendorAddr_DAL();

        public List<sp_VendorAddr_DM> ListAddresses()
        {
            return DAL.ListAddresses();
        }

        public sp_VendorAddr_DM ListAddresses(Guid VendorID)
        {
            return DAL.ListAddresses(VendorID).Single();
        }

        public int InsertAddressContext(sp_VendorAddr_DM InputAddress)
        {
            return DAL.InsertAddressContext(InputAddress);
        }

        public void UpdateAddressContext(sp_VendorAddr_DM InputAddress)
        {
            DAL.UpdateAddressContext(InputAddress);
        }

        public void DeleteAddressContext(sp_VendorAddr_DM InputAddress)
        {
            DAL.DeleteAddressContext(InputAddress);
        }
    }
}
