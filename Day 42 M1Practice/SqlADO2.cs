using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_42_M1Practice
{
   public class SqlMain
    {
        public static void Main()
        {
            string cs = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=NormalizationDemo;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = "SELECT CustomerId, CustomerName, CustomerPhone, CustomerCity FROM dbo.Customer ORDER BY CustomerId";

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string phone = reader.GetInt32(2);
                        decimal city = reader.GetString(3);

                        Console.WriteLine($"{id} | {name} | {phone} | {city}");
                    }
                }
            }
        }
    }
}
