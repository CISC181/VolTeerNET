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
    public class utGroupAddr
    {

        static string[] ExcelFilenames = {
            "Group.xlsx",
            "VolAddress.xlsx",
            "GroupAddr.xlsx"
        };

        bool Equals(sp_GroupAddr_DM dm1, sp_GroupAddr_DM dm2)
        {
            return (dm1.GroupID == dm2.GroupID &&
                    dm1.AddrID == dm2.AddrID &&
                    dm1.PrimaryAddrID == dm2.PrimaryAddrID &&
                    dm1.ActiveFlg == dm2.ActiveFlg
                    );
        }

        private static List<sp_GroupAddr_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_GroupAddr_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnGroup = new sp_GroupAddr_DM();
                returnGroup.GroupID = Convert.ToInt32(dataTable.Rows[i]["GroupID"]);
                returnGroup.AddrID = Convert.ToInt32(dataTable.Rows[i]["AddrID"]);
                returnGroup.PrimaryAddrID = Convert.ToBoolean(dataTable.Rows[i]["PrimaryAddrID"]);
                returnGroup.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                DMs.Add(returnGroup);
            }
            return DMs;
        }

        [ClassInitialize]
        public static void InsertGroupAddrData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestGroupAddrRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "GroupAddr.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vol].[tblGroupAddr]");

            //Pull our data from the DB through the BLL
            var groupAddr_bll = new sp_GroupAddr_BLL();
            var allGroupAddrs = groupAddr_bll.ListGroups();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allGroupAddrs.Count);
            //foreach (var testGroupAddr in excelDMs)
            //{
            //    var selectedGroupAddr = groupAddr_bll.ListGroups();
            //    //Assert.IsTrue(Equals(testGroupAddr, selectedGroupAddr));
            //}
        }

        [TestMethod]
        public void TestGroupAddrCreate()
        {
            var group_bll = new sp_Group_BLL();
            var groupAddr_bll = new sp_GroupAddr_BLL();
            var groupAddr_dm = new sp_GroupAddr_DM();
            var allGroups = group_bll.ListGroups();
            Assert.IsTrue(allGroups.Count > 0, "The allGroups() is broken, or no data in DB");
            groupAddr_dm.GroupID = allGroups[0].GroupID;
            groupAddr_dm.PrimaryAddrID = true;
            groupAddr_dm.ActiveFlg = true;
            var volAddress_bll = new sp_Vol_Address_BLL();
            var volAddress_dm = volAddress_bll.ListAddress(new sp_Vol_Address_DM());
            groupAddr_bll.InsertAddressContext(ref volAddress_dm, ref groupAddr_dm);
            groupAddr_dm.AddrID = volAddress_dm.AddrID;

            var groupAddr_dm_selected = groupAddr_bll.ListAddress(groupAddr_dm);
            Assert.IsTrue(Equals(groupAddr_dm, groupAddr_dm_selected));
        }

        [TestMethod]
        public void TestGroupAddrUpdate()
        {
            var volAddress_bll = new sp_Vol_Address_BLL();
            var groupAddr_bll = new sp_GroupAddr_BLL();
            //Grab the first GroupAddr we find
            var allGroupAddrs = groupAddr_bll.ListAddresses(null, null);
            Assert.IsTrue(allGroupAddrs.Count > 0, "The ListAddresses() is broken, or no data in DB");
            var firstGroupAddr = allGroupAddrs[0];

            //Get the volAddress the GroupAddr points to
            var volAddress_dm = new sp_Vol_Address_DM();
            volAddress_dm.AddrID = firstGroupAddr.AddrID;
            volAddress_dm = volAddress_bll.ListAddress(volAddress_dm);
            
            //Change some data
            firstGroupAddr.PrimaryAddrID = !firstGroupAddr.PrimaryAddrID;
            firstGroupAddr.ActiveFlg = !firstGroupAddr.ActiveFlg;
            groupAddr_bll.UpdateAddressContext(volAddress_dm, firstGroupAddr);

            //Pull record after the changes and test if it worked
            var selectedGroupAddr = groupAddr_bll.ListAddress(firstGroupAddr);
            Assert.IsTrue(Equals(firstGroupAddr, selectedGroupAddr));
        }

        [TestMethod]
        public void TestGroupAddrDelete()
        {
            var volAddress_bll = new sp_Vol_Address_BLL();
            var groupAddr_bll = new sp_GroupAddr_BLL();
            //Grab the first GroupAddr we find
            var allGroupAddrs = groupAddr_bll.ListAddresses(null, null);
            Assert.IsTrue(allGroupAddrs.Count > 0, "The ListAddresses() is broken, or no data in DB");
            var currGroupAddr = allGroupAddrs[0];
            //TODO: change activeflg to bool not bool?
            var notActive = currGroupAddr.ActiveFlg != true;
            var i = 1;
            while (notActive)
            {
                currGroupAddr = allGroupAddrs[i];
                notActive = currGroupAddr.ActiveFlg != true;
            }

            var volAddress_dm = new sp_Vol_Address_DM();
            volAddress_dm = volAddress_bll.ListAddress(volAddress_dm);
            groupAddr_bll.DeleteAddressContext(volAddress_dm, currGroupAddr);
            var selectedGroup = groupAddr_bll.ListAddress(currGroupAddr);
            var selectedVolAddress = volAddress_bll.ListAddress(volAddress_dm);

            //TODO: change activeflg to bool not bool?
            Assert.IsNotNull(selectedGroup.ActiveFlg);
            Assert.IsFalse(selectedGroup.ActiveFlg == true);
            Assert.IsTrue(selectedGroup.ActiveFlg == false);

            //TODO: change activeflg to bool not bool?
            Assert.IsNotNull(selectedVolAddress.ActiveFlg);
            Assert.IsFalse(selectedVolAddress.ActiveFlg == true);
            Assert.IsTrue(selectedVolAddress.ActiveFlg == false);
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
