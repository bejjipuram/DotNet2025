using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_43_ADOdotNet
{
    public class DeletionExample1
    {
        public static void Main(string[] args)
        {
            string cs = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = @"DELETE FROM dbo.Employees WHERE EmployeeId=@id";

            Console.Write("EmployeeId to delete: "); int id = int.Parse(Console.ReadLine() ?? "0");

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine(rows == 1 ? "🗑️ Deleted" : "⚠️ Not found");
        }
    }
}
