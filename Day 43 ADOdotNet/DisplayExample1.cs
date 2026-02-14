using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_43_ADOdotNet
{
    public class DisplayExample1
    {
        public static void Main(string[] args)
        {
            string cs = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";

            Console.Write("Enter Department (e.g., IT): ");
            string dept = Console.ReadLine() ?? "";

            string sql = @"SELECT EmployeeId, FullName, Salary
               FROM dbo.Employees
               WHERE Department = @dept
               ORDER BY Salary DESC";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            // ✅ Add parameter
            cmd.Parameters.AddWithValue("@dept", dept);

            con.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["EmployeeId"]} | {r["FullName"]} | {r["Salary"]}");
            }
        }
    }
}
