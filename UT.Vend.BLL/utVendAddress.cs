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
    public class utVendAddress
    {
        static string[] ExcelFilenames = new string[] {
            "VendAddress.xlsx", "Vendor.xlsx","VendorAddr.xlsx"
        };

       

      

        [ClassInitialize]
        public static void InsertVendAddressData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);
            
        }

        [TestMethod]
        public void TestVendAddressRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendAddress.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                int AddrID = (int)row["AddrID"];
                sp_VendAddress_BLL vend = new sp_VendAddress_BLL();
                sp_VendAddress_DM data = vend.ListAddresses(AddrID);
                Assert.AreEqual(row["[AddrLine1]"].ToString(), data.AddrLine1, "AddrLine1 Not Set As Expected");
            }
        }

        [ClassCleanup]
        public static void RemoveVendAddressData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
