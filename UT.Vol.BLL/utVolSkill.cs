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
    public class utVolSkill
    {
        [TestMethod]
        public void TestListVolSkill()
        {
            string[] fnames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx",
                                "VolEmail.xlsx"};

            cExcel.InsertData(fnames);
            string hdir = cExcel.GetHelperFilesDir();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dt = cExcel.QueryExcelFile(hdir + "VolSkill.xlsx", query);
            DataTable dtskill = cExcel.QueryExcelFile(hdir + "Skill.xlsx", query);
            sp_VolSkill_BLL spBLL = new sp_VolSkill_BLL();
            foreach (DataRow row in dt.Rows)
            {
                var volid = row["VolID"];

                Guid gvol = new Guid(volid.ToString());
                foreach (sp_VolSkill_DM vol in spBLL.ListVolSkills(gvol))
                {
                    DataRow[] volskillRow = dtskill.Select(String.Format("SkillID = '{0}'", vol.SkillID.ToString()));
                    Assert.AreEqual(volskillRow.Length, 1);

                    var tmpid = volskillRow[0]["MstrSkillID"].ToString() == "" ? null : (Guid?)(new Guid(volskillRow[0]["MstrSkillID"].ToString()));
                    Assert.AreEqual(vol.MstrSkillID, tmpid);
                    Assert.AreEqual(vol.SkillName, volskillRow[0]["SkillName"]);
                }
            }

            cExcel.RemoveData(fnames);
        }

        [TestMethod]
        public void TestContexVolSkill()
        {
            string[] insertNames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                                 "VolAddr.xlsx", "Skill.xlsx"};
            string[] removeNames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx",
                                "VolEmail.xlsx"};
            cExcel.RemoveData(removeNames);
            cExcel.InsertData(insertNames);


            string directory = cExcel.GetHelperFilesDir();
            string hdir = cExcel.GetHelperFilesDir();
            sp_VolSkill_BLL volskillBLL = new sp_VolSkill_BLL();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dtvolskill = cExcel.QueryExcelFile(hdir + "VolSkill.xlsx", query);
            DataTable dtskill = cExcel.QueryExcelFile(hdir + "Skill.xlsx", query);
            foreach (DataRow row in dtvolskill.Rows)
            {

                //Push data into the database and then check to see if the data 
                //we get out the other end is the same.
                volskillBLL.InsertVolSkill(new Guid(row["VolID"].ToString()), new Guid(row["SkillID"].ToString()));
                var returned_Skill = volskillBLL.ListVolSkills(new Guid(row["VolID"].ToString()));
                Assert.IsTrue(returned_Skill.Capacity > 0);
                sp_VolSkill_DM fnd_skill = returned_Skill.Find(x => x.SkillID.Equals(new Guid(row["SkillID"].ToString())));
                Assert.AreEqual(fnd_skill.SkillID, new Guid(row["SkillID"].ToString()));
            }
            cExcel.RemoveData(removeNames);
        }

        [TestMethod]
        public void TestDeleteVolSkill()
        {
            string[] insertNames = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                    "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx",
                                    "VolEmail.xlsx"};
            cExcel.InsertData(insertNames);


            string directory = cExcel.GetHelperFilesDir();
            string hdir = cExcel.GetHelperFilesDir();
            sp_VolSkill_BLL volskillBLL = new sp_VolSkill_BLL();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dtvolskill = cExcel.QueryExcelFile(hdir + "VolSkill.xlsx", query);
            
            foreach (DataRow row in dtvolskill.Rows)
            {

                //Delete a volskill 
                int before = cExcel.getNumRecordsFromDB("Vol.tblVolSkill");
                volskillBLL.DeleteVolSkillALL(new Guid(row["VolID"].ToString()));
                int after = cExcel.getNumRecordsFromDB("Vol.tblVolSkill");
                Assert.AreEqual(before - 1, after);
            }
        }
    }
}
