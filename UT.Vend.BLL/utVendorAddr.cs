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
    public class utVendorAddr
    {
        static string[] ExcelFilenames = new string[] {
            "VendAddress.xlsx", "Vendor.xlsx","VendorAddr.xlsx"
        };

       

      

        [ClassInitialize]
        public static void InsertVendorAddrData(TestContext testContext)
        {
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);
            
        }

        [TestMethod]
        public void TestVendorAddrCreate()
        {
            //create a vendor
            sp_Vendor_DM data = new sp_Vendor_DM();
            data.VendorID = new Guid();
            string vendorName = "My Name";
            data.VendorName = vendorName;
            data.ActiveFlg = true;
            sp_Vendor_BLL vendor = new sp_Vendor_BLL();
            vendor.InsertVendorContext(ref data);

            //Insert Vendor Addr
            sp_VendorAddr_DM data1 = new sp_VendorAddr_DM();
            data1.VendorID = data.VendorID;
            data1.AddrID = 1;
            sp_VendorAddr_BLL vendoraddr = new sp_VendorAddr_BLL();
            vendoraddr.InsertAddressContext(data1);

            //Read Vendor Add
            var newdata = vendoraddr.ListAddresses(data1.VendorID);

            Assert.AreEqual(newdata.VendorID, data.VendorID, "VendorID Not Set As Expected");
            Assert.AreEqual(newdata.AddrID, 1, "AddrID Not Set As Expected");
        }

        [TestMethod]
        public void TestVendorAddrReadAll()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "VendorAddr.xlsx"));
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblVendorAddr]");

            //Pull our data from the DB through the BLL
            sp_VendorAddr_BLL vendor = new sp_VendorAddr_BLL();
            var allVendors = vendor.ListAddresses();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allVendors.Count);
        }

        [TestMethod]
        public void TestVendorAddrRead()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendorAddr.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string vendorID = row["VendorID"].ToString();
                sp_VendorAddr_BLL vendor = new sp_VendorAddr_BLL();
                sp_VendorAddr_DM data = vendor.ListAddresses(new Guid(vendorID));
                Assert.AreEqual(row["AddrID"].ToString(), data.AddrID, "AddrID Not Set As Expected");
                Assert.AreEqual(row["HQ"].ToString(), data.HQ, "HQ Not Set As Expected");
            }
        }

        [TestMethod]
        public void TestVendorAddrUpdate()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendorAddr.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                Guid vendorID = new Guid(row["VendorID"].ToString());
                sp_VendorAddr_DM data = new sp_VendorAddr_DM();
                data.VendorID = vendorID;
                data.AddrID = 1;
                sp_VendorAddr_BLL vendor = new sp_VendorAddr_BLL();
                vendor.UpdateAddressContext(data);
                var newdata = vendor.ListAddresses(vendorID);
                Assert.AreEqual(newdata.AddrID, data.AddrID, "AddrID Not Set As Expected");
            }
        }


        

        [TestMethod]
        public void TTestVendorAddrDelete()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendorAddr.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                Guid vendorID = new Guid(row["VendorID"].ToString());
                sp_VendorAddr_DM data = new sp_VendorAddr_DM();
                data.VendorID = vendorID;
                sp_VendorAddr_BLL vendor = new sp_VendorAddr_BLL();
                vendor.DeleteAddressContext(data);
                var newdata = vendor.ListAddresses(vendorID);
                
            }
        }


        


        [ClassCleanup]
        public static void RemoveVendAddressData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
