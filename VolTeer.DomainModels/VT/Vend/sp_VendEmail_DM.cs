using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_VendEmail_DM
    {
        public sp_VendEmail_DM()
        {
            
        }
    
        public int EmailID { get; set; }
        public string EmailAddr { get; set; }
        public bool ActiveFlg { get; set; }

    }
}
