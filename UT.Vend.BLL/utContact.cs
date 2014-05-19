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
    public class utContact
    {
        static string[] ExcelFilenames = new string[] {
            "Contact.xlsx", "VendEmail.xlsx", "ContactEmail.xlsx"
        };

        [ClassInitialize]
        public static void InsertContactData(TestContext testContext)
        {
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);  
        }

        [TestMethod]
        public void TestContactCreate()
        {
            sp_Contact_DM data = new sp_Contact_DM();
            data.ContactID = new Guid();
            string insertFirstName = "A";
            string insertMiddleName = "J";
            string insertLastName = "Riz";
            data.ContactFirstName = insertFirstName;
            data.ContactMiddleName = insertMiddleName;
            data.ContactLastName = insertLastName;
            data.ActiveFlg = true;
            sp_Contact_BLL contact = new sp_Contact_BLL();
            contact.InsertContactContext(ref data);
            Assert.AreEqual(insertFirstName, data.ContactFirstName, "Contact First Name Not Set As Expected");
            Assert.AreEqual(insertMiddleName, data.ContactMiddleName, "Contact Middle Name Not Set As Expected");
            Assert.AreEqual(insertLastName, data.ContactLastName, "Contact Last Name Not Set As Expected");
        }

        [TestMethod]
        public void TestContactReadAll()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "Contact.xlsx"));
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblContact]");

            //Pull our data from the DB through the BLL
            sp_Contact_BLL contact = new sp_Contact_BLL();
            var allContacts = contact.ListContacts();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allContacts.Count);
        }

        [TestMethod]
        public void TestContactRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string contactID = row["ContactID"].ToString();
                sp_Contact_BLL contact = new sp_Contact_BLL();
                sp_Contact_DM data = contact.ListContacts(new Guid(contactID));
                Assert.AreEqual(row["ContactFirstName"].ToString(), data.ContactFirstName, "Contact First Name Not Set As Expected");
                Assert.AreEqual(row["ContactMiddleName"].ToString(), data.ContactMiddleName, "Contact Middle Name Not Set As Expected");
                Assert.AreEqual(row["ContactLastName"].ToString(), data.ContactLastName, "Contact Last Name Not Set As Expected");
            }
        }

        [TestMethod]
        public void TestContactUpdate()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string updateFirstName = "TestFirstName";
                string updateMiddleName = "TestMiddleName";
                string updateLastName = "TestLastName";
                string contactID = row["ContactID"].ToString();
                sp_Contact_DM data = new sp_Contact_DM();
                data.ContactID = new Guid(contactID);
                data.ContactFirstName = updateFirstName;
                data.ContactMiddleName = updateMiddleName;
                data.ContactLastName = updateLastName;
                sp_Contact_BLL contact = new sp_Contact_BLL();
                contact.UpdateContactContext(data);
                data = contact.ListContacts(new Guid(contactID));
                Assert.AreEqual(updateFirstName, data.ContactFirstName, "Contact First Name Not Set As Expected");
                Assert.AreEqual(updateMiddleName, data.ContactMiddleName, "Contact Middle Name Not Set As Expected");
                Assert.AreEqual(updateLastName, data.ContactLastName, "Contact Last Name Not Set As Expected");
                
            }
        }

            [TestMethod]
            public void TestContactDelete()
            {
                DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
                foreach (DataRow row in dt.Rows) // Loop over the rows.
                {
                    string contactID = row["ContactID"].ToString();
                    sp_Contact_DM data = new sp_Contact_DM();
                    data.ContactID = new Guid(contactID);
                    sp_Contact_BLL contact = new sp_Contact_BLL();
                    contact.DeleteContactContext(data.ContactID);
                    data = contact.ListContacts(new Guid(contactID));
                    Assert.AreEqual(false, data.ActiveFlg, "ActiveFlag not set as expected");
                }
            }

        


        [ClassCleanup]
        public static void RemoveContactData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
