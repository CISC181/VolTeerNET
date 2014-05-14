using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_VendorAddr_DM
    {
        public sp_VendorAddr_DM()
        {

        }

        public Guid VendorID { get; set; }
        public int AddrID { get; set; }
        public bool? HQ { get; set; }
     
    }
}

