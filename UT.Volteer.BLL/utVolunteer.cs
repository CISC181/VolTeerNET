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

            VOL.VolFirstName = "Jim";
            VOL.VolMiddleName = "";
            VOL.VolLastName = "Morrison";

            VOL = VOlBll.InsertVolunteerContext(VOL);

            Console.WriteLine(VOL.VolID);
            System.Diagnostics.Debug.Write(VOL.VolID);
        }
    }
}
