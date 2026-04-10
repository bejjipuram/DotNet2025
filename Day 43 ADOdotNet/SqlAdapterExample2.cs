using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CAP2025.Day_43_ADOdotNet
{
    public class SqlAdapterExample2
    {
        public static void Main(string[] args)
        {
            string ConnectionString = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            string sql = "SELECT EmployeeId, FullName, Department, Salary FROM Employees";
            using var con = new SqlConnection(ConnectionString);
            using(var cmd=new SqlCommand(sql, con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet LocalDataSet = new DataSet();
                adapter.Fill(LocalDataSet, "EmployeesLocal");
                DataTable LocalTable = LocalDataSet.Tables["EmployeesLocal"];

                //Insertion
                DataRow newRow = LocalTable.NewRow();
                newRow["FullName"] = "Aryan";
                newRow["Department"] = "IT";
                newRow["Salary"] = 60000;
                LocalTable.Rows.Add(newRow);

                //Updation
                LocalTable.Rows[0]["Salary"] = 90000;
                LocalTable.Rows[0]["FullName"] = "Viswa";

                //Deletion
                LocalTable.Rows[2].Delete();

                //AcceptChanges
                LocalDataSet.AcceptChanges();

                //Pushing changes into db
                adapter.Update(LocalDataSet, "EmployeesLocal");
                Console.WriteLine("Insert, Update, and Delete Operations are done.");

            }
        }
    }
}
