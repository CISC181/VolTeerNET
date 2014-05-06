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
using UT.Vend.BLL.HelperMethods;

namespace UT.Vend.BLL
{
    [TestClass]
    public class utProject
    {

        static string[] ExcelFilenames = new string[] {
            "Project.xlsx",
            "ProjectEvent.xlsx"
        };


        [ClassInitialize]
        public void initializeProject()
        {
        }

        [TestMethod]
        public void TestProject()
        {
        }

        [ClassCleanup]
        public void postRun()
        {
        }
    }
}
