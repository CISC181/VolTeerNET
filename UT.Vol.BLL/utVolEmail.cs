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
    public class utVolEmail
    {
        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx", "VolEmail.xlsx"
        };

        /*[ClassInitialize]
        public static void InsertVolEmailData(TestContext testContext)
        {
            cExcel.InsertData(ExcelFilenames);
        }*/

        [TestMethod]
        public void TestVolEmail()
        {

            sp_Volunteer_DM testVol = new sp_Volunteer_DM();
            sp_Email_DM primaryEmail = new sp_Email_DM();
            sp_Email_DM secondEmail = new sp_Email_DM();
            sp_Email_DM thirdEmail = new sp_Email_DM();
            sp_Email_DM selectEmail = new sp_Email_DM();
            List<sp_Email_DM> emailList = new List<sp_Email_DM>();
            List<string> addressList = new List<string>();
            List<int> idList = new List<int>();
            int numberEmails = 300;

            hVolunteer hVol = new hVolunteer();
            testVol = hVol.hCreateVolunteer("testName1","testName2","testName3");

            hVolEmail hEmail = new hVolEmail();
            primaryEmail = hEmail.hCreateVolEmail("test1@test.tes", testVol.VolID, true, ref numberEmails);
            secondEmail = hEmail.hCreateVolEmail("test2@test.tes", testVol.VolID, false, ref numberEmails);
            thirdEmail = hEmail.hCreateVolEmail("test3@test.tes", testVol.VolID, false, ref numberEmails);

            emailList = hEmail.hSelectVolEmail(primaryEmail);
            foreach (sp_Email_DM email in emailList)
            {
                addressList.Add(email.EmailAddr);
                idList.Add(email.EmailID);
            }
            Assert.IsTrue(addressList.Contains(primaryEmail.EmailAddr));
            Assert.IsTrue(addressList.Contains(secondEmail.EmailAddr));
            Assert.IsTrue(addressList.Contains(thirdEmail.EmailAddr));
            Assert.IsTrue(idList.Contains(primaryEmail.EmailID));
            Assert.IsTrue(idList.Contains(secondEmail.EmailID));
            Assert.IsTrue(idList.Contains(thirdEmail.EmailID));
            addressList.Clear();
            idList.Clear();

            emailList = hEmail.hSelectVolEmail(secondEmail);
            foreach (sp_Email_DM email in emailList)
            {
                addressList.Add(email.EmailAddr);
                idList.Add(email.EmailID);
            }
            Assert.IsTrue(addressList.Contains(primaryEmail.EmailAddr));
            Assert.IsTrue(addressList.Contains(secondEmail.EmailAddr));
            Assert.IsTrue(addressList.Contains(thirdEmail.EmailAddr));
            Assert.IsTrue(idList.Contains(primaryEmail.EmailID));
            Assert.IsTrue(idList.Contains(secondEmail.EmailID));
            Assert.IsTrue(idList.Contains(thirdEmail.EmailID));
            addressList.Clear();
            idList.Clear();

            emailList = hEmail.hSelectVolEmail(thirdEmail);
            foreach (sp_Email_DM email in emailList)
            {
                addressList.Add(email.EmailAddr);
                idList.Add(email.EmailID);
            }
            Assert.IsTrue(addressList.Contains(primaryEmail.EmailAddr));
            Assert.IsTrue(addressList.Contains(secondEmail.EmailAddr));
            Assert.IsTrue(addressList.Contains(thirdEmail.EmailAddr));
            Assert.IsTrue(idList.Contains(primaryEmail.EmailID));
            Assert.IsTrue(idList.Contains(secondEmail.EmailID));
            Assert.IsTrue(idList.Contains(thirdEmail.EmailID));
            addressList.Clear();
            idList.Clear();

            selectEmail = hEmail.hSelectPrimaryVolEmail(primaryEmail);
            Assert.AreEqual(primaryEmail.EmailAddr, selectEmail.EmailAddr);
            Assert.AreEqual(primaryEmail.EmailID, selectEmail.EmailID);
            Assert.AreEqual(primaryEmail.ActiveFlg, selectEmail.ActiveFlg);
            Assert.AreEqual(primaryEmail.VolID, selectEmail.VolID);
            Assert.AreEqual(true, selectEmail.PrimaryFlg);

            selectEmail = hEmail.hSelectPrimaryVolEmail(secondEmail);
            Assert.AreEqual(primaryEmail.EmailAddr, selectEmail.EmailAddr);
            Assert.AreEqual(primaryEmail.EmailID, selectEmail.EmailID);
            Assert.AreEqual(primaryEmail.ActiveFlg, selectEmail.ActiveFlg);
            Assert.AreEqual(primaryEmail.VolID, selectEmail.VolID);
            Assert.AreEqual(true, selectEmail.PrimaryFlg);

            selectEmail = hEmail.hSelectPrimaryVolEmail(thirdEmail);
            Assert.AreEqual(primaryEmail.EmailAddr, selectEmail.EmailAddr);
            Assert.AreEqual(primaryEmail.EmailID, selectEmail.EmailID);
            Assert.AreEqual(primaryEmail.ActiveFlg, selectEmail.ActiveFlg);
            Assert.AreEqual(primaryEmail.VolID, selectEmail.VolID);
            Assert.AreEqual(true, selectEmail.PrimaryFlg);

            hEmail.hUpdateVolEmail(primaryEmail, "replaceTest@replace.tes", true);
            selectEmail = hEmail.hSelectPrimaryVolEmail(primaryEmail);
            Assert.AreEqual("replaceTest@replace.tes", selectEmail.EmailAddr);
            Assert.AreEqual(primaryEmail.EmailID, selectEmail.EmailID);
            Assert.AreEqual(primaryEmail.ActiveFlg, selectEmail.ActiveFlg);
            Assert.AreEqual(primaryEmail.VolID, selectEmail.VolID);
            Assert.AreEqual(true, selectEmail.PrimaryFlg);


            /*hPhone.hUpdateVolPhone(primaryPhone, primaryPhone.PhoneNbr, false);
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
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);*/

            hEmail.hDeleteVolEmail(primaryEmail);
            /*selectPhone = hPhone.hSelectPrimaryVolPhone(primaryPhone);
            Assert.AreEqual(primaryPhone.PhoneNbr,selectPhone.PhoneNbr);
            Assert.AreEqual(true, selectPhone.PrimaryFlg);
            Assert.AreEqual(false,selectPhone.ActiveFlg);
            Assert.AreEqual(primaryPhone.PhoneID, selectPhone.PhoneID);
            Assert.AreEqual(primaryPhone.VolID, selectPhone.VolID);*/

            hEmail.hDeleteVolEmail(secondEmail);
            hEmail.hDeleteVolEmail(thirdEmail);
            hVol.hDeleteVolunteer(testVol);

        }

        /*[ClassCleanup]
        public static void RemoveVolPhoneData()
        {
            cExcel.RemoveData(ExcelFilenames);
        }*/

    }
}
