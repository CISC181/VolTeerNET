using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_ProjectEvent_DM
    {
        public sp_ProjectEvent_DM()
        {

        }

        public Guid EventID { get; set; }
        public Guid ProjectID { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? AddrID { get; set; }
    }
}
