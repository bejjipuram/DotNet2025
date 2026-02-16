using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace CAP2025.Day_42_M1Practice
{
    public class SqlADO1
    {
        public static void Main(string[] args)
        {
            string ConnectionString = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=NormalizationDemo;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = "ALTER TABLE dbo.Customers\r\nADD CustomerEmail VARCHAR(100);\r\n";

            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.BeginExecuteNonQuery();
                    Console.WriteLine("Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
