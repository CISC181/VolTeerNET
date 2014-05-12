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

using System.Linq;

namespace UT.Vend.BLL
{
    [TestClass]
    public class utVendor
    {
        static string[] ExcelFilenames = new string[] {
            "VendAddress.xlsx", "Vendor.xlsx","VendorAddr.xlsx"
        };

       

      

        [ClassInitialize]
        public static void InsertVendorData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);
            
        }

        [TestMethod]
        public void TestVendor()
        {
        }

        [ClassCleanup]
        public static void RemoveVendorData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
