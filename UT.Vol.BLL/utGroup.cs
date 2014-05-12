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

        [ClassInitialize]
        public static void InsertGroupData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveData(ExcelFilenames);
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestGroup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
