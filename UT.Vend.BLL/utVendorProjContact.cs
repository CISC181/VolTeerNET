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
    public class utVendorProjContact
    {
        static string[] ExcelFilenames = new string[] {
            "Vendor.xlsx",
            "VendAddress.xlsx",
            "VendorAddr.xlsx",
            "Project.xlsx",
            "Contact.xlsx",
            "tblVendContact.xlsx", 
            "tblVendorProjContact.xlsx"
        };


        [ClassInitialize]
        public static void InsertVendorProjContactData(TestContext testContext)
        {
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestVendorProjContactRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "tblVendorProjContact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string vendorID = row["VendorID"].ToString();
                string projectID = row["ProjectID"].ToString();
                string contactID = row["ContactID"].ToString();
                sp_VendorProjContact_BLL contact = new sp_VendorProjContact_BLL();
                sp_VendorProjContact_DM data = contact.ListContact(new Guid(vendorID), new Guid(projectID), new Guid(contactID));
                Assert.AreEqual(Convert.ToBoolean(row["PrimaryContact"]), data.PrimaryContact, "Primary Contact Not Set As Expected");
                
            }
        }

        [TestMethod]

        public void TestVendorProjContactUpdate()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "tblVendorProjContact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                bool updatePrimaryContact = Convert.ToBoolean(row["PrimaryContact"]);
                string contactID = row["ContactID"].ToString();
                string vendorID = row["VendorID"].ToString();
                string projectID = row["ProjectID"].ToString();
                sp_VendorProjContact_DM data = new sp_VendorProjContact_DM();
                data.ContactID = new Guid(contactID);
                data.PrimaryContact = updatePrimaryContact;
                sp_VendorProjContact_BLL VendorProjContact = new sp_VendorProjContact_BLL();
                VendorProjContact.UpdateContactContext(data);
                data = VendorProjContact.ListContact(new Guid(vendorID), new Guid(projectID), new Guid(contactID));
                Assert.AreEqual(updatePrimaryContact, data.PrimaryContact, "Primary Contact Not Set As Expected");

            }
        }

        [TestMethod]

        public void TestVendorProjContactDelete()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "tblVendorProjContact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                Guid VendorID = new Guid(row["VendorID"].ToString());
                Guid ProjectID = new Guid(row["ProjectID"].ToString());
                Guid ContactID = new Guid(row["ContactID"].ToString());
                sp_VendorProjContact_DM data = new sp_VendorProjContact_DM();
                sp_VendorProjContact_BLL vend = new sp_VendorProjContact_BLL();
                data.VendorID = VendorID;
                data.ProjectID = ProjectID;
                data.ContactID = ContactID;
                vend.DeleteContactContext(data);
                data = vend.ListContact(VendorID, ProjectID, ContactID);
                Assert.AreEqual(false, data.PrimaryContact, "PrimaryContact not set as expected");
            }
        }

        [TestMethod]

        public void TestVendorProjContactInsert()
        {
            //Test Our Read
            sp_VendorProjContact_DM data = new sp_VendorProjContact_DM();
            data.VendorID = new Guid();
            bool insertPrimaryContact = true;
            data.PrimaryContact = insertPrimaryContact;
            sp_VendorProjContact_BLL contact = new sp_VendorProjContact_BLL();
            contact.InsertContactContext(data);
            Assert.AreEqual(insertPrimaryContact, data.PrimaryContact, "Primary Contact Not Set As Expected");
        }

        [ClassCleanup]

        public static void RemoveVendorProjContactData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}