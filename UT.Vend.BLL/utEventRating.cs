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
    public class utEventRating
    {

        static string[] ExcelFilenames = {
            "Contact.xlsx",
            "VendAddress.xlsx",
            "../../UT.Vol.BLL/HelperFiles/Volunteer.xlsx",
            "Project.xlsx",
            "ProjectEvent.xlsx",
            "ProjectEventContact.xlsx",
            "EventRating.xlsx"
        };

        private static bool Equals(sp_EventRating_DM dm1, sp_EventRating_DM dm2)
        {
            return (dm1.RatingID == dm2.RatingID &&
                    dm1.EventID == dm2.EventID &&
                    dm1.VolID == dm2.VolID &&
                    dm1.RatingValue == dm2.RatingValue &&
                    dm1.ActiveFlg == dm2.ActiveFlg
                    );
        }

        private static List<sp_EventRating_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_EventRating_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnEventRating = new sp_EventRating_DM();
                returnEventRating.RatingID = Convert.ToInt32(dataTable.Rows[i]["RatingID"]);
                returnEventRating.EventID = new Guid((String)dataTable.Rows[i]["EventID"]);
                returnEventRating.VolID = new Guid((String)dataTable.Rows[i]["VolID"]);
                returnEventRating.RatingValue = Convert.ToInt32(dataTable.Rows[i]["RatingValue"]);
                returnEventRating.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                DMs.Add(returnEventRating);
            }
            return DMs;
        }

        [ClassInitialize]
        public static void initializeClass(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveData(ExcelFilenames);
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestEventRatingRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "EventRating.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblEventRating]");

            //Pull our data from the DB through the BLL
            var EventRating_bll = new sp_EventRating_BLL();
            var allEventRatings = EventRating_bll.ListEventRatings();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allEventRatings.Count);
            foreach (var testEventRating in excelDMs)
            {
                var selectedEventRating = EventRating_bll.ListEventRatings(testEventRating.RatingID);
                Assert.IsTrue(Equals(testEventRating, selectedEventRating));
            }
        }

        [TestMethod]
        public void TestEventRatingCreate()
        {
            DateTime StartDate = new DateTime(2014, 05, 01, 10, 0, 0);
            DateTime EndDate = new DateTime(2014, 05, 02, 11, 0, 0);
            var EventRating_bll = new sp_EventRating_BLL();
            var EventRating_dm = new sp_EventRating_DM();
            var Event_bll = new sp_ProjectEvent_BLL();

            var allEvents = Event_bll.ListEvents();
            Assert.IsTrue(allEvents.Count > 0, "The ListEventRatings() is broken, or no data in DB");
            EventRating_dm.EventID = allEvents[0].EventID;

            int RatingID = EventRating_bll.InsertEventRatingContext(EventRating_dm).RatingID;
            EventRating_dm.RatingID = RatingID;

            var EventRating_dm_selected = EventRating_bll.ListEventRatings(RatingID);
            Assert.IsTrue(Equals(EventRating_dm, EventRating_dm_selected));
        }

        [TestMethod]
        public void TestEventRatingUpdate()
        {
            var EventRating_bll = new sp_EventRating_BLL();
            var allEventRatings = EventRating_bll.ListEventRatings();
            Assert.IsTrue(allEventRatings.Count > 0, "The ListEventRatings() is broken, or no data in DB");
            var firstEventRating = allEventRatings[0];
            firstEventRating.RatingValue = firstEventRating.RatingValue + 1;
            firstEventRating.ActiveFlg = !firstEventRating.ActiveFlg;
            EventRating_bll.UpdateEventRatingContext(firstEventRating);
            var selectedEventRating = EventRating_bll.ListEventRatings(firstEventRating.RatingID);

            Assert.IsTrue(Equals(firstEventRating, selectedEventRating));
        }

        [TestMethod]
        public void TestEventRatingDelete()
        {
            var EventRating_bll = new sp_EventRating_BLL();
            var allEventRatings = EventRating_bll.ListEventRatings();
            Assert.IsTrue(allEventRatings.Count > 0, "The ListEventRatings() is broken, or no data in DB");
            var currEventRating = allEventRatings[0];

            var notActive = currEventRating.ActiveFlg != true;
            var i = 1;
            while (notActive)
            {
                currEventRating = allEventRatings[i];
                notActive = currEventRating.ActiveFlg != true;
            }
            EventRating_bll.DeleteEventRatingContext(currEventRating);
            var selectedEventRating = EventRating_bll.ListEventRatings(currEventRating.RatingID);

            Assert.IsFalse(selectedEventRating.ActiveFlg);
        }

        [ClassCleanup]
        public static void postRun()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
