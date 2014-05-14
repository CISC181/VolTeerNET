using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;


namespace UT.Vol.BLL.HelperMethods
{
    public class hVolunteer
    {
        public sp_Volunteer_DM hCreateVolunteer(string strFirstName, string strMiddleName, string strLastName)
        {
            sp_Volunteer_DM VOL = new sp_Volunteer_DM();
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();

            VOL.VolID = Guid.NewGuid();
            VOL.ActiveFlg = true;
            VOL.VolFirstName = strFirstName;
            VOL.VolMiddleName = strMiddleName;
            VOL.VolLastName = strLastName;

            VOL = VOlBll.InsertVolunteerContext(ref VOL);

            return VOL;

        }

        public List<sp_Volunteer_DM> hSelectVolunteer()
        {
            List<sp_Volunteer_DM> VOLList = null;
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();
            VOLList = VOlBll.ListVolunteers();
            return VOLList;
        }

        public sp_Volunteer_DM hSelectVolunteer(Guid VolID)
        {
            sp_Volunteer_DM VOL = new sp_Volunteer_DM();
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();
            VOL = VOlBll.ListVolunteers(VolID);
            return VOL;
        }

        public void hUpdateVolunteer(sp_Volunteer_DM VOL, string strFirstName, string strMiddleName, string strLastName)
        {
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();

            VOL.VolFirstName = strFirstName;
            VOL.VolMiddleName = strMiddleName;
            VOL.VolLastName = strLastName;

            VOlBll.UpdateVolunteerContext(VOL);
        }

        public void hDeleteVolunteer(sp_Volunteer_DM VOL)
        {
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();

            VOlBll.DeleteVolunteerContext(VOL);
        }

    }

}
