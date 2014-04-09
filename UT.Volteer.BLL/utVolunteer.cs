using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;

namespace UT.Volteer.BLL
{
    [TestClass]
    public class utVolunteer
    {
        [TestMethod]
        public void CreateVolunteer()
        {
            sp_Volunteer_DM VOL = new sp_Volunteer_DM();
            sp_Volunteer_BLL VOlBll = new sp_Volunteer_BLL();

            VOL.VolFirstName = "FNTest";
            VOL.VolMiddleName = "MNTest";
            VOL.VolLastName = "LNTest";

            VOlBll.InsertVolunteerContext(VOL);


        }
    }
}
