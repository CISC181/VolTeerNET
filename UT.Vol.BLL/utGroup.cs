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
using UT.Vol.BLL.HelperMethods;

namespace UT.Vol.BLL
{
    [TestClass]
    public class utGroup
    {

        static string[] ExcelFilenames = new string[] {
            "Group.xlsx"
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

        public static string getConnectionString()
        {
            return new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["VolTeerConnectionString"].ConnectionString).ProviderConnectionString;
        }

        public static void setIdentityInsert(SqlCommand command, string table, string value)
        {
            try
            {
                command.CommandText = string.Format("SET IDENTITY_INSERT {0} {1}", table, value);
                command.ExecuteNonQuery();
            }
            catch
            {
            }
        }

        [ClassInitialize]
        public static void InsertGroupData(TestContext testContext)
        {
            RemoveAllData();
            List<string> ExcelFiles = GetExcelFiles();
            foreach (string excelFile in ExcelFiles)
            {
                Console.WriteLine(String.Format("{0} exists: {1}", excelFile, File.Exists(excelFile)));
                DataTable dt = new DataTable();
                cExcel _cExcel = new cExcel();
                string strSheetName = "Sheet1";
                dt = _cExcel.ReadExcelFile(strSheetName, excelFile);
                string connectionString = getConnectionString();
                Console.WriteLine(String.Format("Connection String: {0}", connectionString));
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        setIdentityInsert(command, dt.Rows[0]["Table"].ToString(), "ON");
                        foreach (DataRow row in dt.Rows) // Loop over the rows.
                        {
                            string query = row["Query"].ToString();
                            int numRowsAffected = 0;
                            if (query.Length > 1)
                            {
                                Console.WriteLine(query);
                                command.CommandText = query;
                                numRowsAffected = command.ExecuteNonQuery();
                                if (numRowsAffected != 1)
                                {
                                    Console.WriteLine(String.Format("Query affected {0} rows instead of the expected 1 row.", numRowsAffected));
                                }
                            }
                        }
                        setIdentityInsert(command, dt.Rows[0]["Table"].ToString(), "OFF");
                    }
                }
            }
        }

        [TestMethod]
        public void TestGroup()
        {
        }

        [ClassCleanup]
        public static void RemoveAllData()
        {
            string connectionString = getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    foreach (string excelFile in GetExcelFiles())
                    {
                        Console.WriteLine(String.Format("{0} exists: {1}", excelFile, File.Exists(excelFile)));
                        DataTable dt = new DataTable();
                        cExcel _cExcel = new cExcel();
                        string strSheetName = "Sheet1";
                        dt = _cExcel.ReadExcelFile(strSheetName, excelFile);
                        string table = dt.Rows[0]["Table"].ToString();
                        string query = string.Format("DELETE FROM {0}", table);
                        Console.WriteLine(query);
                        command.CommandText = query;
                        int numRowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(String.Format("\t{0} rows affected", numRowsAffected));
                    }
                }
            }

        }
    }
}
