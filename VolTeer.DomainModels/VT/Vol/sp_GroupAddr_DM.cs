using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    public class sp_GroupAddr_DM
    {
        public int GroupID { get; set; }
        public int AddrID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public string GroupName { get; set; }
        public string AddrLine1 { get; set; }
        public string AddrLine2 { get; set; }
        public string AddrLine3 { get; set; }
        public string City { get; set; }
        public string St { get; set; }
        public Nullable<int> Zip { get; set; }
        public Nullable<int> Zip4 { get; set; }
        public string GeoCodeGetSet { get; set; }
        public bool PrimaryAddr { get; set; }
    }
}
