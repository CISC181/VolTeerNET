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

        static sp_Volunteer_DM createTestVol;

        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx"
        };

        private static bool VolEquals(sp_Volunteer_DM vol1, sp_Volunteer_DM vol2)
        {

            return ((vol1.VolID == vol2.VolID) &&
                (vol1.VolFirstName == vol2.VolFirstName) &&
                (vol1.VolMiddleName == vol2.VolMiddleName) &&
                (vol1.VolLastName == vol2.VolLastName) &&
                (vol1.ActiveFlg == vol2.ActiveFlg));

        }

        private static List<sp_Volunteer_DM> getVolDMs(DataTable dataTable)
        {

            List<sp_Volunteer_DM> volDMs = new List<sp_Volunteer_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                sp_Volunteer_DM returnVolunteer = new sp_Volunteer_DM();
                returnVolunteer.VolID = new Guid((string)dataTable.Rows[i]["VolID"]);
                returnVolunteer.VolFirstName = (String)dataTable.Rows[i]["VolFirstName"];
                returnVolunteer.VolMiddleName = (String)dataTable.Rows[i]["VolMiddleName"];
                returnVolunteer.VolLastName = (String)dataTable.Rows[i]["VolLastName"];
                returnVolunteer.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                volDMs.Add(returnVolunteer);
            }
            return volDMs;

        }

        [ClassInitialize]
        public static void InsertVolunteerData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);

            createTestVol = new sp_Volunteer_DM();
        }

        [TestMethod]
        public void TestVolunteerRead()
        {
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "Volunteer.xlsx"));
            var excelDMs = getVolDMs(dt);
            var numRows = cExcel.getNumRecordsFromDB("[Vol].[tblVolunteer]");

            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            List<sp_Volunteer_DM> allVols = vol_bll.ListVolunteers();

            Assert.AreEqual(numRows, allVols.Count);
            foreach (sp_Volunteer_DM testVol in excelDMs)
            {
                sp_Volunteer_DM selectedVol = vol_bll.ListVolunteers(testVol.VolID);
                Assert.IsTrue(VolEquals(testVol, selectedVol));
            }
        }

        [TestMethod]
        public void TestVolunteerCreate()
        {
            string volFirst = "TestFirst";
            string volMiddle = "TestMiddle";
            string volLast = "TestLast";
            bool ActiveFlg = true;
            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            sp_Volunteer_DM vol_dm = new sp_Volunteer_DM();
            vol_dm.VolFirstName = volFirst;
            vol_dm.VolMiddleName = volMiddle;
            vol_dm.VolLastName = volLast;
            vol_dm.ActiveFlg = ActiveFlg;
            System.Guid volID = vol_bll.InsertVolunteerContext(ref vol_dm).VolID;
            vol_dm.VolID = volID;
            createTestVol = vol_dm;

            sp_Volunteer_DM vol_dm_selected = vol_bll.ListVolunteers(volID);
            Assert.IsTrue(VolEquals(vol_dm, vol_dm_selected));
        }

        [TestMethod]
        public void TestVolunteerUpdate()
        {
            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            List<sp_Volunteer_DM> allVols = vol_bll.ListVolunteers();
            Assert.IsTrue(allVols.Count > 0, "The ListVolunteers() is broken, or no data in DB");
            sp_Volunteer_DM firstVol = allVols[0];
            String newFirst = "NewFirst";
            String newMiddle = "NewMiddle";
            String newLast = "NewLast";
            firstVol.VolFirstName = newFirst;
            firstVol.VolMiddleName = newMiddle;
            firstVol.VolLastName = newLast;
            vol_bll.UpdateVolunteerContext(firstVol);
            sp_Volunteer_DM selectedVol = vol_bll.ListVolunteers(firstVol.VolID);

            Assert.IsTrue(VolEquals(firstVol, selectedVol));
            Assert.AreEqual(newFirst, selectedVol.VolFirstName);
            Assert.AreEqual(newMiddle, selectedVol.VolMiddleName);
            Assert.AreEqual(newLast, selectedVol.VolLastName);
        }

        [TestMethod]
        public void TestVolunteerDelete()
        {
            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            List<sp_Volunteer_DM> allVols = vol_bll.ListVolunteers();
            Assert.IsTrue(allVols.Count > 0, "The ListVolunteers() is broken, or no data in DB");
            sp_Volunteer_DM currVol = allVols[0];
            bool notActive = currVol.ActiveFlg != true;
            int i = 1;
            while (notActive && (i < allVols.Count))
            {
                currVol = allVols[i];
                notActive = currVol.ActiveFlg != true;
                i++;
            }
            vol_bll.DeleteVolunteerContext(currVol);
            sp_Volunteer_DM selectedVol = vol_bll.ListVolunteers(currVol.VolID);

            Assert.IsNotNull(selectedVol.ActiveFlg);
            Assert.IsFalse(selectedVol.ActiveFlg == true);
            Assert.IsTrue(selectedVol.ActiveFlg == false);
        }

        [ClassCleanup]
        public static void RemoveVolunteerData()
        {
            sp_Volunteer_BLL volBLL = new sp_Volunteer_BLL();
            volBLL.DeleteVolunteerContext(createTestVol);

            cExcel.RemoveData(ExcelFilenames);
        }

    }
}
