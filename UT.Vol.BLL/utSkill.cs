using System;
using UT.Helper;
using VolTeer.BusinessLogicLayer;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UT.Volteer.BLL
{
    [TestClass]
    public class utSkill
    {
        [TestMethod]
        public void testListSkills()
        {
            string[] fnames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx", 
                                "VolEmail.xlsx", "VolPhone.xlsx"};
            cExcel.RemoveData(fnames);
            cExcel.InsertData(fnames);
            string directory = cExcel.GetHelperFilesDir();
            sp_Skill_BLL skillBLL = new sp_Skill_BLL();
            string hdir = cExcel.GetHelperFilesDir();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dt = cExcel.QueryExcelFile(hdir + "Skill.xlsx", query);
            foreach (sp_Skill_DM skill in skillBLL.ListSkills())
            {
                var selectedRow = dt.Select(string.Format("SkillID = '{0}'", skill.SkillID));
                Assert.AreEqual(selectedRow.Length, 1);
                Assert.AreEqual(selectedRow[0]["SkillName"], skill.SkillName);
                var tmp = skill.MstrSkillID == null ? (object)"" : skill.MstrSkillID.Value.ToString();
                Assert.AreEqual(tmp, selectedRow[0]["MStrSkillID"].ToString().ToLower());
                Assert.AreEqual(skill.ActiveFlg, Convert.ToInt32(selectedRow[0]["ActiveFlg"]));
            }
        }

        [TestMethod]
        public void testListSingleSkill()
        {
            string[] fnames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx", 
                                "VolEmail.xlsx", "VolPhone.xlsx"};
            cExcel.InsertData(fnames);
            string directory = cExcel.GetHelperFilesDir();
            string hdir = cExcel.GetHelperFilesDir();
            sp_Skill_BLL skillBLL = new sp_Skill_BLL();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dt = cExcel.QueryExcelFile(hdir + "Skill.xlsx", query);
            foreach (DataRow row in dt.Rows)
            {
                sp_Skill_DM skdm = skillBLL.ListSingleSkill(new Guid(row["SkillID"].ToString()));
                
                Guid? g = row["MstrSkillID"].ToString() == "" ? new Nullable<Guid>() : (Guid?)(new Guid(row["MstrSkillID"].ToString()));
                Assert.AreEqual(skdm.MstrSkillID, g);
                Assert.AreEqual(skdm.SkillName, row["SkillName"]);
                Assert.AreEqual(skdm.ActiveFlg, Convert.ToInt32(row["ActiveFlg"]));
            }
        }

        [TestMethod]
        public void testContextSkill()
        {
            string[] insertNames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                     "VolAddr.xlsx"};
            string[] removeNames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx", 
                                "VolEmail.xlsx", "VolPhone.xlsx"};
            cExcel.RemoveData(removeNames);
            cExcel.InsertData(insertNames);

            string directory = cExcel.GetHelperFilesDir();
            string hdir = cExcel.GetHelperFilesDir();
            sp_Skill_BLL skillBLL = new sp_Skill_BLL();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dt = cExcel.QueryExcelFile(hdir + "Skill.xlsx", query);
            foreach (DataRow row in dt.Rows)
            {
                sp_Skill_DM dmskill = new sp_Skill_DM();

                dmskill.ActiveFlg = Convert.ToInt32(row["ActiveFlg"]);
                dmskill.MstrSkillID = row["MstrSkillID"].ToString() == "" ? new Nullable<Guid>() : (Guid?)(new Guid(row["MstrSkillID"].ToString()));
                dmskill.SkillID = new Guid(row["SkillID"].ToString());
                dmskill.SkillName = row["SkillName"].ToString();
                System.Console.WriteLine(row["MstrSkillID"]);
                //Push data into the database and then check to see if the data 
                //we get out the other end is the same.
                skillBLL.InsertSkillContext(ref dmskill);
                sp_Skill_DM returned_Skill = skillBLL.ListSingleSkill(dmskill.SkillID);
                Assert.AreEqual(returned_Skill, dmskill);
            }
        }
    }
}
