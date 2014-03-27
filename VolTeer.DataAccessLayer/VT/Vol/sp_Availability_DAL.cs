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
                                AvailDateID = result.AvailDateID,
                                AvailStartDate = result.AvailStartDate,
                                AvailEndDate = result.AvailEndDate,
                                DayID = result.DayID,
                                StartTime = result.StartTime,
                                EndTime = result.EndTime
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
                var cVolAvail = new tblAvailablity
                {
                    VolID = _cVolAvail.VolID,
                    AddrID = _cVolAvail.AddrID,
                    AvailDateID = _cVolAvail.AvailDateID,
                    AvailStartDate = _cVolAvail.AvailStartDate,
                    AvailEndDate = _cVolAvail.AvailEndDate,
                    DayID = _cVolAvail.DayID,
                    StartTime = _cVolAvail.StartTime,
                    EndTime = _cVolAvail.EndTime

                };
                context.tblAvailablities.Add(cVolAvail);
                context.SaveChanges();
            }
        }
        #endregion
        #region Update Statements
        public void UpdateVolunteerAvailability(sp_Availablity_DM _cVolAvail)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolAvail = new tblAvailablity
                {
                    VolID = _cVolAvail.VolID,
                    AddrID = _cVolAvail.AddrID,
                    AvailDateID = _cVolAvail.AvailDateID,
                    AvailStartDate = _cVolAvail.AvailStartDate,
                    AvailEndDate = _cVolAvail.AvailEndDate,
                    DayID = _cVolAvail.DayID,
                    StartTime = _cVolAvail.StartTime,
                    EndTime = _cVolAvail.EndTime
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
                var cVolAvail = new tblAvailablity
                {
                    VolID = _cVolAvail.VolID,
                    AddrID = _cVolAvail.AddrID,
                    AvailDateID = _cVolAvail.AvailDateID
                };
                context.tblAvailablities.Remove(cVolAvail);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
