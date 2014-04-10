using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Volteer.BLL.HelperMethods;

namespace UT.Volteer.BLL
{
    [TestClass]
    public class utVolunteer
    {
        [TestMethod]
        public void CreateVolunteer()
        {
            sp_Volunteer_DM insertVol = new sp_Volunteer_DM();
            sp_Volunteer_DM selectVol = new sp_Volunteer_DM();

            hVolunteer hVol = new hVolunteer();
            insertVol = hVol.hCreateVolunteer("New", "Test", "User");


            selectVol = hVol.hSelectVolunteer(insertVol.VolID);

            Assert.AreEqual(insertVol.VolFirstName, selectVol.VolFirstName);
            Assert.AreEqual(insertVol.VolMiddleName, selectVol.VolMiddleName);
            Assert.AreEqual(insertVol.VolLastName, selectVol.VolMiddleName);

            
            Console.WriteLine(insertVol.VolID);
            System.Diagnostics.Debug.Write(insertVol.VolID);
        }
    }
}
