using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public class sp_Project_DM
    {
        public System.Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public Nullable<int> AddrID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
    }
}
