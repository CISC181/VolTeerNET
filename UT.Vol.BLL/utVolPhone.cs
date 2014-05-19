using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Vol.BLL.HelperMethods;
using System.Data;
using System.IO;
using UT.Helper;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utVolPhone
    {
        static sp_Volunteer_DM createTestVol;
        static sp_Volunteer_DM generalTestVol;

        static sp_Phone_DM createTestVolPhone;
        static sp_Phone_DM primaryTestVolPhone;
        static sp_Phone_DM secondaryTestVolPhone;

        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx", "VolPhone.xlsx"
        };

        private static bool PhoneEquals(sp_Phone_DM dm1, sp_Phone_DM dm2)
        {
            return ((dm1.ActiveFlg == dm2.ActiveFlg) &&
                (dm1.PhoneNbr == dm2.PhoneNbr) &&
                (dm1.PhoneID == dm2.PhoneID) &&
                (dm1.PrimaryFlg == dm2.PrimaryFlg) &&
                (dm1.VolID == dm2.VolID));
        }

        private static bool PhoneListContains(List<sp_Phone_DM> phoneList, sp_Phone_DM phone)
        {

            bool listContainsPhone = false;

            foreach (sp_Phone_DM currPhone in phoneList)
            {

                listContainsPhone = listContainsPhone || PhoneEquals(currPhone, phone);

            }

            return listContainsPhone;

        }

        private static List<sp_Phone_DM> getVolPhoneDMs(DataTable dataTable)
        {
            List<sp_Phone_DM> volPhoneDMs = new List<sp_Phone_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                sp_Phone_DM returnPhone = new sp_Phone_DM();
                returnPhone.VolID = new Guid((string)dataTable.Rows[i]["VolID"]);
                returnPhone.PhoneNbr = (String)dataTable.Rows[i]["PhoneNbr"];
                returnPhone.PrimaryFlg = Convert.ToBoolean(dataTable.Rows[i]["PrimaryFlg"]);
                returnPhone.PhoneID = Convert.ToInt32(dataTable.Rows[i]["PhoneID"]);
                returnPhone.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                volPhoneDMs.Add(returnPhone);
            }
            return volPhoneDMs;
        }

        [ClassInitialize]
        public static void InsertVolPhoneData(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);

            sp_Volunteer_BLL volBLL = new sp_Volunteer_BLL();
            generalTestVol = new sp_Volunteer_DM();
            generalTestVol.VolFirstName = "TestFirst";
            generalTestVol.VolMiddleName = "TestMiddle";
            generalTestVol.VolLastName = "TestLast";
            generalTestVol.ActiveFlg = true;
            System.Guid volID = volBLL.InsertVolunteerContext(ref generalTestVol).VolID;
            generalTestVol.VolID = volID;

            sp_VolPhone_BLL volPhone_bll = new sp_VolPhone_BLL();
            primaryTestVolPhone = new sp_Phone_DM();
            primaryTestVolPhone.PhoneNbr = "1357924680";
            primaryTestVolPhone.VolID = volID;
            primaryTestVolPhone.ActiveFlg = true;
            primaryTestVolPhone.PrimaryFlg = true;
            volPhone_bll.InsertPhoneContext(primaryTestVolPhone);

            secondaryTestVolPhone = new sp_Phone_DM();
            secondaryTestVolPhone.PhoneNbr = "2468013579";
            secondaryTestVolPhone.VolID = volID;
            secondaryTestVolPhone.ActiveFlg = true;
            secondaryTestVolPhone.PrimaryFlg = false;
            volPhone_bll.InsertPhoneContext(secondaryTestVolPhone);
        }

        [TestMethod]
        public void TestVolPhoneRead()
        {
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "VolPhone.xlsx"));
            List<sp_Phone_DM> excelDMs = getVolPhoneDMs(dt);
            sp_VolPhone_BLL volPhone_bll = new sp_VolPhone_BLL();

            foreach (sp_Phone_DM testVolPhone in excelDMs)
            {
                List<sp_Phone_DM> selectedVolPhones = volPhone_bll.ListPhones(testVolPhone);
                Assert.IsTrue(PhoneListContains(selectedVolPhones, testVolPhone));
            }
        }

        [TestMethod]
        public void TestVolPhoneCreate()
        {

            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            sp_Volunteer_DM vol_dm = new sp_Volunteer_DM();
            vol_dm.VolFirstName = "createFirst";
            vol_dm.VolMiddleName = "createMiddle";
            vol_dm.VolLastName = "createLast";
            vol_dm.ActiveFlg = true;
            System.Guid volID = vol_bll.InsertVolunteerContext(ref vol_dm).VolID;
            vol_dm.VolID = volID;
            createTestVol = vol_dm;

            string volPhoneNbr = "0123456789";
            bool PrimaryFlg = true;
            bool ActiveFlg = true;
            sp_VolPhone_BLL volPhone_bll = new sp_VolPhone_BLL();
            sp_Phone_DM volPhone_dm = new sp_Phone_DM();
            volPhone_dm.PhoneNbr = volPhoneNbr;
            volPhone_dm.VolID = volID;
            volPhone_dm.ActiveFlg = ActiveFlg;
            volPhone_dm.PrimaryFlg = PrimaryFlg;
            volPhone_bll.InsertPhoneContext(volPhone_dm);
            int volPhoneID = volPhone_dm.PhoneID;
            createTestVolPhone = volPhone_dm;

            List<sp_Phone_DM> volPhoneDMs_selected = volPhone_bll.ListPhones(volPhone_dm);
            Assert.IsTrue(PhoneListContains(volPhoneDMs_selected, volPhone_dm));

        }

        [TestMethod]
        public void TestVolPhonePrimaryRead()
        {

            sp_VolPhone_BLL volPhoneBLL = new sp_VolPhone_BLL();
            sp_Phone_DM volPhoneDM_selected = volPhoneBLL.ListPrimaryPhone(primaryTestVolPhone);
            Assert.IsTrue(PhoneEquals(primaryTestVolPhone, volPhoneDM_selected));

            volPhoneDM_selected = volPhoneBLL.ListPrimaryPhone(secondaryTestVolPhone);
            Assert.IsTrue(PhoneEquals(primaryTestVolPhone, volPhoneDM_selected));

        }

        [TestMethod]
        public void TestVolPhoneUpdate()
        {

            sp_VolPhone_BLL volPhoneBLL = new sp_VolPhone_BLL();
            sp_Phone_DM updatePhone = volPhoneBLL.ListPrimaryPhone(primaryTestVolPhone);
            String newPhoneNbr = "9876543210";
            updatePhone.PhoneNbr = newPhoneNbr;
            volPhoneBLL.UpdatePhoneNbr(updatePhone);
            sp_Phone_DM selectedPhone = volPhoneBLL.ListPrimaryPhone(updatePhone);
            List<sp_Phone_DM> selectedPhoneList = volPhoneBLL.ListPhones(updatePhone);

            Assert.IsTrue(PhoneListContains(selectedPhoneList, updatePhone));
            Assert.IsTrue(PhoneListContains(selectedPhoneList, secondaryTestVolPhone));
            Assert.IsTrue(PhoneEquals(selectedPhone, updatePhone));
            Assert.AreEqual(newPhoneNbr, selectedPhone.PhoneNbr);

        }

        [TestMethod]
        public void TestVolPhoneDelete()
        {

            sp_VolPhone_BLL volPhone_bll = new sp_VolPhone_BLL();
            volPhone_bll.DeletePhonesContext(primaryTestVolPhone);
            sp_Phone_DM selectedVolPhone = volPhone_bll.ListPrimaryPhone(primaryTestVolPhone);

            Assert.IsNotNull(selectedVolPhone.ActiveFlg);
            Assert.IsFalse(selectedVolPhone.ActiveFlg == true);
            Assert.IsTrue(selectedVolPhone.ActiveFlg == false);
        }

        [ClassCleanup]
        public static void RemoveVolPhoneData()
        {
            sp_VolPhone_BLL volPhoneBLL = new sp_VolPhone_BLL();
            volPhoneBLL.DeletePhonesContext(secondaryTestVolPhone);
            volPhoneBLL.DeletePhonesContext(primaryTestVolPhone);
            volPhoneBLL.DeletePhonesContext(createTestVolPhone);

            sp_Volunteer_BLL volBLL = new sp_Volunteer_BLL();
            volBLL.DeleteVolunteerContext(generalTestVol);
            volBLL.DeleteVolunteerContext(createTestVol);

            cExcel.RemoveData(ExcelFilenames);
        }

    }
}
