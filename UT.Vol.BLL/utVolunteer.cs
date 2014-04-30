using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Vol.BLL.HelperMethods;
using System.Data;
using System.IO;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utVolunteer
    {
        static string CWorkbook = "Volunteer.xlsx";

        [ClassInitialize]
        public static void GetCWorkbook(TestContext testContext)
        {
            string exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string helperFilesDir = Path.GetFullPath(Path.Combine(exeDir, "..\\..\\HelperFiles\\"));
            CWorkbook = Path.Combine(helperFilesDir, CWorkbook);
        }

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

        [TestMethod]
        public void TestVolunteer()
        {

            DataTable dt = new DataTable();
            cExcel _cExcel = new cExcel();
            string strSheetName = "Volunteer";

            dt = _cExcel.ReadExcelFile(strSheetName, CWorkbook);

            // listVolunteers()

            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {

                string strFirstName = row["FirstName"].ToString();
                string strMiddleName = row["MiddleName"].ToString();
                string strLastName = row["LastName"].ToString();

                sp_Volunteer_DM insertVol = new sp_Volunteer_DM();
                sp_Volunteer_DM selectVol = new sp_Volunteer_DM();

                hVolunteer hVol = new hVolunteer();
                insertVol = hVol.hCreateVolunteer(strFirstName, strMiddleName, strLastName);

                selectVol = hVol.hSelectVolunteer(insertVol.VolID);

                Assert.AreEqual(insertVol.VolFirstName, selectVol.VolFirstName);
                Assert.AreEqual(insertVol.VolMiddleName, selectVol.VolMiddleName);
                Assert.AreEqual(insertVol.VolLastName, selectVol.VolLastName);

                hVol.hUpdateVolunteer(insertVol, "testFirst", "testMiddle", "testLast");
                selectVol = hVol.hSelectVolunteer(insertVol.VolID);

                Assert.AreEqual(selectVol.VolFirstName,"testFirst");
                Assert.AreEqual(selectVol.VolMiddleName,"testMiddle");
                Assert.AreEqual(selectVol.VolLastName,"testLast");

                hVol.hDeleteVolunteer(insertVol);
                selectVol = hVol.hSelectVolunteer(insertVol.VolID);

                Assert.AreEqual(selectVol.ActiveFlg, false);

            }
        }

        [TestMethod]
        public void TestVolPhone()
        {

            DataTable dt = new DataTable();
            cExcel _cExcel = new cExcel();
            string strSheetName = "VolPhone";

            dt = _cExcel.ReadExcelFile(strSheetName, CWorkbook);

            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {

                string strFirstName = row["FirstName"].ToString();
                string strMiddleName = row["MiddleName"].ToString();
                string strLastName = row["LastName"].ToString();
                string phoneNumber = row["PhoneNumber"].ToString();
                string secondNumber = row["SecondPhone"].ToString();
                string thirdNumber = row["ThirdPhone"].ToString();

                sp_Volunteer_DM testVol = new sp_Volunteer_DM();
                sp_Phone_DM primaryPhone = new sp_Phone_DM();
                sp_Phone_DM secondPhone = new sp_Phone_DM();
                sp_Phone_DM thirdPhone = new sp_Phone_DM();
                sp_Phone_DM selectPhone = new sp_Phone_DM();
                List<sp_Phone_DM> phoneList = new List<sp_Phone_DM>();

                hVolunteer hVol = new hVolunteer();
                testVol = hVol.hCreateVolunteer(strFirstName, strMiddleName, strLastName);

                hVolPhone hPhone = new hVolPhone();
                primaryPhone = hPhone.hCreateVolPhone(phoneNumber, testVol.VolID,true);
                secondPhone = hPhone.hCreateVolPhone(secondNumber, testVol.VolID, false);
                thirdPhone = hPhone.hCreateVolPhone(thirdNumber, testVol.VolID, false);

                phoneList = hPhone.hSelectVolPhone(testVol.VolID,primaryPhone.PhoneID);
                Assert.IsTrue(phoneList.Contains(primaryPhone));
                Assert.IsTrue(phoneList.Contains(secondPhone));
                Assert.IsTrue(phoneList.Contains(thirdPhone));

                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID,primaryPhone.PhoneID);
                Assert.AreEqual(primaryPhone.PhoneNbr, selectPhone.PhoneNbr);
                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID,secondPhone.PhoneID);
                Assert.AreEqual(primaryPhone.PhoneNbr, selectPhone.PhoneNbr);
                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID,thirdPhone.PhoneID);
                Assert.AreEqual(primaryPhone.PhoneNbr, selectPhone.PhoneNbr);

                hPhone.hUpdateVolPhone(primaryPhone, "3335557777",true);
                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID,primaryPhone.PhoneID);
                Assert.AreEqual(selectPhone.PhoneNbr, "3335557777");

                hPhone.hUpdateVolPhone(primaryPhone, primaryPhone.PhoneNbr, false);
                hPhone.hUpdateVolPhone(secondPhone, secondPhone.PhoneNbr, true);
                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID, thirdPhone.PhoneID);
                Assert.AreEqual(selectPhone.PhoneNbr, secondPhone.PhoneNbr);

                hPhone.hUpdateVolPhone(primaryPhone, primaryPhone.PhoneNbr, true);
                hPhone.hUpdateVolPhone(secondPhone, secondPhone.PhoneNbr, false);
                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID, thirdPhone.PhoneID);
                Assert.AreEqual(selectPhone.PhoneNbr, primaryPhone.PhoneNbr);

                hPhone.hDeleteVolPhone(primaryPhone);
                selectPhone = hPhone.hSelectPrimaryVolPhone(testVol.VolID,primaryPhone.PhoneID);
                Assert.AreEqual(selectPhone.ActiveFlg, false);

                hPhone.hDeleteVolPhone(secondPhone);
                hPhone.hDeleteVolPhone(thirdPhone);
                hVol.hDeleteVolunteer(testVol);

            }
        }

        [TestMethod]
        public void TestVolEmail()
        {

            DataTable dt = new DataTable();
            cExcel _cExcel = new cExcel();
            string strSheetName = "VolEmail";

            dt = _cExcel.ReadExcelFile(strSheetName, CWorkbook);

            // listVolEmails()

            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {

                string strFirstName = row["FirstName"].ToString();
                string strMiddleName = row["MiddleName"].ToString();
                string strLastName = row["LastName"].ToString();
                string emailAddress = row["EmailAddress"].ToString();

                sp_Volunteer_DM testVol = new sp_Volunteer_DM();
                sp_Email_DM insertEmail = new sp_Email_DM();
                sp_Email_DM selectEmail = new sp_Email_DM();

                hVolunteer hVol = new hVolunteer();
                testVol = hVol.hCreateVolunteer(strFirstName, strMiddleName, strLastName);

                hVolEmail hEmail = new hVolEmail();
                insertEmail = hEmail.hCreateVolEmail(emailAddress, testVol.VolID);

               // selectEmail = hEmail.hSelectVolEmail(insertEmail.EmailID);

                Assert.AreEqual(insertEmail.EmailAddr, selectEmail.EmailAddr);

                hEmail.hUpdateVolEmail(insertEmail, "testing@tes.test");
               // selectEmail = hEmail.hSelectVolEmail(insertEmail.EmailID);

                Assert.AreEqual(selectEmail.EmailAddr, "testing@tes.test");

                hEmail.hDeleteVolEmail(insertEmail);
               // selectEmail = hEmail.hSelectVolEmail(insertEmail.EmailID);

                Assert.AreEqual(selectEmail.ActiveFlg, false);

                hVol.hDeleteVolunteer(testVol);

            }
        }

    }
}
