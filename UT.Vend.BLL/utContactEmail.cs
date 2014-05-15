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
    public class utContactEmail
    {
        static string[] ExcelFilenames = new string[] {
            "Contact.xlsx", "VendEmail.xlsx", "ContactEmail.xlsx"
        };

       

      

        [ClassInitialize]
        public static void InsertContactEmailData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);
            
        }


        [TestMethod]
        public void TestContactEmailCreate()
        {
            //Insert a Contact First
            sp_Contact_DM contact_dm = new sp_Contact_DM();
            contact_dm.ContactID = new Guid();
            sp_Contact_BLL contact_bll = new sp_Contact_BLL();
            contact_bll.InsertContactContext(ref contact_dm);

            //Insert an ContactEmail
            sp_ContactEmail_DM data = new sp_ContactEmail_DM();
            data.ContactID = contact_dm.ContactID;
            data.EmailID = 1;
            data.PrimaryEmail = true;
            sp_ContactEmail_BLL vendor = new sp_ContactEmail_BLL();
            vendor.InsertContactEmailContext(ref data);
            var newdata = vendor.ListContactEmails(data.ContactID, data.EmailID);
            Assert.AreEqual(data.ContactID, newdata.ContactID, "Contact ID Not Set As Expected");
            Assert.AreEqual(data.EmailID, newdata.EmailID, "Email ID Not Set As Expected");
            Assert.AreEqual(data.PrimaryEmail, newdata.PrimaryEmail, "PrimaryEmail Not Set As Expected");
        }

        [TestMethod]
        public void TestContactEmailReadAll()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "ContactEmail.xlsx"));
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblContactEmail]");

            //Pull our data from the DB through the BLL
            sp_ContactEmail_BLL contactEmails = new sp_ContactEmail_BLL();
            var allContactsEmails = contactEmails.ListContactEmails();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allContactsEmails.Count);
        }

        [TestMethod]
        public void TestContactEmailRead()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "ContactEmail.xlsx"));
                foreach (DataRow row in dt.Rows) // Loop over the rows.
                {
                    string contactID = row["ContactID"].ToString();
                    int emailID = Convert.ToInt32(row["EmailID"]);
                    sp_ContactEmail_BLL contact = new sp_ContactEmail_BLL();

                    var data = contact.ListContactEmails(new Guid(contactID), emailID);
                    Assert.AreEqual(row["ContactID"].ToString(), data.ContactID, "ContactID Not Set As Expected");
                    Assert.AreEqual(row["EmailID"].ToString(), data.EmailID, "EmailID Not Set As Expected");  
                }
        }

        [TestMethod]
        public void TestContactUpdate()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                bool primaryEmail = true;
                int emailID = Convert.ToInt32(row["EmailID"]);
                Guid contactID = new Guid( row["ContactID"].ToString());
                sp_ContactEmail_DM data = new sp_ContactEmail_DM();
                data.ContactID = contactID;
                data.EmailID = emailID;
                data.PrimaryEmail = primaryEmail;
                sp_ContactEmail_BLL contact = new sp_ContactEmail_BLL();
                contact.UpdateContactEmailContext(data);
                var newdata = contact.ListContactEmails();
                Assert.AreEqual(primaryEmail, newdata[0].PrimaryEmail, "PrimaryEmail Not Set As Expected");
                Assert.AreEqual(emailID, newdata[0].EmailID, "EmailID Not Set As Expected");
                Assert.AreEqual(contactID, newdata[0].ContactID, "ContactIDe Not Set As Expected");

            }
        }

        [TestMethod]
        public void TestContactEmailDelete()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "ContactEmail.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                Guid contactID = new Guid(row["ContactID"].ToString());
                int emailID = Convert.ToInt32(row["EmailID"]);
                sp_ContactEmail_DM data = new sp_ContactEmail_DM();
                data.EmailID = emailID;
                data.ContactID = contactID;
                sp_VendContactEmail_BLL contact = new sp_VendContactEmail_BLL();
                contact.DeleteContactContext(data);
                var newdata = contact.ListContacts(contactID, emailID);
            }
        }

       


        [ClassCleanup]
        public static void RemoveContactData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
