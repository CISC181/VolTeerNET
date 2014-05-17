using System;
using System.Collections.Generic;
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
                System.Console.WriteLine(skill.ActiveFlg);
                Assert.AreEqual(skill.ActiveFlg, Convert.ToInt32(selectedRow[0]["ActiveFlg"]));
            }
            cExcel.RemoveData(fnames);
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
            cExcel.RemoveData(removeNames);
        }



        [TestMethod]
        public void testDeleteSkill()
        {
            string[] tablesToFill = { "Volunteer.xlsx", "Group.xlsx", "GroupVol.xlsx", "VolAddress.xlsx", 
                                "VolAddr.xlsx", "Skill.xlsx", "VolSkill.xlsx", "VolState.xlsx", 
                                "VolEmail.xlsx", "VolPhone.xlsx"};
            cExcel.InsertData(tablesToFill);

            string directory = cExcel.GetHelperFilesDir();
            string hdir = cExcel.GetHelperFilesDir();
            sp_Skill_BLL skillBLL = new sp_Skill_BLL();
            string query = "SELECT * FROM [Sheet1$]";
            DataTable dt = cExcel.QueryExcelFile(hdir + "Skill.xlsx", query);
            List<Tuple<Guid, String, int, Guid?>> rowTree = new List<Tuple<Guid, string, int, Guid?>>();

            foreach (DataRow row in dt.Rows)
            {
                var key = new Guid(row["SkillID"].ToString());
                var mstr = row["MstrSkillID"].ToString() == "" ? new Nullable<Guid>() : (Guid?)(new Guid(row["MstrSkillID"].ToString()));
                var activeFlag = Convert.ToInt32(row["ActiveFlg"]);
                var skillname = row["SkillName"].ToString();
                rowTree.Add(Tuple.Create<Guid, string, int, Guid?>(key, skillname, activeFlag, mstr));
            }
            //this function returns the guid of the parent we deleted
            Func<Guid, List<Tuple<Guid, String, int, Guid?>>> deleteReturnParent = (Guid key) =>
            {
                //Check to make sure this key is still contained in the database based
                //on the description of how it should work.
                var toDeleteRow = rowTree.Find((x) => { 
                        return x.Item1.Equals(key); 
                });
                rowTree.Remove(toDeleteRow);
                //Find all rows that have the key as their mstrskill
                var updateRows = rowTree.FindAll((x) =>
                {
                    return x.Item4.Equals(key);
                });
                //Remove them
                rowTree.RemoveAll((x) =>
                {
                    return x.Item4.Equals(key);
                });
                var returnList = new List<Tuple<Guid, String, int, Guid?>>();
                foreach (var row in updateRows){
                    //Update them so that their master skill ids point at the master skill of the deleted node
                    var guidTpl = Tuple.Create<Guid, String, int, Guid?>(row.Item1, row.Item2, row.Item3, toDeleteRow.Item4);
                    rowTree.Add(guidTpl);
                    returnList.Add(guidTpl);
                }
                return returnList;
            };

            foreach (DataRow row in dt.Rows)
            {
                sp_Skill_DM dmskill = new sp_Skill_DM();
                dmskill.ActiveFlg = Convert.ToInt32(row["ActiveFlg"]);
                dmskill.MstrSkillID = row["MstrSkillID"].ToString() == "" ? new Nullable<Guid>() : (Guid?)(new Guid(row["MstrSkillID"].ToString()));
                dmskill.SkillID = new Guid(row["SkillID"].ToString());
                dmskill.SkillName = row["SkillName"].ToString();

                //Delete a skill
                int before = cExcel.getNumRecordsFromDB("Vol.tblVolSkill");
                skillBLL.DeleteSkillContext(dmskill);
                var updatedList = deleteReturnParent(dmskill.SkillID);
                int after = cExcel.getNumRecordsFromDB("Vol.tblVolSkill");
                //Did the skill actually get deleted.
                Assert.AreEqual(before - 1, after);
                //Did all the values get properly updated
                foreach (var updatedRow in updatedList){
                    sp_Skill_DM updatedSkill = skillBLL.ListSingleSkill(updatedRow.Item1);
                    Assert.AreEqual(updatedSkill.ActiveFlg, updatedRow.Item3);
                    Assert.AreEqual(updatedSkill.MstrSkillID, updatedRow.Item4);
                    Assert.AreEqual(updatedSkill.SkillName, updatedRow.Item2);
                }
            }
            cExcel.RemoveData(tablesToFill);
        }
    }
}
