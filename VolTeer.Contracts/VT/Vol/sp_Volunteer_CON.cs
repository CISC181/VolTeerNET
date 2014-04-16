using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolTeer.DomainModels.VT.Vol;


namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_Volunteer_CON
    {
        List<sp_Volunteer_DM> ListVolunteers();
        sp_Volunteer_DM ListVolunteers(Guid? Volunteer);
        sp_Volunteer_DM InsertVolunteerContext(ref sp_Volunteer_DM _cVolunteer);
        void UpdateVolunteerContext(sp_Volunteer_DM _cVolunteer);
        void DeleteVolunteerContext(sp_Volunteer_DM _cVolunteer);
    }
}
