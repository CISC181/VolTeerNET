using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    public class sp_Volunteer_DM
    {
        public System.Guid VolID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public string VolFirstName { get; set; }
        public string VolMiddleName { get; set; }
        public string VolLastName { get; set; }
    }
}
