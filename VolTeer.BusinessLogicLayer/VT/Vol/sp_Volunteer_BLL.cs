using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_Volunteer_BLL
    {
        sp_Volunteer_DAL DAL = new sp_Volunteer_DAL();
        
        public List<sp_Volunteer_DM> ListVolunteers()
        {
            return DAL.ListVolunteers();
        }

        public sp_Volunteer_DM ListVolunteers(Guid? Volunteer)
        {
            return DAL.ListVolunteers(Volunteer).Single();
        }

        public void InsertVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            DAL.InsertVolunteerContext(_cVolunteer);
        }

        public void UpdateSampleAddressContext(sp_Volunteer_DM _cVolunteer)
        {
            DAL.UpdateSampleAddressContext(_cVolunteer);
        }

        public void DeleteVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            DAL.DeleteVolunteerContext(_cVolunteer);
        }

    }
}
