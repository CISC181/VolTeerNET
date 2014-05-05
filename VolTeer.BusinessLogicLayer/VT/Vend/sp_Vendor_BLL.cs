using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_Vendor_BLL : sp_Vendor_CON
    {
        sp_Vendor_DAL dal = new sp_Vendor_DAL();
        public List<sp_Vendor_DM> ListVendors()
        {
            return dal.ListVendors();
        }

        public sp_Vendor_DM ListVendors(Guid? VendorID)
        {
            return dal.ListVendors(VendorID);
        }

        public sp_Vendor_DM InsertVendorContext(ref sp_Vendor_DM _cVendor)
        {
            return dal.InsertVendorContext(ref _cVendor);
        }

        public void UpdateVolunteerContext(sp_Vendor_DM _cVendor)
        {
            dal.UpdateVolunteerContext(_cVendor);
        }

        public void DeleteVendorContext(sp_Vendor_DM _cVendor)
        {
            dal.DeleteVendorContext(_cVendor);
        }
    }
}
