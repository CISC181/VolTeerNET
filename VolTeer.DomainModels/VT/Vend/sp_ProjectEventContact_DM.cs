using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public class sp_ProjectEventContact_DM
    {
        public System.Guid EventID { get; set; }
        public System.Guid ContactID { get; set; }
        public bool? PrimaryContact { get; set; }
    }
}
