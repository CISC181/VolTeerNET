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
        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx", "VolPhone.xlsx"
        };

        /*[ClassInitialize]
        public static void InsertVolPhoneData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);
        }*/

        [TestMethod]
        public void TestVolPhone()
        {

            sp_Volunteer_DM testVol = new sp_Volunteer_DM();
            sp_Phone_DM primaryPhone = new sp_Phone_DM();
            sp_Phone_DM secondPhone = new sp_Phone_DM();
            sp_Phone_DM thirdPhone = new sp_Phone_DM();
            sp_Phone_DM selectPhone = new sp_Phone_DM();
            List<sp_Phone_DM> phoneList = new List<sp_Phone_DM>();
            List<string> numberList = new List<string>();
            List<int> idList = new List<int>();
            int numberPhones = 200;

            hVolunteer hVol = new hVolunteer();
            testVol = hVol.hCreateVolunteer("testName1","testName2","testName3");

            hVolPhone hPhone = new hVolPhone();
            primaryPhone = hPhone.hCreateVolPhone("1111111111", testVol.VolID,true,ref numberPhones);
            secondPhone = hPhone.hCreateVolPhone("2222222222", testVol.VolID, false,ref numberPhones);
            thirdPhone = hPhone.hCreateVolPhone("3333333333", testVol.VolID, false,ref numberPhones);

            phoneList = hPhone.hSelectVolPhone(primaryPhone);
            foreach(sp_Phone_DM phone in phoneList)
            {
                numberList.Add(phone.PhoneNbr);
                idList.Add(phone.PhoneID);
            }
            Assert.IsTrue(numberList.Contains(primaryPhone.PhoneNbr));
            Assert.IsTrue(numberList.Contains(secondPhone.PhoneNbr));
            Assert.IsTrue(numberList.Contains(thirdPhone.PhoneNbr));
            Assert.IsTrue(idList.Contains(primaryPhone.PhoneID));
            Assert.IsTrue(idList.Contains(secondPhone.PhoneID));
            Assert.IsTrue(idList.Contains(thirdPhone.PhoneID));
            numberList.Clear();
            idList.Clear();

            phoneList = hPhone.hSelectVolPhone(secondPhone);
            foreach(sp_Phone_DM phone in phoneList)
            {
                numberList.Add(phone.PhoneNbr);
                idList.Add(phone.PhoneID);
            }
            Assert.IsTrue(numberList.Contains(primaryPhone.PhoneNbr));
            Assert.IsTrue(numberList.Contains(secondPhone.PhoneNbr));
            Assert.IsTrue(numberList.Contains(thirdPhone.PhoneNbr));
            Assert.IsTrue(idList.Contains(primaryPhone.PhoneID));
            Assert.IsTrue(idList.Contains(secondPhone.PhoneID));
            Assert.IsTrue(idList.Contains(thirdPhone.PhoneID));
            numberList.Clear();
            idList.Clear();

            phoneList = hPhone.hSelectVolPhone(thirdPhone);
            foreach(sp_Phone_DM phone in phoneList)
            {
                numberList.Add(phone.PhoneNbr);
                idList.Add(phone.PhoneID);
            }
            Assert.IsTrue(numberList.Contains(primaryPhone.PhoneNbr));
            Assert.IsTrue(numberList.Contains(secondPhone.PhoneNbr));
            Assert.IsTrue(numberList.Contains(thirdPhone.PhoneNbr));
            Assert.IsTrue(idList.Contains(primaryPhone.PhoneID));
            Assert.IsTrue(idList.Contains(secondPhone.PhoneID));
            Assert.IsTrue(idList.Contains(thirdPhone.PhoneID));
            numberList.Clear();
            idList.Clear();

            selectPhone = hPhone.hSelectPrimaryVolPhone(primaryPhone);
            Assert.AreEqual(primaryPhone.PhoneNbr, selectPhone.PhoneNbr);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.ActiveFlg, selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);
            
            selectPhone = hPhone.hSelectPrimaryVolPhone(secondPhone);
            Assert.AreEqual(primaryPhone.PhoneNbr, selectPhone.PhoneNbr);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.ActiveFlg, selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);

            selectPhone = hPhone.hSelectPrimaryVolPhone(thirdPhone);
            Assert.AreEqual(primaryPhone.PhoneNbr, selectPhone.PhoneNbr);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.ActiveFlg, selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);

            hPhone.hUpdateVolPhone(primaryPhone, "3335557777",true);
            selectPhone = hPhone.hSelectPrimaryVolPhone(primaryPhone);
            Assert.AreEqual("3335557777",selectPhone.PhoneNbr);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);
            Assert.AreEqual(primaryPhone.ActiveFlg, selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);


            hPhone.hUpdateVolPhone(primaryPhone, primaryPhone.PhoneNbr, false);
            hPhone.hUpdateVolPhone(secondPhone, secondPhone.PhoneNbr, true);
            selectPhone = hPhone.hSelectPrimaryVolPhone(primaryPhone);
            Assert.AreEqual(secondPhone.PhoneNbr,selectPhone.PhoneNbr);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);
            Assert.AreEqual(secondPhone.ActiveFlg, selectPhone.ActiveFlg);
            Assert.AreEqual(secondPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(secondPhone.VolID, selectPhone.VolID);

            hPhone.hUpdateVolPhone(primaryPhone, primaryPhone.PhoneNbr, true);
            hPhone.hUpdateVolPhone(secondPhone, secondPhone.PhoneNbr, false);
            selectPhone = hPhone.hSelectPrimaryVolPhone(thirdPhone);
            Assert.AreEqual(primaryPhone.PhoneNbr,selectPhone.PhoneNbr);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);
            Assert.AreEqual(primaryPhone.ActiveFlg, selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);

            hPhone.hDeleteVolPhone(primaryPhone);
            selectPhone = hPhone.hSelectPrimaryVolPhone(primaryPhone);
            Assert.AreEqual(primaryPhone.PhoneNbr,selectPhone.PhoneNbr);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);
            Assert.AreEqual(false,selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);

            hPhone.hDeleteVolPhone(secondPhone);
            hPhone.hDeleteVolPhone(thirdPhone);
            hVol.hDeleteVolunteer(testVol);

        }

        /*[ClassCleanup]
        public static void RemoveVolPhoneData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }*/

    }
}
