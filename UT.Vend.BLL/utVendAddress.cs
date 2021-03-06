﻿using System;
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
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);   
        }

        [TestMethod]
        public void TestVendAddressCreate()
        {
            //Test Our Read
            sp_VendAddress_DM data = new sp_VendAddress_DM();
            string AddrLine1 = "Add1";
            string AddrLine2 = "Add2";
            string AddrLine3 = "Add3";
            string City = "City";
            string St = "St";
            int Zip = 11111;
            int Zip4 = 1111;


            data.AddrLine1 = AddrLine1;
            data.AddrLine2 = AddrLine2;
            data.AddrLine3 = AddrLine3;
            data.City = City;
            data.St = St;
            data.Zip = Zip;
            data.Zip4 = Zip4;
            data.ActiveFlg = true;
            sp_VendAddress_BLL vend = new sp_VendAddress_BLL();
            vend.InsertAddressContext(data);
            Assert.AreEqual(AddrLine1, data.AddrLine1, "AddrLine1 Not Set As Expected");
            Assert.AreEqual(AddrLine2, data.AddrLine2, "AddrLine2 Not Set As Expected");
            Assert.AreEqual(AddrLine3, data.AddrLine3, "AddrLine3 Not Set As Expected");
            Assert.AreEqual(City, data.City, "City Not Set As Expected");
            Assert.AreEqual(St, data.St, "St Not Set As Expected");
            Assert.AreEqual(Zip, data.Zip, "Zip Not Set As Expected");
            Assert.AreEqual(Zip4, data.Zip4, "Zip Not Set As Expected");

        }

        [TestMethod]
        public void TestVendAddressRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendAddress.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                int AddrID = Convert.ToInt32(row["AddrID"].ToString());
                sp_VendAddress_BLL vend = new sp_VendAddress_BLL();
                sp_VendAddress_DM data = vend.ListAddresses(AddrID);
                Assert.AreEqual(row["AddrLine1"].ToString(), data.AddrLine1, "AddrLine1 Not Set As Expected");
                Assert.AreEqual(row["AddrLine2"].ToString(), data.AddrLine2, "AddrLine2 Not Set As Expected");
                Assert.AreEqual(row["AddrLine3"].ToString(), data.AddrLine3, "AddrLine3 Not Set As Expected");
                Assert.AreEqual(row["City"].ToString(), data.City, "City Not Set As Expected");
                Assert.AreEqual(row["St"].ToString(), data.St, "St Not Set As Expected");
                Assert.AreEqual(Convert.ToInt32(row["Zip"]), data.Zip, "Zip Not Set As Expected"); //Floats don't work
                Assert.AreEqual(Convert.ToInt32(row["Zip4"]), data.Zip4, "Zip4 Not Set As Expected"); //Ints don't work
            }
        }

        [TestMethod]
        public void TestVendorAddrReadAll()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "VendAddress.xlsx"));
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblVendAddress]");

            //Pull our data from the DB through the BLL
            sp_VendAddress_BLL vendor = new sp_VendAddress_BLL();
            var allVendors = vendor.ListAddresses();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allVendors.Count);
        }

        [TestMethod]
        public void TestVendAddressUpdate()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendAddress.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string AddrLine1 = "TestAddrLine1";
                string AddrLine2 = "TestAddrLine2";
                string AddrLine3 = "TestAddrLine3";
                string City = "TestCity";
                string St = "TestSt";
                int Zip = 11111;
                int Zip4 = 1111;

                int AddrID = Convert.ToInt32(row["AddrID"].ToString());
                sp_VendAddress_DM data = new sp_VendAddress_DM();
                data.AddrID = AddrID;
                data.AddrLine1 = AddrLine1;
                data.AddrLine2 = AddrLine2;
                data.AddrLine3 = AddrLine3;
                data.City = City;
                data.St = St;
                data.Zip = Zip;
                data.Zip4 = Zip4;
                sp_VendAddress_BLL vend = new sp_VendAddress_BLL();
                vend.UpdateAddressContext(data);
                data = vend.ListAddresses(AddrID);
                Assert.AreEqual(AddrLine1, data.AddrLine1, "AddrLine1 Not Set As Expected");
                Assert.AreEqual(AddrLine2, data.AddrLine2, "AddrLine2 Not Set As Expected");
                Assert.AreEqual(AddrLine3, data.AddrLine3, "AddrLine3 Not Set As Expected");
                Assert.AreEqual(City, data.City, "City Not Set As Expected");
                Assert.AreEqual(St, data.St, "St Not Set As Expected");
                Assert.AreEqual(Zip, data.Zip, "Zip Not Set As Expected");
                Assert.AreEqual(Zip4, data.Zip4, "Zip4 Not Set As Expected");

            }
        }

        [TestMethod]
        public void TestVendAddressDelete()
        {

            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "VendAddress.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                int AddrID = Convert.ToInt32(row["AddrID"].ToString());
                sp_VendAddress_DM data = new sp_VendAddress_DM();
                sp_VendAddress_BLL vend = new sp_VendAddress_BLL();
                data.AddrID = AddrID;
                vend.DeleteAddressContext(data);
                data = vend.ListAddresses(AddrID);
                Assert.AreEqual(false, data.ActiveFlg, "ActiveFlag not set as expected");
            }
        }

        


        [ClassCleanup]
        public static void RemoveVendAddressData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
