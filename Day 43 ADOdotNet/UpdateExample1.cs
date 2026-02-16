using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_43_ADOdotNet
{
    public class UpdateExample1
    {
        public static void Main(string[] args) 
        { 

            string cs = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = @"UPDATE dbo.Employees SET Salary=@salary WHERE EmployeeId=@id";

            Console.Write("EmployeeId: "); int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("New Salary: "); decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@salary", salary);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine($"Updated rows: {rows}");
        }
    }
}
