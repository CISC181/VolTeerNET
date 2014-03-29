using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Availability_DAL
    {

        public List<sp_Availablity_DM> ListVolunteerAvailability(Guid? VolID)
        {
            List<sp_Availablity_DM> list = new List<sp_Availablity_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Availability_Select(VolID)
                            select new sp_Availablity_DM
                            {
                                VolID = result.VolID,
                                AddrID = result.AddrID,
                                AvailID = result.AvailID,
                                AvailStart = result.AvailStart,
                                AvailEnd = result.AvailEnd,
                                Annotations = result.Annotations,
                                Description = result.Description,
                                RecurrenceParentID = result.RecurrenceParentID,
                                RecurrenceRule = result.RecurrenceRule,
                                Reminder = result.Reminder,
                                Subject = result.Subject
                            }).ToList();

                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }
        #region Insert Statements
        public void InsertVolunteerAvailability(sp_Availablity_DM _cVolAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolAvail = new tblAvailability 
                {
                    VolID = _cVolAvail.VolID,
                    AddrID = _cVolAvail.AddrID,
                    AvailStart = _cVolAvail.AvailStart,
                    AvailEnd = _cVolAvail.AvailEnd,
                    Annotations = _cVolAvail.Annotations,
                    Description = _cVolAvail.Description,
                    RecurrenceParentID = _cVolAvail.RecurrenceParentID,
                    RecurrenceRule = _cVolAvail.RecurrenceRule,
                    Reminder = _cVolAvail.Reminder,
                    Subject = _cVolAvail.Subject

                };
                context.tblAvailabilities.Add(cVolAvail);
                context.SaveChanges();
            }
        }
        #endregion
        #region Update Statements
        public void UpdateVolunteerAvailability(sp_Availablity_DM _cVolAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolAvail = new tblAvailability
                {
                    VolID = _cVolAvail.VolID,
                    AddrID = _cVolAvail.AddrID,
                    AvailID = _cVolAvail.AvailID,
                    AvailStart = _cVolAvail.AvailStart,
                    AvailEnd = _cVolAvail.AvailEnd,
                    Annotations = _cVolAvail.Annotations,
                    Description = _cVolAvail.Description,
                    RecurrenceParentID = _cVolAvail.RecurrenceParentID,
                    RecurrenceRule = _cVolAvail.RecurrenceRule,
                    Reminder = _cVolAvail.Reminder,
                    Subject = _cVolAvail.Subject
                };
                context.SaveChanges();
            }
        }
        #endregion


        #region Delete Statements
        public void DeleteVolunteerAvailability(sp_Availablity_DM _cVolAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolAvail = new tblAvailability
                {
                    VolID = _cVolAvail.VolID,
                    AddrID = _cVolAvail.AddrID,
                    AvailID = _cVolAvail.AvailID
                };
                context.tblAvailabilities.Remove(cVolAvail);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
