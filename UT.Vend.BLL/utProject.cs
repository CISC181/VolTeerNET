using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using UT.Helper;

namespace UT.Vend.BLL
{
    [TestClass]
    public class utProject
    {

        static string[] ExcelFilenames = {
            "VendAddress.xlsx",
            "Project.xlsx"
        };

        private static bool Equals(sp_Project_DM dm1, sp_Project_DM dm2)
        {
            return (dm1.ProjectID == dm2.ProjectID &&
                    dm1.ProjectName == dm2.ProjectName &&
                    dm1.ProjectDesc == dm2.ProjectDesc &&
                    dm1.AddrID == dm2.AddrID &&
                    dm1.ActiveFlg == dm2.ActiveFlg
                    );
        }

        private static List<sp_Project_DM> DMsFrom(DataTable dataTable)
        {
            var DMs = new List<sp_Project_DM>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var returnProject = new sp_Project_DM();
                returnProject.ProjectID = new Guid((string)dataTable.Rows[i]["ProjectID"]);
                returnProject.ProjectName = (String)dataTable.Rows[i]["ProjectName"];
                returnProject.ProjectDesc = (String)dataTable.Rows[i]["ProjectDesc"];
                returnProject.AddrID = Convert.ToInt32(dataTable.Rows[i]["AddrID"]);
                returnProject.ActiveFlg = Convert.ToBoolean(dataTable.Rows[i]["ActiveFlg"]);
                DMs.Add(returnProject);
            }
            return DMs;
        }

        [ClassInitialize]
        public static void initializeProject(TestContext testContext)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", DateTime.Now));
            cExcel.RemoveAllData();
            cExcel.InsertData(ExcelFilenames);
        }

        [TestMethod]
        public void TestProjectRead()
        {
            //Pull our data from the excel file
            string helperDir = cExcel.GetHelperFilesDir();
            DataTable dt = cExcel.ReadExcelFile("Sheet1", Path.Combine(helperDir, "Project.xlsx"));
            var excelDMs = DMsFrom(dt);
            //Pull our data directly from the DB
            var numRows = cExcel.getNumRecordsFromDB("[Vend].[tblProject]");

            //Pull our data from the DB through the BLL
            var Project_bll = new sp_Project_BLL();
            var allProjects = Project_bll.ListProjects();

            //Test the data from the BLL
            Assert.AreEqual(numRows, allProjects.Count);
            foreach (var testProject in excelDMs)
            {
                var selectedProject = Project_bll.ListProjects(testProject.ProjectID);
                Assert.IsTrue(Equals(testProject, selectedProject));
            }
        }

        [TestMethod]
        public void TestProjectCreate()
        {
            string ProjectName = "TestProject";
            string ProjectDesc = "We Rock!";
            bool ActiveFlg = true;
            var Project_bll = new sp_Project_BLL();
            var Project_dm = new sp_Project_DM();
            var VendAdress_bll = new sp_VendAddress_BLL();
            Project_dm.ProjectName = ProjectName;
            Project_dm.ProjectDesc = ProjectDesc;
            var allAddresses = VendAdress_bll.ListAddresses();
            Assert.IsTrue(allAddresses.Count > 0, "The ListAddresses() is broken, or no data in DB");
            Project_dm.AddrID = allAddresses[0].AddrID;
            Project_dm.ActiveFlg = ActiveFlg;
            var ProjectID = Project_bll.InsertProjectContext(ref Project_dm).ProjectID;
            Project_dm.ProjectID = ProjectID;

            var Project_dm_selected = Project_bll.ListProjects(ProjectID);
            Assert.IsTrue(Equals(Project_dm, Project_dm_selected));
        }

        [TestMethod]
        public void TestProjectUpdate()
        {
            var Project_bll = new sp_Project_BLL();
            var allProjects = Project_bll.ListProjects();
            Assert.IsTrue(allProjects.Count > 0, "The ListProjects() is broken, or no data in DB");
            var firstProject = allProjects[0];
            var newProjectName = "Updated Project Name";
            firstProject.ProjectName = newProjectName;
            Project_bll.UpdateProjectContext(firstProject);
            var selectedProject = Project_bll.ListProjects(firstProject.ProjectID);

            Assert.IsTrue(Equals(firstProject, selectedProject));
            Assert.AreEqual(newProjectName, selectedProject.ProjectName);
        }

        [TestMethod]
        public void TestProjectDelete()
        {
            var Project_bll = new sp_Project_BLL();
            var allProjects = Project_bll.ListProjects();
            Assert.IsTrue(allProjects.Count > 0, "The ListProjects() is broken, or no data in DB");
            var currProject = allProjects[0];
            //TODO: change activeflg to bool not bool?
            var notActive = currProject.ActiveFlg != true;
            var i = 1;
            while (notActive)
            {
                currProject = allProjects[i];
                notActive = currProject.ActiveFlg != true;
            }
            Project_bll.DeleteProjectContext(currProject);
            var selectedProject = Project_bll.ListProjects(currProject.ProjectID);

            //TODO: change activeflg to bool not bool?
            Assert.IsNotNull(selectedProject.ActiveFlg);
            Assert.IsFalse(selectedProject.ActiveFlg == true);
            Assert.IsTrue(selectedProject.ActiveFlg == false);
        }

        [ClassCleanup]
        public static void postRun()
        {
            cExcel.RemoveData(ExcelFilenames);
        }
    }
}
