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
    public class utGroup
    {

        static string[] ExcelFilenames = {
            "Volunteer.xlsx",
            "VolAddress.xlsx",
            "VolAddr.xlsx",
            "Group.xlsx",
            "GroupVol.xlsx",
            "GroupAddr.xlsx"
        };

        bool Equals(sp_Group_DM dm1, sp_Group_DM dm2)
        {
            return (dm1.GroupID == dm2.GroupID &&
                    dm1.GroupName == dm2.GroupName &&
                    dm1.LongDesc == dm2.LongDesc &&
                    dm1.ShortDesc == dm2.ShortDesc &&
                    dm1.ActiveFlg == dm2.ActiveFlg &&
                    dm1.ParticipationLevelID == dm2.ParticipationLevelID
                    );
        }

        private static List<sp_Group_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_Group_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnGroup = new sp_Group_DM();
                returnGroup.GroupID = Convert.ToInt32(dataTable.Rows[i]["GroupID"]);
                returnGroup.GroupName = (String)dataTable.Rows[i]["GroupName"];
                returnGroup.LongDesc = (String)dataTable.Rows[i]["LongDesc"];
                returnGroup.ShortDesc = (String)dataTable.Rows[i]["ShortDesc"];
                returnGroup.ParticipationLevelID = Convert.ToInt32(dataTable.Rows[i]["ParticipationLevelID"]);
                DMs.Add(returnGroup);
            }
            return DMs;
        }

        [ClassInitialize]
        public static void InsertGroupData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveData(ExcelFilenames);
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestGroupRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "Group.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vol].[tblGroup]");

            //Pull our data from the DB through the BLL
            var group_bll = new sp_Group_BLL();
            var allGroups = group_bll.ListGroups();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allGroups.Count);
            foreach (var testGroup in excelDMs)
            {
                var selectedGroup = group_bll.ListGroups(testGroup.GroupID);
                Assert.IsTrue(Equals(testGroup, selectedGroup));
            }
        }

        [TestMethod]
        public void TestGroupCreate()
        {
            string groupName = "TestGroup";
            string shortDesc = "We Rock!";
            string longDesc = "We will, we will, rock you!";
            int levelID = 5;
            var group_bll = new sp_Group_BLL();
            var group_dm = new sp_Group_DM();
            group_dm.GroupName = groupName;
            group_dm.ShortDesc = shortDesc;
            group_dm.LongDesc = longDesc;
            group_dm.ParticipationLevelID = levelID;
            var groupID = group_bll.InsertGroupContext(ref group_dm).GroupID;
            group_dm.GroupID = groupID;

            var group_dm_selected = group_bll.ListGroups(groupID);
            Assert.IsTrue(Equals(group_dm, group_dm_selected));
        }

        [TestMethod]
        public void TestGroupUpdate()
        {
            var group_bll = new sp_Group_BLL();
            var allGroups = group_bll.ListGroups();
            Assert.IsTrue(allGroups.Count > 0, "The ListGroups() is broken, or no data in DB");
            var firstGroup = allGroups[0];
            var newGroupName = "Updated Group Name";
            firstGroup.GroupName = newGroupName;
            group_bll.UpdateGroupContext(firstGroup);
            var selectedGroup = group_bll.ListGroups(firstGroup.GroupID);

            Assert.IsTrue(Equals(firstGroup, selectedGroup));
            Assert.AreEqual(newGroupName, selectedGroup.GroupName);
        }

        [TestMethod]
        public void TestGroupDelete()
        {
            var group_bll = new sp_Group_BLL();
            var allGroups = group_bll.ListGroups();
            Assert.IsTrue(allGroups.Count > 0, "The ListGroups() is broken, or no data in DB");
            var currGroup = allGroups[0];
            //TODO: change activeflg to bool not bool?
            var notActive = currGroup.ActiveFlg != true;
            var i = 1;
            while (notActive)
            {
                currGroup = allGroups[i];
                notActive = currGroup.ActiveFlg != true;
            }
            group_bll.DeleteGroupContext(currGroup);
            var selectedGroup = group_bll.ListGroups(currGroup.GroupID);

            //TODO: change activeflg to bool not bool?
            Assert.IsNotNull(selectedGroup.ActiveFlg);
            Assert.IsFalse(selectedGroup.ActiveFlg == true);
            Assert.IsTrue(selectedGroup.ActiveFlg == false);
        }

        //TODO: Write tests to check for expected failures
        //IDEAS:
        //  Insert a NULL ActiveFlg, should error (won't)
        //  Insert too long of a short desc
        //  Insert too long of a Group Name
        //  Insert a super large participationID
        //  Test for XACT rollback

        [ClassCleanup]
        public static void ClassCleanup()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
