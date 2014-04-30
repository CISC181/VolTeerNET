using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public class sp_Vendor_DM

    {
        public System.Guid VendorID { get; set; }
        public string VendorName { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
    }
}
