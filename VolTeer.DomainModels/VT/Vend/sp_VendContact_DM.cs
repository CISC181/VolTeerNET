using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public class sp_VendContact_DM
    {
        public sp_VendContact_DM()
        {

        }

        public Guid VendorID { get; set; }
        public Guid ContactID { get; set; }
        public bool? PrimaryContact { get; set; }
    }
}