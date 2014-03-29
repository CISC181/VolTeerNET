using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public class sp_VendContact_DM
    {
        public sp_VendContact_DM()
        {
            this.sp_Project_DMs = new HashSet<sp_Project_DM>();
            this.sp_VendorContacts_DMs = new HashSet<sp_VendorContacts_DM>();
        }

        public System.Guid ContactID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
        public bool ActiveFlg { get; set; }

        public virtual ICollection<sp_Project_DM> sp_Project_DMs { get; set; }
        public virtual ICollection<sp_VendorContacts_DM> sp_VendorContacts_DMs { get; set; }
    }
}