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
        public void TestVendorCreate()
        {
            sp_Vendor_DM data = new sp_Vendor_DM();
            data.VendorID = new Guid();
            string vendorName = "My Name";
            data.VendorName= vendorName;
            data.ActiveFlg = true;
            sp_Vendor_BLL vendor = new sp_Vendor_BLL();
            vendor.InsertVendorContext(ref data);
            Assert.AreEqual(vendorName, data.VendorName, "Vendor Name Not Set As Expected");
            Assert.AreEqual(true, data.ActiveFlg, "Active Flag Not Set As Expected");
        }

        [TestMethod]
        public void TestVendorReadAll()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "Vendor.xlsx"));
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblVendor]");

            //Pull our data from the DB through the BLL
            sp_Vendor_BLL vendor = new sp_Vendor_BLL();
            var allVendors = vendor.ListVendors();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allVendors.Count);
        }

        [TestMethod]
        public void TestVendorRead()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Vendor.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string vendorID = row["VendorID"].ToString();
                sp_Vendor_BLL vendor = new sp_Vendor_BLL();
                sp_Vendor_DM data = vendor.ListVendors(new Guid(vendorID));
                Assert.AreEqual(row["VendorName"].ToString(), data.VendorName, "Vendor Name Not Set As Expected");
            }
        }


        [TestMethod]
        public void TestContactUpdate()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Vendor.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string vendorID = row["VendorID"].ToString();
                string updateVendorName = "TestVendorName";;
                sp_Vendor_DM data = new sp_Vendor_DM();
                data.VendorID = new Guid(vendorID);
                data.VendorName = updateVendorName;
                sp_Vendor_BLL vendor = new sp_Vendor_BLL();
                vendor.UpdateVolunteerContext(data);
                data = vendor.ListVendors(new Guid(vendorID));
                Assert.AreEqual(updateVendorName, data.VendorName, "Vendor Name Not Set As Expected");
            }
        }

        [TestMethod]
        public void TestContactDelete()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Vendor.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string vendorID = row["VendorID"].ToString();
                string updateVendorName = "TestVendorName"; ;
                sp_Vendor_DM data = new sp_Vendor_DM();
                data.VendorID = new Guid(vendorID);
                data.VendorName = updateVendorName;
                sp_Vendor_BLL vendor = new sp_Vendor_BLL();
                vendor.DeleteVendorContext(data);
                data = vendor.ListVendors(new Guid(vendorID));
                Assert.AreEqual(false, data.ActiveFlg, "ActiveFlag not set as expected");
            }
        }

        [ClassCleanup]
        public static void RemoveVendorData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
