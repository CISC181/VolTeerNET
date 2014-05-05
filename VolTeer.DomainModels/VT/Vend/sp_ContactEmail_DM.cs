using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_ContactEmail_DM
    {
        public sp_ContactEmail_DM()
        {
            
        }

        public Guid ContactID { get; set; }
        public int EmailID { get; set; }
        public bool PrimaryEmail { get; set; }
    }
}
