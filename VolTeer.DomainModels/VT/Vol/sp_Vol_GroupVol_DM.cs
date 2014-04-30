using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    class sp_Vol_GroupVol_DM
    {
        public int GroupID { get; set; }
        public Guid VolID { get; set; }
        public Nullable<bool> PrimaryVolID { get; set; }
        public Nullable<bool> Admin { get; set; }
    }
}
