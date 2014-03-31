using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using Telerik.Web.UI;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Availability_DAL
    {

        public IEnumerable<Appointment> ListVolunteerAvailability(Guid? VolID, int AddrID)
        {
            List<Appointment> apts = new List<Appointment>();

            List<sp_Availablity_DM> listAvailability = new List<sp_Availablity_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    listAvailability = (from result in context.sp_Availability_Select(VolID, AddrID)
                                        select new sp_Availablity_DM
                     {
                         VolID = result.VolID,
                         AddrID = result.AddrID,
                         AvailID = result.AvailID,
                         AvailStart = result.AvailStart,
                         AvailEnd = result.AvailEnd,
                         Reminder = result.Reminder,
                         Annotations = result.Annotations,
                         Description = result.Description,
                         RecurrenceParentID = result.RecurrenceParentID,
                         Subject = result.Subject,
                         RecurrenceRule = result.RecurrenceRule

                         //Start = result.AvailStart,
                         //End = result.AvailEnd,
                         //Description = result.Description,
                         //RecurrenceParentID = result.RecurrenceParentID,
                         //RecurrenceRule = result.RecurrenceRule,
                         //Subject = result.Subject
                     }).ToList();

                    foreach (sp_Availablity_DM cAvailability in listAvailability)
                    {
                        Appointment apt = new Appointment();
                        apt.Start = cAvailability.AvailStart;
                        apt.End = cAvailability.AvailEnd;
                        apt.Description = cAvailability.Description;
                        apt.RecurrenceParentID = cAvailability.RecurrenceParentID;
                        apt.RecurrenceRule = cAvailability.RecurrenceRule;
                        apt.Subject = cAvailability.Subject;

                        apt.Attributes.Add("VolID", cAvailability.VolID.ToString());
                        apt.Attributes.Add("AddrID", cAvailability.AddrID.ToString());
                        apt.Attributes.Add("AvailID", cAvailability.AvailID.ToString());

                        apts.Add(apt);
                    }

                    return apts;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return apts;


        }
        #region Insert Statements
        public void InsertVolunteerAvailability(ISchedulerInfo shedulerInfo, Appointment appointmentToInsert, sp_Availablity_DM cAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                try
                {
                    var cVolAvail = new tblAvailability
                    {
                        VolID = cAvail.VolID,
                        AddrID = cAvail.AddrID,
                        AvailStart = appointmentToInsert.Start,
                        AvailEnd = appointmentToInsert.End,
                        Description = appointmentToInsert.Description,
                        RecurrenceParentID = (int?)(appointmentToInsert.RecurrenceParentID),
                        RecurrenceRule = appointmentToInsert.RecurrenceRule,
                        Subject = appointmentToInsert.Subject
                    };
                    context.tblAvailabilities.Add(cVolAvail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                }



            }
        }
        #endregion
        #region Update Statements
        public void UpdateVolunteerAvailability(ISchedulerInfo shedulerInfo, Appointment appointmentToUpdate, sp_Availablity_DM cAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolAvail = new tblAvailability
                {
                    VolID = cAvail.VolID,
                    AddrID = cAvail.AddrID,
                    AvailID = cAvail.AvailID,
                    AvailStart = appointmentToUpdate.Start,
                    AvailEnd = appointmentToUpdate.End,
                    Description = appointmentToUpdate.Description,
                    RecurrenceParentID = (int?)(appointmentToUpdate.RecurrenceParentID),
                    RecurrenceRule = appointmentToUpdate.RecurrenceRule,
                    Subject = appointmentToUpdate.Subject
                };
                context.SaveChanges();
            }
        }
        #endregion


        #region Delete Statements
        public void DeleteVolunteerAvailability(ISchedulerInfo shedulerInfo, Appointment appointmentToDelete, sp_Availablity_DM cAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolAvail = new tblAvailability
                {
                    VolID = cAvail.VolID,
                    AddrID = cAvail.AddrID,
                    AvailID = cAvail.AvailID
                };
                context.tblAvailabilities.Remove(cVolAvail);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
