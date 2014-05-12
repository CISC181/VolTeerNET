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
            cExcel.InsertData(ExcelFilenames);
            
        }

        [TestMethod]
        public void TestContactRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string contactID = row["ContactID"].ToString();
                sp_VendContact_BLL contact = new sp_VendContact_BLL();
                sp_VendContact_DM data = contact.ListContacts(new Guid(contactID));
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
                sp_VendContact_DM data = new sp_VendContact_DM();
                data.ContactID = new Guid(contactID);
                data.ContactFirstName = updateFirstName;
                data.ContactMiddleName = updateMiddleName;
                data.ContactLastName = updateLastName;
                sp_VendContact_BLL contact = new sp_VendContact_BLL();
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
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string contactID = row["ContactID"].ToString();
                sp_VendContact_DM data = new sp_VendContact_DM();
                data.ContactID = new Guid(contactID);
                sp_VendContact_BLL contact = new sp_VendContact_BLL();
                contact.DeleteContactContext(data);
                data = contact.ListContacts(new Guid(contactID));
                Assert.AreEqual(false, data.ActiveFlg, "ActiveFlag not set as expected");
            }
        }

        [TestMethod]
        public void TestContactInsert()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string contactID = row["ContactID"].ToString();
                sp_VendContact_DM data = new sp_VendContact_DM();
                data.ContactID = new Guid(contactID);
                sp_VendContact_BLL contact = new sp_VendContact_BLL();
                contact.DeleteContactContext(data);
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
