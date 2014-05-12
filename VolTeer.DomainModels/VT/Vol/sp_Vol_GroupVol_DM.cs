using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{
    public class sp_Vol_GroupVol_DM
    {
        public string GroupName { get; set; }
        public Nullable<int> ParticipationLevelID { get; set; }
        public Nullable<bool> GroupActive { get; set; }
        public int GroupID { get; set; }
        public System.Guid VolID { get; set; }
        public Nullable<bool> PrimaryVolID { get; set; }
        public Nullable<bool> Admin { get; set; }
        public string VolFirstName { get; set; }
        public string VolMiddleName { get; set; }
        public string VolLastName { get; set; }
        public Nullable<bool> VolActive { get; set; }
    }
}
