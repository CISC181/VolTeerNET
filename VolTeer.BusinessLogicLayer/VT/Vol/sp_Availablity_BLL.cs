using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using System.Configuration;
using Telerik.Web.UI;
using System.Data.Common;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_Availablity_BLL : DbSchedulerProviderBase
    {

        public sp_Vol_Addr_DM cVolAddr;

        sp_Availability_DAL DAL = new sp_Availability_DAL();


        public override IDictionary<ResourceType, IEnumerable<Resource>> GetResources(ISchedulerInfo schedulerInfo)
        {
            Dictionary<ResourceType, IEnumerable<Resource>> resCollection = new Dictionary<ResourceType, IEnumerable<Resource>>();

            return resCollection;
        }

        public override IEnumerable<Appointment> GetAppointments(ISchedulerInfo shedulerInfo)
        {
            string strVolID = "6CD40064-CF05-4B55-93C0-6E4D7F9CCE34";
            Guid VolID = new Guid(strVolID);
            int AddrID = 1;

            return DAL.ListVolunteerAvailability(VolID, AddrID);
        }

        public virtual void Update(RadScheduler owner, Appointment appointmentToUpdate)
        {
            if (!PersistChanges)
            {
                return;
            }

        }


        public override void Update(ISchedulerInfo shedulerInfo, Appointment appointmentToUpdate)
        {
            if (!PersistChanges)
            {
                return;
            }

            sp_Availablity_DM cAvail = new sp_Availablity_DM();

            cAvail.VolID = new Guid(appointmentToUpdate.Attributes["VolID"]);
            cAvail.AddrID = Convert.ToInt32(appointmentToUpdate.Attributes["AddrID"]);
            cAvail.AvailID = Convert.ToInt32(appointmentToUpdate.Attributes["AvailID"]);

            DAL.UpdateVolunteerAvailability(shedulerInfo, appointmentToUpdate, cAvail);
        }


        public override void Insert(ISchedulerInfo shedulerInfo, Appointment appointmentToInsert)
        {
            sp_Availablity_DM cAvail = new sp_Availablity_DM();

            cAvail.VolID = new Guid(appointmentToInsert.Attributes["VolID"]);
            cAvail.AddrID = Convert.ToInt32(appointmentToInsert.Attributes["AddrID"]);

            DAL.InsertVolunteerAvailability(shedulerInfo, appointmentToInsert, cAvail);
        }

        public override void Delete(ISchedulerInfo shedulerInfo, Appointment appointmentToDelete)
        {
            if (!PersistChanges)
            {
                return;
            }

            sp_Availablity_DM cAvail = new sp_Availablity_DM();
            cAvail.VolID = new Guid(appointmentToDelete.Attributes["VolID"]);
            cAvail.AddrID = Convert.ToInt32(appointmentToDelete.Attributes["AddrID"]);
            cAvail.AvailID = Convert.ToInt32(appointmentToDelete.Attributes["AvailID"]);

            DAL.DeleteVolunteerAvailability(shedulerInfo, appointmentToDelete, cAvail);

        }
    }

}
