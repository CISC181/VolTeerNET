using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_Contact_DM
    {
        public sp_Contact_DM()
        {

        }

        public Guid ContactID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
        public bool ActiveFlg { get; set; }
    }
}
