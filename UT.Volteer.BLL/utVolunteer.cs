using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Volteer.BLL.HelperMethods;
using System.Data;

namespace UT.Volteer.BLL
{
    [TestClass]
    public class utVolunteer
    {
        const string CWorkbook = "C:\\Users\\Dad\\Source\\Repos\\VolTeerNET\\UT.Volteer.BLL\\UTTestFiles\\Volunteer.xlsx";

        [TestMethod]
        public void CreateVolunteer()
        {

            DataTable dt = new DataTable();
            cExcel _cExcel = new cExcel();
            string strSheetName = "Volunteer"; 

            dt = _cExcel.ReadExcelFile(strSheetName, CWorkbook);

            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {

                Console.WriteLine("--- Row ---"); // Print separator.
                string strFirstName = row["FirstName"].ToString();
                string strMiddleName = row["MiddleName"].ToString();
                string strLastName = row["LastName"].ToString();
                
                sp_Volunteer_DM insertVol = new sp_Volunteer_DM();
                sp_Volunteer_DM selectVol = new sp_Volunteer_DM();

                hVolunteer hVol = new hVolunteer();
                insertVol = hVol.hCreateVolunteer(strFirstName,strMiddleName,strLastName);


                selectVol = hVol.hSelectVolunteer(insertVol.VolID);

                Assert.AreEqual(insertVol.VolFirstName, selectVol.VolFirstName);
                Assert.AreEqual(insertVol.VolMiddleName, selectVol.VolMiddleName);
                Assert.AreEqual(insertVol.VolLastName, selectVol.VolLastName);

                Console.WriteLine(insertVol.VolID);
                System.Diagnostics.Debug.Write(insertVol.VolID);
            }



        }
    }
}
