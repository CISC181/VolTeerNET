using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Vol.BLL.HelperMethods;
using System.Data;
using System.IO;
using UT.Helper;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utVolAddress
    {
        static sp_Volunteer_DM generalTestVol;
        static sp_Volunteer_DM createTestVol;

        //static sp_Vol_Addr_DM createTestVolAddr;
        static sp_Vol_Addr_DM primaryTestVolAddr;
        static sp_Vol_Addr_DM secondaryTestVolAddr;

        static sp_Vol_Address_DM primaryTestVolAddress;
        static sp_Vol_Address_DM secondaryTestVolAddress;

        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx", "VolAddress.xlsx", "VolAddr.xlsx"
        };

        private static bool AddressEquals(sp_Vol_Address_DM dm1, sp_Vol_Address_DM dm2)
        {
            return ((dm1.ActiveFlg == dm2.ActiveFlg) &&
                (dm1.AddrID == dm2.AddrID) &&
                (dm1.AddrLine1 == dm2.AddrLine1) &&
                (dm1.AddrLine2 == dm2.AddrLine2) &&
                (dm1.AddrLine3 == dm2.AddrLine3) &&
                (dm1.City == dm2.City) &&
                (dm1.St == dm2.St) &&
                (dm1.Zip == dm2.Zip) &&
                (dm1.Zip4 == dm2.Zip4) &&
                (dm1.VolID == dm2.VolID) &&
                (dm1.PrimaryAddr == dm2.PrimaryAddr));
        }

        private static bool AddressListContains(List<sp_Vol_Address_DM> addressList, sp_Vol_Address_DM address)
        {

            bool listContainsAddress = false;

            foreach (sp_Vol_Address_DM currAddress in addressList)
            {

                listContainsAddress = listContainsAddress || AddressEquals(currAddress, address);

            }

            return listContainsAddress;

        }

        private static List<sp_Vol_Address_DM> getVolAddressDMs(DataTable dataTable)
        {
            List<sp_Vol_Address_DM> volAddressDMs = new List<sp_Vol_Address_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                sp_Vol_Address_DM returnAddress = new sp_Vol_Address_DM();
                returnAddress.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                returnAddress.AddrID = Convert.ToInt32(dataTable.Rows[i]["AddrID"]);
                returnAddress.AddrLine1 = dataTable.Rows[i]["AddrLine1"].ToString();
                returnAddress.AddrLine2 = dataTable.Rows[i]["AddrLine2"].ToString();
                returnAddress.AddrLine3 = dataTable.Rows[i]["AddrLine3"].ToString();
                returnAddress.City = dataTable.Rows[i]["City"].ToString();
                returnAddress.St = dataTable.Rows[i]["St"].ToString();
                returnAddress.Zip = Convert.ToInt32(dataTable.Rows[i]["Zip"]);
                returnAddress.VolID = new Guid((string)dataTable.Rows[i]["VolID"]);
                returnAddress.PrimaryAddr = Convert.ToBoolean(dataTable.Rows[i]["PrimaryAddr"]);
                if (!(dataTable.Rows[i]["Zip4"] is DBNull))
                    returnAddress.Zip4 = Convert.ToInt32(dataTable.Rows[i]["Zip4"]);
                else
                    returnAddress.Zip4 = null;
  
                volAddressDMs.Add(returnAddress);
            }
            return volAddressDMs;
        }

        [ClassInitialize]
        public static void InsertVolAddressData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);

            sp_Volunteer_BLL volBLL = new sp_Volunteer_BLL();
            generalTestVol = new sp_Volunteer_DM();
            generalTestVol.VolFirstName = "TestFirst";
            generalTestVol.VolMiddleName = "TestMiddle";
            generalTestVol.VolLastName = "TestLast";
            generalTestVol.ActiveFlg = true;
            generalTestVol.VolID = Guid.NewGuid();
            volBLL.InsertVolunteerContext(ref generalTestVol);

            sp_Vol_Address_BLL volAddress_bll = new sp_Vol_Address_BLL();
            primaryTestVolAddress = new sp_Vol_Address_DM();
            primaryTestVolAddress.AddrLine1 = "PrimaryLine1";
            primaryTestVolAddress.AddrLine2 = "PrimaryLine2";
            primaryTestVolAddress.AddrLine3 = "PrimaryLine3";
            primaryTestVolAddress.City = "PrimaryCity";
            primaryTestVolAddress.St = "PS";
            primaryTestVolAddress.Zip = 12345;
            primaryTestVolAddress.Zip4 = 6789;
            primaryTestVolAddress.VolID = generalTestVol.VolID;
            primaryTestVolAddress.ActiveFlg = true;
            primaryTestVolAddress.PrimaryAddr = true;

            primaryTestVolAddr = new sp_Vol_Addr_DM();
            primaryTestVolAddr.VolID = generalTestVol.VolID;
            primaryTestVolAddr.PrimaryAddr = true;

            volAddress_bll.InsertAddressContext(ref primaryTestVolAddress, ref primaryTestVolAddr);

            secondaryTestVolAddress = new sp_Vol_Address_DM();
            secondaryTestVolAddress.AddrLine1 = "SecondaryLine1";
            secondaryTestVolAddress.AddrLine2 = "SecondaryLine2";
            secondaryTestVolAddress.AddrLine3 = "SecondaryLine3";
            secondaryTestVolAddress.City = "SecondaryCity";
            secondaryTestVolAddress.St = "SS";
            secondaryTestVolAddress.Zip = 98765;
            secondaryTestVolAddress.Zip4 = 4321;
            secondaryTestVolAddress.VolID = generalTestVol.VolID;
            secondaryTestVolAddress.ActiveFlg = true;
            secondaryTestVolAddress.PrimaryAddr = false;

            secondaryTestVolAddr = new sp_Vol_Addr_DM();
            secondaryTestVolAddr.VolID = generalTestVol.VolID;
            secondaryTestVolAddr.PrimaryAddr = false;
            volAddress_bll.InsertAddressContext(ref secondaryTestVolAddress, ref secondaryTestVolAddr);
        }

        [TestMethod]
        public void TestVolAddressRead()
        {
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "VolAddress.xlsx"));
            List<sp_Vol_Address_DM> excelDMs = getVolAddressDMs(dt);
            sp_Vol_Address_BLL volAddress_bll = new sp_Vol_Address_BLL();

            foreach (sp_Vol_Address_DM testVolAddress in excelDMs)
            {
                sp_Vol_Address_DM selectedVolAddress = volAddress_bll.ListAddress(testVolAddress);
                Assert.IsTrue(AddressEquals(selectedVolAddress, testVolAddress));
            }
        }

        [TestMethod]
        public void TestVolAddressReadAll()
        {
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "VolAddress.xlsx"));
            List<sp_Vol_Address_DM> excelDMs = getVolAddressDMs(dt);
            sp_Vol_Address_BLL volAddress_bll = new sp_Vol_Address_BLL();

            foreach (sp_Vol_Address_DM testVolAddress in excelDMs)
            {
                List<sp_Vol_Address_DM> selectedVolAddresses = volAddress_bll.ListAddresses(testVolAddress);
                Assert.IsTrue(AddressListContains(selectedVolAddresses, testVolAddress));
            }
        }

        [TestMethod]
        public void TestVolAddressCreate()
        {

            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            sp_Volunteer_DM vol_dm = new sp_Volunteer_DM();
            vol_dm.VolFirstName = "createFirst";
            vol_dm.VolMiddleName = "createMiddle";
            vol_dm.VolLastName = "createLast";
            vol_dm.ActiveFlg = true;
            System.Guid volID = Guid.NewGuid();
            vol_dm.VolID = volID;
            createTestVol = vol_dm;
            vol_bll.InsertVolunteerContext(ref vol_dm);

            string volAddr1 = "CreateLine1";
            string volAddr2 = "CreateLine2";
            string volAddr3 = "CreateLine3";
            string volCity = "CreateCity";
            string volSt = "CS";
            int volZip = 13579;
            int volZip4 = 2468;
            bool PrimaryFlg = true;
            bool ActiveFlg = true;
            sp_Vol_Address_BLL volAddress_bll = new sp_Vol_Address_BLL();
            sp_Vol_Address_DM volAddress_dm = new sp_Vol_Address_DM();
            sp_Vol_Addr_DM volAddr_dm = new sp_Vol_Addr_DM();

            volAddress_dm.ActiveFlg = ActiveFlg;
            volAddress_dm.AddrLine1 = volAddr1;
            volAddress_dm.AddrLine2 = volAddr2;
            volAddress_dm.AddrLine3 = volAddr3;
            volAddress_dm.City = volCity;
            volAddress_dm.St = volSt;
            volAddress_dm.Zip = volZip;
            volAddress_dm.Zip4 = volZip4;
            volAddress_dm.VolID = volID;
            volAddress_dm.PrimaryAddr = PrimaryFlg;

            volAddr_dm.PrimaryAddr = PrimaryFlg;
            volAddr_dm.VolID = volID;

            volAddress_bll.InsertAddressContext(ref volAddress_dm, ref volAddr_dm);

            sp_Vol_Address_DM volAddressDMs_selected = volAddress_bll.ListAddress(volAddress_dm);
            Assert.IsTrue(AddressEquals(volAddressDMs_selected, volAddress_dm));

        }

        [TestMethod]
        public void TestVolAddressPrimaryRead()
        {

            sp_Vol_Address_BLL volAddressBLL = new sp_Vol_Address_BLL();
            sp_Vol_Address_DM volAddressDM_selected = volAddressBLL.ListPrimaryAddress(primaryTestVolAddress);
            Assert.IsTrue(AddressEquals(primaryTestVolAddress, volAddressDM_selected));

            volAddressDM_selected = volAddressBLL.ListPrimaryAddress(secondaryTestVolAddress);
            Assert.IsTrue(AddressEquals(primaryTestVolAddress, volAddressDM_selected));

        }

        [TestMethod]
        public void TestVolAddressUpdate()
        {

            sp_Vol_Address_BLL volAddressBLL = new sp_Vol_Address_BLL();
            sp_Vol_Address_DM updateAddress = volAddressBLL.ListPrimaryAddress(primaryTestVolAddress);

            String newAddr1 = "UpdateLine1";
            String newAddr2 = "UpdateLine2";
            String newAddr3 = "UpdateLine3";
            String newCity = "UpdateCity";
            String newSt = "US";
            int newZip = 18642;
            int newZip4 = 9753;

            updateAddress.AddrLine1 = newAddr1;
            updateAddress.AddrLine2 = newAddr2;
            updateAddress.AddrLine3 = newAddr3;
            updateAddress.City = newCity;
            updateAddress.St = newSt;
            updateAddress.Zip = newZip;
            updateAddress.Zip4 = newZip4;

            primaryTestVolAddress = updateAddress;

            volAddressBLL.UpdateAddressContext(updateAddress,primaryTestVolAddr);
            sp_Vol_Address_DM selectedAddress = volAddressBLL.ListPrimaryAddress(updateAddress);

            sp_Vol_Address_DM DMToSelectAll = new sp_Vol_Address_DM();
            DMToSelectAll.VolID = selectedAddress.VolID;
            List<sp_Vol_Address_DM> selectedAddressList = volAddressBLL.ListAddresses(DMToSelectAll);

            Assert.IsTrue(AddressListContains(selectedAddressList, updateAddress));
            Assert.IsTrue(AddressListContains(selectedAddressList, secondaryTestVolAddress));
            Assert.IsTrue(AddressEquals(selectedAddress, updateAddress));
            Assert.AreEqual(newAddr1, selectedAddress.AddrLine1);
            Assert.AreEqual(newAddr2, selectedAddress.AddrLine2);
            Assert.AreEqual(newAddr3, selectedAddress.AddrLine3);
            Assert.AreEqual(newCity, selectedAddress.City);
            Assert.AreEqual(newSt, selectedAddress.St);
            Assert.AreEqual(newZip, selectedAddress.Zip);
            Assert.AreEqual(newZip4, selectedAddress.Zip4);

        }

        [TestMethod]
        public void TestVolAddressDelete()
        {

            sp_Vol_Address_BLL volAddress_bll = new sp_Vol_Address_BLL();
            volAddress_bll.DeleteAddressContext(primaryTestVolAddress,primaryTestVolAddr);
            sp_Vol_Address_DM selectedVolAddress = volAddress_bll.ListAddress(primaryTestVolAddress);

            Assert.IsNull(selectedVolAddress);
            //Impossible to get it back using stored procedures since the joining entry 
            //in VolAddr is missing. You'd have to do a direct sql query to test this.
            //Assert.IsNotNull(selectedVolAddress.ActiveFlg);
            //Assert.IsFalse(selectedVolAddress.ActiveFlg == true);
            //Assert.IsTrue(selectedVolAddress.ActiveFlg == false);
        }

        [ClassCleanup]
        public static void RemoveVolAddressData()
        {
            sp_Vol_Address_BLL volAddressBLL = new sp_Vol_Address_BLL();
            volAddressBLL.DeleteAddressContext(secondaryTestVolAddress, secondaryTestVolAddr);
            volAddressBLL.DeleteAddressContext(primaryTestVolAddress, primaryTestVolAddr);
            //volAddressBLL.DeleteAddressContext(createTestVolAddress, createTestVolAddr);

            sp_Volunteer_BLL volBLL = new sp_Volunteer_BLL();
            volBLL.DeleteVolunteerContext(generalTestVol);
            if (createTestVol != null)
                volBLL.DeleteVolunteerContext(createTestVol);

            cExcel.RemoveData(ExcelFilenames);
        }

    }
}
