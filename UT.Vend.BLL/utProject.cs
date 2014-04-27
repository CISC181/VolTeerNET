using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
using System.Data;
using System.IO;
using System.Collections.Generic;
using UT.Vend.BLL.HelperMethods;

namespace UT.Vend.BLL
{
    [TestClass]
    public class utProject
    {

        static string[] ExcelFilenames = new string[] {
            "Project.xlsx",
            "ProjectEvent.xlsx"
        };

        public static List<string> GetExcelFiles()
        {
            //TODO: look into globbing helperFilesDir for all xlsx files
            List<string> ExcelFiles = new List<string>();
            string exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string helperFilesDir = Path.GetFullPath(Path.Combine(exeDir, "..\\..\\HelperFiles\\"));
            foreach (string excelFilename in ExcelFilenames)
            {
                ExcelFiles.Add(Path.Combine(helperFilesDir, excelFilename));
            }
            return ExcelFiles;
        }

        [ClassInitialize]
        public static void InsertProjectData(TestContext testContext)
        {
            List<string> ExcelFiles = GetExcelFiles();
            foreach (string excelFile in ExcelFiles)
            {
                Console.WriteLine(String.Format("{0} exists: {1}", excelFile, File.Exists(excelFile)));
                DataTable dt = new DataTable();
                cExcel _cExcel = new cExcel();
                string strSheetName = "Sheet1";
                try
                {
                    dt = _cExcel.ReadExcelFile(strSheetName, excelFile);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                foreach (DataRow row in dt.Rows) // Loop over the rows.
                {
                    string query = row["Query"].ToString();
                    if (query.Length > 1){
                        Console.WriteLine(query);
                    }
                }
            }
        }

        [TestMethod]
        public void TestProject()
        {
        }

        [ClassCleanup]
        public static void RemoveAllData()
        {
        }
    }
}
