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
        }

        [ClassCleanup]
        public static void RemoveContactData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
