using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;

namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_Availablity_BLL
    {

        sp_Availability_DAL DAL = new sp_Availability_DAL();

        public List<sp_Availablity_DM> ListVolunteerAvailability(Guid? VolID)
        {
            return DAL.ListVolunteerAvailability(VolID);
        }
        
        public void InsertVolunteerContext(sp_Availablity_DM _cVolAvail)
        {
            DAL.InsertVolunteerAvailability(_cVolAvail);
        }

        public void UpdateSampleAddressContext(sp_Availablity_DM _cVolAvail)
        {
            DAL.UpdateVolunteerAvailability(_cVolAvail);
        }

        public void DeleteVolunteerContext(sp_Availablity_DM _cVolAvail)
        {
            DAL.DeleteVolunteerAvailability(_cVolAvail);
        }

    }

}
