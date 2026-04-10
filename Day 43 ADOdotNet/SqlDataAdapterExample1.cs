using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CAP2025.Day_43_ADOdotNet
{
    public class SqlDataAdapterExample1
    {
        public static void Main(string[] args)
        {
            string ConnectionString = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees; SELECT EmployeeId, FullName FROM dbo.Employees; SELECT Department, Salary FROM dbo.Employees";
            DataSet LocalDataSet = new DataSet();
            using var con=new SqlConnection(ConnectionString);
            using(var cmd=new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(LocalDataSet);
            }
            LocalDataSet.WriteXml("TestXmlSQLAdapterExample");
            Console.WriteLine("Successfully Copied the data in the file in XML format");
        }
    }
}
