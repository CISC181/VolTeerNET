using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_VendorProjContact_DM
    {
        public sp_VendorProjContact_DM()
        {

        }

        public Guid VendorID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid ContactID { get; set; }
        public bool? PrimaryContact { get; set; }

    }
}

