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
    public class UTVendEmail
    {
        static string[] ExcelFilenames = new string[] {
            "tblVendEmail.xlsx"
        };

       /* private static bool Equals(sp_VendEmail_DM dm1, sp_VendEmail_DM dm2)
        {
            return (dm1.EmailID == dm2.EmailID &&
                    dm1.EmailAddr == dm2.EmailAddr &&
                    dm1.ActiveFlg == dm2.ActiveFlg
                );
        }

        private static List<sp_VendEmail_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_VendEmail_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnVendEmail = new sp_VendEmail_DM();
                returnVendEmail.EmailID = new Guid((string)dataTable.Rows[i]["EmailID"]);
                returnVendEmail.EmailAddr = new Guid((String)dataTable.Rows[i]["EmailAddr"]);
                returnVendEmail.StartDateTime = Convert.ToDateTime(dataTable.Rows[i]["StartDateTime"]);
                returnVendEmail.EndDateTime = Convert.ToDateTime(dataTable.Rows[i]["EndDateTime"]);
       
                DMs.Add(returnVendEmail);
            }
            return DMs;
        }
        */

        [ClassInitialize]
        public static void InsertVendEmailData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);

        }

        [TestMethod]
        public void TestVendEmailRead()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "tblVendEmail.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                int EmailID = Convert.ToInt32(row["EmailID"].ToString());
                sp_VendEmail_BLL vend = new sp_VendEmail_BLL();
                sp_VendEmail_DM data = vend.ListEmails(EmailID);
                Assert.AreEqual(row["EmailAddr"].ToString(), data.EmailAddr, "EmailAddr Not Set As Expected");

            }
            
        } 

        [TestMethod]
        public void TestVendEmailUpdate()
        {
            //Test Our Read
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "tblVendEmail.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                string EmailAddr = "TestEmailAddr@test.com";

                int EmailID = Convert.ToInt32(row["EmailID"].ToString());
                sp_VendEmail_DM data = new sp_VendEmail_DM();
                data.EmailID = EmailID;
                data.EmailAddr = EmailAddr;
                sp_VendEmail_BLL vend = new sp_VendEmail_BLL();
                vend.UpdateEmailContext(data);
                data = vend.ListEmails(EmailID);
                Assert.AreEqual(EmailAddr, data.EmailAddr, "EmailAddr Not Set As Expected");

            }
        }

        [TestMethod]
        public void TestVendEmailDelete()
        {
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(cExcel.GetHelperFilesDir(), "tblVendEmail.xlsx"));
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                int EmailID = Convert.ToInt32(row["EmailID"].ToString());
                sp_VendEmail_DM data = new sp_VendEmail_DM();
                sp_VendEmail_BLL vend = new sp_VendEmail_BLL();
                data.EmailID = EmailID;
                vend.DeleteEmailContext(data);
                data = vend.ListEmails(EmailID);
                Assert.AreEqual(false, data.ActiveFlg, "ActiveFlag not set as expected");
            }
        }

        [TestMethod]
        public void TestVendEmailInsert()
        {
            //Test Our Read
            sp_VendEmail_DM data = new sp_VendEmail_DM();
            string EmailAddr = "Email1@test.com";

            data.EmailAddr = EmailAddr;
            data.ActiveFlg = true;
            sp_VendEmail_BLL vend = new sp_VendEmail_BLL();
            vend.InsertEmailContext(data);
            Assert.AreEqual(EmailAddr, data.EmailAddr, "EmailAddr Not Set As Expected");

        }

        [ClassCleanup]
        public static void RemoveVendEmailData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}

