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
        public void TestContact()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "Contact.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string contactID = row["ContactID"].ToString();
                sp_VendContact_BLL contact = new sp_VendContact_BLL();
                sp_VendContact_DM data = contact.ListContacts(new Guid(contactID));

            }

        }

        [ClassCleanup]
        public static void RemoveContactData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
