using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_ProjectEvent_DAL : sp_ProjectEvent_CON
    {

        #region Select Statements

        public List<sp_ProjectEvent_DM> ListEvents(Guid? EventID)
        {
            List<sp_ProjectEvent_DM> list = new List<sp_ProjectEvent_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_ProjectEvent_Select(EventID)
                            select new sp_ProjectEvent_DM
                            {
                                EventID = result.EventID,
                                ProjectID = result.ProjectID,
                                StartDateTime = result.StartDateTime,
                                EndDateTime = result.EndDateTime,
                                AddrID = result.AddrID
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
            return list;
        }

        public List<sp_ProjectEvent_DM> ListEvents()
        {
            return ListEvents(null);
        }
        #endregion

        public sp_ProjectEvent_DM ListEvent(Guid EventID)
        {
            return ListEvents(EventID).FirstOrDefault();
        }

        #region Insert Statements


        public Guid InsertProjectEventContext(sp_ProjectEvent_DM InputProjectEvent)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewProjectEvent = new tblProjectEvent
                {
                    StartDateTime = InputProjectEvent.StartDateTime,
                    EndDateTime = InputProjectEvent.EndDateTime,
                    AddrID = InputProjectEvent.AddrID
                };
                context.tblProjectEvents.Add(NewProjectEvent);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewProjectEvent.EventID;
            }
        }

        #endregion

        #region Update Statements
        public void UpdateProjectEventContext(sp_ProjectEvent_DM InputProjectEvent)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingProjectEvent = context.tblProjectEvents.Find(InputProjectEvent.EventID);

                if (InputProjectEvent != null)
                {
                    existingProjectEvent.StartDateTime = InputProjectEvent.StartDateTime;
                    existingProjectEvent.EndDateTime = InputProjectEvent.EndDateTime;
                    existingProjectEvent.AddrID = InputProjectEvent.AddrID;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteProjectEventContext(sp_ProjectEvent_DM InputProjectEvent)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ProjectEventToRemove = (from n in context.tblProjectEvents where n.EventID == InputProjectEvent.EventID select n).FirstOrDefault();
                context.tblProjectEvents.Remove(ProjectEventToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}