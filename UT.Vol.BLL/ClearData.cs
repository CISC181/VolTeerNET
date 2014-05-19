using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using UT.Helper;

namespace UT.Volteer.BLL
{
    [TestClass]
    class ClearData
    {

        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx",
            "Skill.xlsx",
            "Group.xlsx",
            "VolAddress.xlsx",
            "VolAddr.xlsx",
            "VolEmail.xlsx",
            "VolPhone.xlsx",
            "VolSkill.xlsx",
            "VolState.xlsx",
            "GroupAddr.xlsx",
            "GroupVol.xlsx"
        };

        [TestMethod]
        public static void ClearAllVolData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveData(ExcelFilenames);
            Assert.IsTrue(true);
        }
    }
}
