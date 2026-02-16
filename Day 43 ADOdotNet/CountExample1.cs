using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CAP2025.Day_43_ADOdotNet
{
    public class CountExample1
    {
        public static void Main(string[] args)
        {
            string ConnectionString = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = "SELECT COUNT(*) FROM dbo.Employees";
            using var con = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, con);
            con.Open();
            var result = cmd.ExecuteScalar();
            int total = Convert.ToInt32(result);
            Console.WriteLine($"Total employees: {total}");
        }
    }
}
