﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{

    public  class sp_Availablity_DM
    {
        public System.Guid VolID { get; set; }
        public int AddrID { get; set; }
        public int AvailID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime AvailStart { get; set; }
        public System.DateTime AvailEnd { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceParentID { get; set; }
        public string Reminder { get; set; }
        public string Annotations { get; set; }

        public virtual ICollection<sp_Availablity_DM> tblAvailability1 { get; set; }
        public virtual sp_Availablity_DM tblAvailability2 { get; set; }
        public virtual sp_Vol_Addr_DM tblVolAddress { get; set; }
        public virtual sp_Volunteer_DM tblVolunteer { get; set; }


        //public sp_Availablity_DM(string subject, DateTime start, DateTime end,
        //       string recurrenceRule, string recurrenceParentID, string reminder, int? userID) : this()
        //  {
        //      Subject = subject;
        //      AvailStart = start;
        //      AvailEnd = end;
        //      RecurrenceRule = recurrenceRule;
        //      RecurrenceParentID = recurrenceParentID;
        //      Reminder = reminder;

        //  }

        public sp_Availablity_DM()
        {
            // TODO: Complete member initialization
        }
 
    }
}



