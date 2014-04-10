using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;


namespace UT.Volteer.BLL.HelperMethods
{
    public class hVolunteer
    {
        public sp_Volunteer_DM hCreateVolunteer(string strFirstName, string strMiddleName, string strLastName)
        {
            sp_Volunteer_DM VOL = new sp_Volunteer_DM();
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();

            VOL.VolFirstName = strFirstName;
            VOL.VolMiddleName = strMiddleName;
            VOL.VolLastName = strLastName;

            VOL = VOlBll.InsertVolunteerContext(VOL);

            //Console.WriteLine(VOL.VolID);
            //System.Diagnostics.Debug.Write(VOL.VolID);

            return VOL;

        }

        public sp_Volunteer_DM hSelectVolunteer(Guid VolID)
        {
            sp_Volunteer_DM VOL = new sp_Volunteer_DM();
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();
            VOL = VOlBll.ListVolunteers(VolID);
            return VOL;
        }
    }

}
