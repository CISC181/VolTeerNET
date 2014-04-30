using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_VendAddress_DM
    {
        public sp_VendAddress_DM()
        {
            this.sp_Projects_DMs = new HashSet<sp_Project_DM>();
            this.sp_VendorAddrs_DMs = new HashSet<sp_VendorAddr_DM>();
        }
    
        public int AddrID { get; set; }
        public string AddrLine1 { get; set; }
        public string AddrLine2 { get; set; }
        public string AddrLine3 { get; set; }
        public string City { get; set; }
        public string St { get; set; }
        public Nullable<int> Zip { get; set; }
        public Nullable<int> Zip4 { get; set; }
        public bool ActiveFlg { get; set; }
        public string GeoCodeGetSet { get; set; }

        public virtual ICollection<sp_Project_DM> sp_Projects_DMs { get; set; }
        public virtual ICollection<sp_VendorAddr_DM> sp_VendorAddrs_DMs { get; set; }
    }
}

