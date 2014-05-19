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
        
        private static bool Equals(sp_ProjectEventContact_DM dm1, sp_ProjectEventContact_DM dm2)
        {
            return (dm1.ContactID == dm2.ContactID &&
                    dm1.EventID == dm2.EventID &&
                    dm1.PrimaryContact == dm2.PrimaryContact
                    );
        }

        private static List<sp_ProjectEventContact_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_ProjectEventContact_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnProjectEventContact = new sp_ProjectEventContact_DM();
                returnProjectEventContact.ContactID = new Guid((string)dataTable.Rows[i]["ContactID"]);
                returnProjectEventContact.EventID = new Guid((String)dataTable.Rows[i]["EventID"]);
                returnProjectEventContact.PrimaryContact = Convert.ToBoolean(dataTable.Rows[i]["PrimaryContact"]);
                DMs.Add(returnProjectEventContact);
            }
            return DMs;
        }
        
        [ClassInitialize]
        public static void initializeClass(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);
        }
        
        [TestMethod]
        public void TestProjectEventContactRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "ProjectEventContact.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblProjectEventContact]");

            //Pull our data from the DB through the BLL
            var ProjectEventContact_bll = new sp_ProjectEventContact_BLL();
            var allProjectEventContacts = ProjectEventContact_bll.ListEventsContacts();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allProjectEventContacts.Count);
            foreach (var testProjectEventContact in excelDMs)
            {
                var selectedProjectEventContact = ProjectEventContact_bll.ListEventsContacts(
                                                            testProjectEventContact.EventID,
                                                            testProjectEventContact.ContactID);
                Assert.AreEqual(1, selectedProjectEventContact.Count);
                Assert.IsTrue(Equals(testProjectEventContact, selectedProjectEventContact[0]));
            }
        }

        [TestMethod]
        public void TestProjectEventContactCreate()
        {
            bool PrimaryContact = true;
            var ProjectEventContact_bll = new sp_ProjectEventContact_BLL();
            var ProjectEventContact_dm = new sp_ProjectEventContact_DM();
            var ProjectEvent_bll = new sp_ProjectEvent_BLL();
            var Contact_bll = new sp_Contact_BLL();
            ProjectEventContact_dm.PrimaryContact = PrimaryContact;

            var allProjectEvents = ProjectEvent_bll.ListEvents();
            Assert.IsTrue(allProjectEvents.Count > 0, "The ListEvents() is broken, or no data in DB");
            ProjectEventContact_dm.EventID = allProjectEvents[0].EventID;

            var allContacts = Contact_bll.ListContacts();
            Assert.IsTrue(allContacts.Count > 0, "The ListContacts() is broken, or no data in DB");
            ProjectEventContact_dm.ContactID = allContacts[0].ContactID;

            ProjectEventContact_bll.InsertProjectEventContactContext(ProjectEventContact_dm);

            var ProjectEventContact_dm_selected = ProjectEventContact_bll.ListEventsContacts(
                                                                ProjectEventContact_dm.EventID,
                                                                ProjectEventContact_dm.ContactID);
            Assert.AreEqual(1, ProjectEventContact_dm_selected.Count);
            Assert.IsTrue(Equals(ProjectEventContact_dm, ProjectEventContact_dm_selected[0]));
        }

        [TestMethod]
        public void TestProjectEventContactUpdate()
        {
            var ProjectEventContact_bll = new sp_ProjectEventContact_BLL();
            var allProjectEventContacts = ProjectEventContact_bll.ListEventsContacts();
            Assert.IsTrue(allProjectEventContacts.Count > 0, "The ListEventsContacts() is broken, or no data in DB");
            var firstProjectEventContact = allProjectEventContacts[0];
            firstProjectEventContact.PrimaryContact = !firstProjectEventContact.PrimaryContact;
            ProjectEventContact_bll.UpdateProjectEventContactContext(firstProjectEventContact);
            var selectedProjectEventContact = ProjectEventContact_bll.ListEventsContacts(
                                                        firstProjectEventContact.EventID,
                                                        firstProjectEventContact.ContactID);
            Assert.AreEqual(1, selectedProjectEventContact.Count);
            Assert.IsTrue(Equals(firstProjectEventContact, selectedProjectEventContact));
        }

        [TestMethod]
        public void TestProjectEventContactDelete()
        {
            var ProjectEventContact_bll = new sp_ProjectEventContact_BLL();
            var allProjectEventContacts = ProjectEventContact_bll.ListEventsContacts();
            Assert.IsTrue(allProjectEventContacts.Count > 0, "The ListProjectEventContacts() is broken, or no data in DB");
            var currProjectEventContact = allProjectEventContacts[0];

            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblProjectEventContact]");

            ProjectEventContact_bll.DeleteProjectEventContactContext(currProjectEventContact);
            var selectedProjectEventContact = ProjectEventContact_bll.ListEventsContacts(
                                                                currProjectEventContact.EventID,
                                                                currProjectEventContact.ContactID);
            Assert.AreEqual(1, selectedProjectEventContact.Count);
            var numCurrRows = cExcel.getNumRecordsFromDB("[Vend].[tblProjectEventContact]");
            Assert.AreEqual(numRows - 1, numCurrRows);
        }
        
        [ClassCleanup]
        public static void postRun()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
