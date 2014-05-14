using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Vol.BLL.HelperMethods;
using System.Data;
using System.IO;
using UT.Helper;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utVolunteer
    {
        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx"
        };

        /*[ClassInitialize]
        public static void InsertVolunteerData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);
        }*/

        [TestMethod]
        public void TestVolunteer()
        {

            sp_Volunteer_DM insertVol = new sp_Volunteer_DM();
            sp_Volunteer_DM selectVol = new sp_Volunteer_DM();
            hVolunteer hVol = new hVolunteer();
                
            insertVol = hVol.hCreateVolunteer("testFirst1","testMiddle1","testLast1");
            Assert.AreEqual("testFirst1", insertVol.VolFirstName);
            Assert.AreEqual("testMiddle1", insertVol.VolMiddleName);
            Assert.AreEqual("testLast1", insertVol.VolLastName);

            selectVol = hVol.hSelectVolunteer(insertVol.VolID);
            Assert.AreEqual(insertVol.VolID, selectVol.VolID);
            Assert.AreEqual(insertVol.ActiveFlg,selectVol.ActiveFlg);
            Assert.AreEqual(insertVol.VolFirstName, selectVol.VolFirstName);
            Assert.AreEqual(insertVol.VolMiddleName, selectVol.VolMiddleName);
            Assert.AreEqual(insertVol.VolLastName, selectVol.VolLastName);

            hVol.hUpdateVolunteer(insertVol, "replaceFirst1", "replaceMiddle1", "replacdLast1");
            selectVol = hVol.hSelectVolunteer(insertVol.VolID);
            Assert.AreEqual(insertVol.VolID,selectVol.VolID);
            Assert.AreEqual(insertVol.ActiveFlg,selectVol.ActiveFlg);
            Assert.AreEqual("replaceFirst1",selectVol.VolFirstName);
            Assert.AreEqual("replaceMiddle1",selectVol.VolMiddleName);
            Assert.AreEqual("replaceLast1",selectVol.VolLastName);

            hVol.hUpdateVolunteer(insertVol, insertVol.VolFirstName, insertVol.VolMiddleName, insertVol.VolLastName);
            selectVol = hVol.hSelectVolunteer(insertVol.VolID);
            Assert.AreEqual(insertVol.VolID, selectVol.VolID);
            Assert.AreEqual(insertVol.ActiveFlg, selectVol.ActiveFlg);
            Assert.AreEqual(insertVol.VolFirstName, selectVol.VolFirstName);
            Assert.AreEqual(insertVol.VolMiddleName, selectVol.VolMiddleName);
            Assert.AreEqual(insertVol.VolLastName, selectVol.VolLastName);

            hVol.hDeleteVolunteer(insertVol);
            selectVol = hVol.hSelectVolunteer(insertVol.VolID);
            Assert.AreEqual(insertVol.VolID, selectVol.VolID);
            Assert.AreEqual(false,selectVol.ActiveFlg);
            Assert.AreEqual(insertVol.VolFirstName, selectVol.VolFirstName);
            Assert.AreEqual(insertVol.VolMiddleName, selectVol.VolMiddleName);
            Assert.AreEqual(insertVol.VolLastName, selectVol.VolLastName);

        }

        /*[ClassCleanup]
        public static void RemoveVolunteerData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }*/

    }
}
