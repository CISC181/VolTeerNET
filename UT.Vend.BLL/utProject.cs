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
    public class utProject
    {

        static string[] ExcelFilenames = {
            "Contact.xlsx",
            "../../UT.Vol.BLL/HelperFiles/Volunteer.xlsx",
            "Project.xlsx",
            "ProjectEvent.xlsx",
            "ProjectEventContact.xlsx",
            "EventRating.xlsx"
        };


        [ClassInitialize]
        public static void initializeProject(TestContext testContext)
        {
            cExcel.RemoveData(ExcelFilenames);
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestProject()
        {
        }

        [ClassCleanup]
        public static void postRun()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
