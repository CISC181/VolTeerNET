using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using UT.Vol.BLL.HelperMethods;
using System.Data;
using System.IO;
using System.Linq;
using UT.Helper;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utVolEmail
    {

        static sp_Volunteer_DM generalTestVol;
        static sp_Volunteer_DM createTestVol;

        static sp_Email_DM primaryTestVolEmail;
        static sp_Email_DM secondaryTestVolEmail;
        static sp_Email_DM createTestVolEmail;

        static string[] ExcelFilenames = new string[] {
            "Volunteer.xlsx", "VolEmail.xlsx"
        };

        private static bool EmailEquals(sp_Email_DM dm1, sp_Email_DM dm2)
        {
            return ((dm1.ActiveFlg == dm2.ActiveFlg) &&
                (dm1.EmailAddr == dm2.EmailAddr) &&
                (dm1.EmailID == dm2.EmailID) &&
                (dm1.PrimaryFlg == dm2.PrimaryFlg) &&
                (dm1.VolID == dm2.VolID));
        }

        private static bool EmailListContains(List<sp_Email_DM> emailList, sp_Email_DM email)
        {

            bool listContainsEmail = false;

            foreach (sp_Email_DM currEmail in emailList)
            {

                listContainsEmail = listContainsEmail || EmailEquals(currEmail, email);

            }

            return listContainsEmail;

        }

        private static List<sp_Email_DM> getVolEmailDMs(DataTable dataTable)
        {
            List<sp_Email_DM> volEmailDMs = new List<sp_Email_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                sp_Email_DM returnEmail = new sp_Email_DM();
                returnEmail.VolID = new Guid((string)dataTable.Rows[i]["VolID"]);
                returnEmail.EmailAddr = (String)dataTable.Rows[i]["EmailAddr"];
                returnEmail.PrimaryFlg = Convert.ToBoolean(dataTable.Rows[i]["PrimaryFlg"]);
                returnEmail.EmailID = Convert.ToInt32(dataTable.Rows[i]["EmailID"]);
                returnEmail.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                volEmailDMs.Add(returnEmail);
            }
            return volEmailDMs;
        }

        [ClassInitialize]
        public static void InsertVolEmailData(TestContext testContext)
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
            Guid volID = Guid.NewGuid();
            generalTestVol.VolID = volID;
            volBLL.InsertVolunteerContext(ref generalTestVol);
            

            sp_VolEmail_BLL volEmail_bll = new sp_VolEmail_BLL();
            primaryTestVolEmail = new sp_Email_DM();
            primaryTestVolEmail.EmailAddr = "PrimaryAddress@te.st";
            primaryTestVolEmail.VolID = volID;
            primaryTestVolEmail.ActiveFlg = true;
            primaryTestVolEmail.PrimaryFlg = true;
            volEmail_bll.InsertEmailContext(ref primaryTestVolEmail);

            secondaryTestVolEmail = new sp_Email_DM();
            secondaryTestVolEmail.EmailAddr = "SecondaryAddress@te.st";
            secondaryTestVolEmail.VolID = volID;
            secondaryTestVolEmail.ActiveFlg = true;
            secondaryTestVolEmail.PrimaryFlg = false;
            volEmail_bll.InsertEmailContext(ref secondaryTestVolEmail);
        }

        [TestMethod]
        public void TestVolEmailRead()
        {
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "VolEmail.xlsx"));
            List<sp_Email_DM> excelDMs = getVolEmailDMs(dt);
            sp_VolEmail_BLL volEmail_bll = new sp_VolEmail_BLL();

            foreach (sp_Email_DM testVolEmail in excelDMs)
            {
                List<sp_Email_DM> selectedVolEmails = volEmail_bll.ListEmails(testVolEmail);
                Assert.IsTrue(EmailListContains(selectedVolEmails,testVolEmail));
            }
        }

        [TestMethod]
        public void TestVolEmailCreate()
        {

            sp_Volunteer_BLL vol_bll = new sp_Volunteer_BLL();
            sp_Volunteer_DM vol_dm = new sp_Volunteer_DM();
            vol_dm.VolFirstName = "createFirst";
            vol_dm.VolMiddleName = "createMiddle";
            vol_dm.VolLastName = "createLast";
            vol_dm.ActiveFlg = true;
            System.Guid volID = vol_bll.InsertVolunteerContext(ref vol_dm).VolID;
            vol_dm.VolID = volID;

            string volEmailAddr = "CreateAddress@te.st";
            bool PrimaryFlg = true;
            bool ActiveFlg = true;
            sp_VolEmail_BLL volEmail_bll = new sp_VolEmail_BLL();
            sp_Email_DM volEmail_dm = new sp_Email_DM();            
            volEmail_dm.EmailAddr = volEmailAddr;
            volEmail_dm.VolID = volID;
            volEmail_dm.ActiveFlg = ActiveFlg;
            volEmail_dm.PrimaryFlg = PrimaryFlg;
            volEmail_bll.InsertEmailContext(ref volEmail_dm);
            int volEmailID = volEmail_dm.EmailID;

            List<sp_Email_DM> volEmailDMs_selected = volEmail_bll.ListEmails(volEmail_dm);
            Assert.IsTrue(EmailListContains(volEmailDMs_selected,volEmail_dm));

        }

        [TestMethod]
        public void TestVolEmailPrimaryRead()
        {

            sp_VolEmail_BLL volEmailBLL = new sp_VolEmail_BLL();
            sp_Email_DM volEmailDM_selected = volEmailBLL.ListPrimaryEmail(primaryTestVolEmail);
            Assert.IsTrue(EmailEquals(primaryTestVolEmail,volEmailDM_selected));

            volEmailDM_selected = volEmailBLL.ListPrimaryEmail(secondaryTestVolEmail);
            Assert.IsTrue(EmailEquals(primaryTestVolEmail, volEmailDM_selected));

        }

        [TestMethod]
        public void TestVolEmailUpdate()
        {

            sp_VolEmail_BLL volEmailBLL = new sp_VolEmail_BLL();
            volEmailBLL.InsertEmailContext(ref primaryTestVolEmail);
            sp_Email_DM updateEmail = volEmailBLL.ListPrimaryEmail(primaryTestVolEmail);
            String newEmailAddr = "updated@em.ail";
            updateEmail.EmailAddr = newEmailAddr;
            volEmailBLL.UpdateEmailAddr(updateEmail);
            sp_Email_DM selectedEmail = volEmailBLL.ListPrimaryEmail(updateEmail);

            //To get all emails listed, create a new domain model with no emailID specified.
            sp_Email_DM selectAllEmails = new sp_Email_DM();
            selectAllEmails.VolID = updateEmail.VolID;
            List<sp_Email_DM> selectedEmailList = volEmailBLL.ListEmails(selectAllEmails);

            Assert.IsTrue(EmailListContains(selectedEmailList, updateEmail));
            Assert.IsTrue(EmailListContains(selectedEmailList, selectedEmail));
            Assert.IsTrue(EmailEquals(selectedEmail,updateEmail));
            Assert.AreEqual(newEmailAddr, selectedEmail.EmailAddr);

        }

        [TestMethod]
        public void TestVolEmailDelete()
        {

            sp_VolEmail_BLL volEmail_bll = new sp_VolEmail_BLL();
            //Can't delete primary emails
            //volEmail_bll.DeleteEmailsContext(primaryTestVolEmail);
            //sp_Email_DM selectedVolEmail = volEmail_bll.ListPrimaryEmail(primaryTestVolEmail);
            volEmail_bll.DeleteEmailsContext(secondaryTestVolEmail);
            sp_Email_DM selectedVolEmail = volEmail_bll.ListEmails(secondaryTestVolEmail).First();

            Assert.IsNotNull(selectedVolEmail.ActiveFlg);
            Assert.IsFalse(selectedVolEmail.ActiveFlg == true);
            Assert.IsTrue(selectedVolEmail.ActiveFlg == false);
        }

        [ClassCleanup]
        public static void RemoveVolEmailData()
        {
            sp_VolEmail_BLL volEmailBLL = new sp_VolEmail_BLL();
            volEmailBLL.DeleteEmailsContext(secondaryTestVolEmail);
            volEmailBLL.DeleteEmailsContext(primaryTestVolEmail);
            //Make sure we don't pass it null because we didn't run one of the tests
            if (createTestVolEmail != null)
                volEmailBLL.DeleteEmailsContext(createTestVolEmail);

            sp_Volunteer_BLL volBLL = new sp_Volunteer_BLL();
            volBLL.DeleteVolunteerContext(generalTestVol);
            //Make sure we don't pass it null because we didn't run one of the tests
            if (createTestVolEmail != null)
                volBLL.DeleteVolunteerContext(createTestVol);

            cExcel.RemoveData(ExcelFilenames);
        }

    }
}
