using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using UT.Helper;

namespace UT.Vend.BLL
{
    [TestClass]
    public class utProjectEventContact
    {

        static string[] ExcelFilenames = {
            "VendAddress.xlsx",
            "Contact.xlsx",
            "Project.xlsx",
            "ProjectEvent.xlsx",
            "ProjectEventContact.xlsx"
        };
        /*
        private static bool Equals(sp_ProjectEvent_DM dm1, sp_ProjectEvent_DM dm2)
        {
            return (dm1.ProjectID == dm2.ProjectID &&
                    dm1.EventID == dm2.EventID &&
                    dm1.StartDateTime == dm2.StartDateTime &&
                    dm1.EndDateTime == dm2.EndDateTime &&
                    dm1.AddrID == dm2.AddrID
                    );
        }

        private static List<sp_ProjectEvent_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_ProjectEvent_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnProjectEvent = new sp_ProjectEvent_DM();
                returnProjectEvent.ProjectID = new Guid((string)dataTable.Rows[i]["ProjectID"]);
                returnProjectEvent.EventID = new Guid((String)dataTable.Rows[i]["EventID"]);
                returnProjectEvent.StartDateTime = Convert.ToDateTime(dataTable.Rows[i]["StartDateTime"]);
                returnProjectEvent.EndDateTime = Convert.ToDateTime(dataTable.Rows[i]["EndDateTime"]);
                returnProjectEvent.AddrID = Convert.ToInt32(dataTable.Rows[i]["AddrID"]);
                DMs.Add(returnProjectEvent);
            }
            return DMs;
        }
        */
        [ClassInitialize]
        public static void initializeClass(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveData(ExcelFilenames);
            cExcel.InsertData(ExcelFilenames);
        }
        /*
        [TestMethod]
        public void TestProjectEventRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "ProjectEvent.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblProjectEvent]");

            //Pull our data from the DB through the BLL
            var ProjectEvent_bll = new sp_ProjectEvent_BLL();
            var allProjectEvents = ProjectEvent_bll.ListEvents();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allProjectEvents.Count);
            foreach (var testProjectEvent in excelDMs)
            {
                var selectedProjectEvent = ProjectEvent_bll.ListEvents(testProjectEvent.ProjectID);
                Assert.IsTrue(Equals(testProjectEvent, selectedProjectEvent));
            }
        }

        [TestMethod]
        public void TestProjectEventCreate()
        {
            DateTime StartDate = new DateTime(2014, 05, 01, 10, 0, 0);
            DateTime EndDate = new DateTime(2014, 05, 02, 11, 0, 0);
            var ProjectEvent_bll = new sp_ProjectEvent_BLL();
            var ProjectEvent_dm = new sp_ProjectEvent_DM();
            var Project_bll = new sp_Project_BLL();
            var VendAdress_bll = new sp_VendAddress_BLL();
            ProjectEvent_dm.StartDateTime = StartDate;
            ProjectEvent_dm.EndDateTime = EndDate;

            var allProjects = Project_bll.ListProjects();
            Assert.IsTrue(allProjects.Count > 0, "The ListProjects() is broken, or no data in DB");
            ProjectEvent_dm.ProjectID = allProjects[0].ProjectID;

            var allAddresses = VendAdress_bll.ListAddresses();
            Assert.IsTrue(allAddresses.Count > 0, "The ListAddresses() is broken, or no data in DB");
            ProjectEvent_dm.AddrID = allAddresses[0].AddrID;
            var ProjectID = ProjectEvent_bll.InsertEventContext(ref ProjectEvent_dm).ProjectID;
            ProjectEvent_dm.ProjectID = ProjectID;

            var ProjectEvent_dm_selected = ProjectEvent_bll.ListEvents(ProjectID);
            Assert.IsTrue(Equals(ProjectEvent_dm, ProjectEvent_dm_selected));
        }

        [TestMethod]
        public void TestProjectEventUpdate()
        {
            var ProjectEvent_bll = new sp_ProjectEvent_BLL();
            var allProjectEvents = ProjectEvent_bll.ListEvents();
            Assert.IsTrue(allProjectEvents.Count > 0, "The ListEvents() is broken, or no data in DB");
            var firstProjectEvent = allProjectEvents[0];
            DateTime StartDate = new DateTime(1998, 02, 03, 1, 2, 3);
            DateTime EndDate = new DateTime(1999, 04, 05, 3, 2, 1);
            firstProjectEvent.StartDateTime = StartDate;
            firstProjectEvent.EndDateTime = EndDate;
            ProjectEvent_bll.UpdateEventContext(firstProjectEvent);
            var selectedProjectEvent = ProjectEvent_bll.ListEvents(firstProjectEvent.ProjectID);

            Assert.IsTrue(Equals(firstProjectEvent, selectedProjectEvent));
            Assert.AreEqual(StartDate, selectedProjectEvent.StartDateTime);
            Assert.AreEqual(EndDate, selectedProjectEvent.EndDateTime);
        }

        [TestMethod]
        public void TestProjectEventDelete()
        {
            var ProjectEvent_bll = new sp_ProjectEvent_BLL();
            var allProjectEvents = ProjectEvent_bll.ListEvents();
            Assert.IsTrue(allProjectEvents.Count > 0, "The ListProjectEvents() is broken, or no data in DB");
            var currProjectEvent = allProjectEvents[0];

            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblProjectEvent]");

            ProjectEvent_bll.DeleteEventContext(currProjectEvent);
            var selectedProjectEvent = ProjectEvent_bll.ListEvents(currProjectEvent.ProjectID);

            var numCurrRows = cExcel.getNumRecordsFromDB("[Vend].[tblProjectEvent]");

            Assert.AreEqual(numRows - 1, numCurrRows);
        }
        */
        [ClassCleanup]
        public static void postRun()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
