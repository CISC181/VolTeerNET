using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    public class sp_Vol_Addr_DM
    {
        public System.Guid VolID { get; set; }
        public int AddrID { get; set; }
        public bool PrimaryAddr { get; set; }
    }
}
