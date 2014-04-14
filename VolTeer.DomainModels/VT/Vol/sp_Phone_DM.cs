using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    using System;
    using System.Collections.Generic;

    public class sp_Phone_DM
    {
        public int PhoneID { get; set; }
        public System.Guid VolID { get; set; }
        public string PhoneNbr { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }

        
    }
}
