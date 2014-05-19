using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using UT.Vol.BLL.HelperMethods;
using UT.Helper;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utGroupVol
    {

        static string[] ExcelFilenames = {
            "Group.xlsx",
            "Volunteer.xlsx",
            "GroupVol.xlsx"
        };

        bool Equals(sp_Vol_GroupVol_DM dm1, sp_Vol_GroupVol_DM dm2)
        {
            return (dm1.GroupID == dm2.GroupID &&
                    dm1.VolID == dm2.VolID &&
                    dm1.PrimaryVolID == dm2.PrimaryVolID &&
                    dm1.Admin == dm2.Admin
                    );
        }

        private static List<sp_Vol_GroupVol_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_Vol_GroupVol_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnGroupVol = new sp_Vol_GroupVol_DM();
                returnGroupVol.GroupID = Convert.ToInt32(dataTable.Rows[i]["GroupID"]);
                returnGroupVol.VolID = new Guid((string)dataTable.Rows[i]["VolID"]);
                returnGroupVol.Admin = Convert.ToBoolean(dataTable.Rows[i]["Admin"]);
                returnGroupVol.PrimaryVolID = Convert.ToBoolean(dataTable.Rows[i]["PrimaryVolID"]);
                DMs.Add(returnGroupVol);
            }
            return DMs;
        }

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestGroupVolRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "GroupVol.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vol].[tblGroupVol]");

            //Pull our data from the DB through the BLL
            var groupVol_bll = new sp_GroupVol_BLL();
            List<sp_GroupVol_BLL> allGroupVols = null;
            //Need someway to select all group vols
            //allGroupVols = groupVol_bll.ListGroupVols();
            Assert.IsNotNull(allGroupVols, "Listing all Group Vols is broken or no data in DB");

            //Test the data from the BLL
            Assert.AreEqual(numRows, allGroupVols.Count);
            foreach (var testGroup in excelDMs)
            {
                var selectedGroup = groupVol_bll.ListGroupVols(testGroup);
                Assert.IsTrue(Equals(testGroup, selectedGroup));
            }
        }

        [TestMethod]
        public void TestGroupVolCreate()
        {
            var group_bll = new sp_Group_BLL();
            var vol_bll = new sp_Volunteer_BLL();
            var groupVol_bll = new sp_GroupVol_BLL();
            var groupVol_dm = new sp_Vol_GroupVol_DM();
            var allGroups = group_bll.ListGroups();
            var allVols = vol_bll.ListVolunteers();
            Assert.IsTrue(allGroups.Count > 0, "ListGroups() is broken or no data in DB");
            Assert.IsTrue(allVols.Count > 0, "ListVolunteers() is broken or no data in DB");
            groupVol_dm.GroupID = allGroups[0].GroupID;
            groupVol_dm.VolID = allVols[0].VolID;
            groupVol_dm.Admin = true;
            groupVol_dm.PrimaryVolID = true;
            groupVol_bll.InsertGroupContext(ref groupVol_dm);

            var groupVol_dm_selected = groupVol_bll.ListGroupVols(groupVol_dm);
            Assert.AreEqual(1, groupVol_dm_selected.Count);
            Assert.IsTrue(Equals(groupVol_dm, groupVol_dm_selected[0]));
        }

        [TestMethod]
        public void TestGroupVolUpdate()
        {
            var volAddress_bll = new sp_Vol_Address_BLL();
            var groupVol_bll = new sp_GroupVol_BLL();
            //Grab the first groupVol we find
            List<sp_Vol_GroupVol_DM> allGroupVols = null;
            //allGroupVols = groupVol_bll.ListGroupVols();
            Assert.IsNotNull(allGroupVols, "Please fix/implement ListGroupVols then uncomment it");
            Assert.IsTrue(allGroupVols.Count > 0, "The ListGroupVols() is broken, or no data in DB");
            var firstGroupVol = allGroupVols[0];
            
            //Change some data
            firstGroupVol.PrimaryVolID = !firstGroupVol.PrimaryVolID;
            firstGroupVol.Admin = !firstGroupVol.Admin;
            //groupVol_bll.Update(firstGroupVol);

            //Pull record after the changes and test if it worked
            var selectedgroupVol = groupVol_bll.ListGroupVols(firstGroupVol);
            Assert.IsTrue(Equals(firstGroupVol, selectedgroupVol));
        }

        [TestMethod]
        public void TestGroupVolDelete()
        {
            var groupVol_bll = new sp_GroupVol_BLL();
            //Grab the first groupVol we find
            List<sp_Vol_GroupVol_DM> allGroupVols = null;
            //allGroupVols = groupVol_bll.ListGroupVols();
            Assert.IsNotNull(allGroupVols, "Please fix/implement ListGroupVols then uncomment it");
            Assert.IsTrue(allGroupVols.Count > 0, "The ListGroupVols() is broken, or no data in DB");
            var currGroupVol = allGroupVols[0];
            var numRows = cExcel.getNumRecordsFromDB("[Vol].[tblGroupVol]");

            groupVol_bll.DeleteGroupContext(currGroupVol);
            var selectedGroupVol = groupVol_bll.ListGroupVols(currGroupVol);

            var currNumRows = cExcel.getNumRecordsFromDB("[Vol].[tblGroupVol]");

            Assert.AreEqual(numRows - 1, currNumRows);
            
            //TODO: expand test to make sure the correct record was deleted
        }

        //TODO: Write tests to check for expected failures
        //IDEAS:
        //  Insert a NULL ActiveFlg, should error (won't)
        //  Test for XACT rollback

        [ClassCleanup]
        public static void ClassCleanup()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
