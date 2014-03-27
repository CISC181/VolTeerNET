using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{

    public partial class sp_Availablity_DM
    {
        public System.Guid VolID { get; set; }
        public int AddrID { get; set; }
        public int AvailDateID { get; set; }
        public System.DateTime AvailStartDate { get; set; }
        public Nullable<System.DateTime> AvailEndDate { get; set; }
        public Nullable<int> DayID { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }

        public virtual sp_Volunteer_DM tblVolAddress { get; set; }
        public virtual sp_Volunteer_DM tblVolunteer { get; set; }
    }
}



