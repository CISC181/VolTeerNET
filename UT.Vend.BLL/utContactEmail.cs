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
        public void TestContactEmailRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "ContactEmail.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string contactID = row["ContactID"].ToString();
                sp_VendContactEmail_BLL contact = new sp_VendContactEmail_BLL();
                sp_ContactEmail_DM data = contact.ListContacts(new Guid(contactID));
                Assert.AreEqual(row["ContactID"].ToString(), data.ContactID, "ContactID Not Set As Expected");
                Assert.AreEqual(row["EmailID"].ToString(), data.EmailID, "EmailID Not Set As Expected");  
            }
        }

        [TestMethod]
        public void TestContactEmailUpdate()
        {
            //@TODO - DAL Implemented
        }

        [TestMethod]
        public void TestContactEmailDelete()
        {
            //@TODO - DAL Implemented
        }

        [TestMethod]
        public void TestContactEmailInsert()
        {
            //@TODO - DAL Implemented
        }


        [ClassCleanup]
        public static void RemoveContactData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
