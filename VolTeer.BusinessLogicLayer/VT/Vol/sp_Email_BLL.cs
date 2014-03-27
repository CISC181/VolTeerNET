using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
        public class sp_Email_BLL
        {
            sp_Email_DAL DAL = new sp_Email_DAL();

            public List<sp_Email_DM> ListVolunteers()
            {
                return DAL.ListVolunteers();
            }

            public sp_Email_DM ListVolunteers(Guid? Volunteer)
            {
                return DAL.ListVolunteers(Volunteer).Single();
            }

            public void InsertVolunteerContext(sp_Email_DM _cVolunteer)
            {
                DAL.InsertVolunteerContext(_cVolunteer);
            }

            public void UpdateSampleAddressContext(sp_Email_DM _cVolunteer)
            {
                DAL.UpdateSampleAddressContext(_cVolunteer);
            }

            public void DeleteVolunteerContext(sp_Email_DM _cVolunteer)
            {
                DAL.DeleteVolunteerContext(_cVolunteer);
            }

        }
}
