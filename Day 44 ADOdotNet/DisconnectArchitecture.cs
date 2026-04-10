using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace CAP2025.Day_44_ADOdotNet
{

    public class OperationsLocal
    {
        static string ConnectionString = "Data Source=INDRA-S-LAPII\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
        static string sql = "SELECT EmployeeId, FullName, Department, Salary FROM Employees";
        
        /// <summary>
        /// Insertion Operation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="salary"></param>
        public void InsertRecord(string name,string department, decimal salary)
        {
            using var con = new SqlConnection(ConnectionString);
            using var adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet LocalDS = new DataSet();
            adapter.Fill(LocalDS, "EmployeesLocal");
            DataTable LocalTable = LocalDS.Tables["EmployeesLocal"];
            DataRow newRow = LocalTable.NewRow();
            newRow["FullName"] = name;
            newRow["Department"] = department;
            newRow["Salary"] = salary;
            LocalTable.Rows.Add(newRow);
            //LocalDS.AcceptChanges();
            adapter.Update(LocalDS, "EmployeesLocal");
            LocalDS.AcceptChanges();
        }

        /// <summary>
        /// Updating the Records
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="newName"></param>
        /// <param name="NewSalary"></param>
        public void UpdateRecords(int EmployeeId, string newName, decimal NewSalary)
        {
            using var con = new SqlConnection(ConnectionString);
            using var adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet LocalDS= new DataSet();
            adapter.Fill(LocalDS, "EmployeesLocal");
            DataTable LocalTable = LocalDS.Tables["EmployeesLocal"];

            foreach(DataRow row in LocalTable.Rows)
            {
                if ((int)row["EmployeeId"] == EmployeeId)
                {
                    row["FullName"] = newName;
                    row["Salary"] = NewSalary;
                    break;
                }
            }
            //LocalDS.AcceptChanges();
            adapter.Update(LocalDS, "EmployeesLocal");
            LocalDS.AcceptChanges();
        }

        /// <summary>
        /// Deletion Operation
        /// </summary>
        /// <param name="EmployeeId"></param>
        public void DeleteRecords(int EmployeeId)
        {
            using var con = new SqlConnection(ConnectionString);
            using var adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet LocalDS= new DataSet();
            adapter.Fill(LocalDS, "EmployeesLocal");
            DataTable LocalTable = LocalDS.Tables["EmployeesLocal"];
            foreach(DataRow row in LocalTable.Rows)
            {
                if ((int)row["EmployeeId"] == EmployeeId)
                {
                    row.Delete();
                    break;
                }
            }
            //LocalDS.AcceptChanges();
            adapter.Update(LocalDS, "EmployeesLocal");
            LocalDS.AcceptChanges();
        }

        public void Display()
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");

            DataTable table = ds.Tables["Employees"];

            Console.WriteLine("\n--- Employee List ---");

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["EmployeeId"]} | {row["FullName"]} | {row["Department"]} | {row["Salary"]}");
            }
        }

        public void LinqDisplay()
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");

            DataTable table = ds.Tables["Employees"];


            // Convert DataTable → LINQ compatible collection
            var rows = table.AsEnumerable();

            Console.WriteLine("\n========= LINQ ANALYTICS =========");

            // ===========================
            // 3️⃣ HIGH SALARY FILTER + ORDER
            // ===========================

            Console.WriteLine("\n--- High Salary Employees (>50000) Sorted ---");

            var highSalary = rows
                .Where(r => r.Field<decimal>("Salary") > 50000)
                .OrderByDescending(r => r.Field<decimal>("Salary"))  // Highest first
                .ThenBy(r => r.Field<string>("FullName"))
                .Select(r => new
                {
                    Name = r.Field<string>("FullName"),
                    Dept = r.Field<string>("Department"),
                    Salary = r.Field<decimal>("Salary")
                });

            foreach (var list in highSalary)
            {
                Console.WriteLine($"{list.Name} | {list.Dept} | {list.Salary}");
            }



            // 2️⃣ Only Names (Projection)
            Console.WriteLine("\n--- Only Employee Names ---");

            var names = rows.Select(r => r.Field<string>("FullName"));

            foreach (var name in names)
                Console.WriteLine(name);


            // ===========================
            // 2️⃣ GROUPING + SORTING
            // ===========================

            Console.WriteLine("\n--- Grouped By Department (Sorted Inside Group) ---");

            var grouped = rows
                .OrderBy(r => r.Field<string>("Department"))   // Sort Departments First
                .ThenBy(r => r.Field<decimal>("Salary"))       // Sort Within Dept By Salary
                .ThenBy(r => r.Field<string>("FullName"))      // If salary same → sort by name
                .GroupBy(r => r.Field<string>("Department"));  // Now group

            foreach (var deptGroup in grouped)
            {
                Console.WriteLine($"\nDepartment: {deptGroup.Key}");

                foreach (var emp in deptGroup)
                {
                    Console.WriteLine($"   {emp.Field<string>("FullName")} - {emp.Field<decimal>("Salary")}");
                }
            }

            // 4️⃣ Average Salary (Aggregation)
            Console.WriteLine("\n--- Average Salary ---");

            var avgSalary = rows.Average(r => r.Field<decimal>("Salary"));

            Console.WriteLine($"Average Salary: {avgSalary}");

            // ===========================
            // 1️⃣ ORDERING (Global Sort)
            // ===========================

            Console.WriteLine("\n--- Employees Ordered By Salary, Then Name ---");

            var orderedEmployees = rows
                .OrderBy(r => r.Field<decimal>("Salary"))      // Primary Sort
                .ThenBy(r => r.Field<string>("FullName"));     // Secondary Sort

            foreach (var emp in orderedEmployees)
            {
                Console.WriteLine($"{emp.Field<int>("EmployeeId")} | {emp.Field<string>("FullName")} | {emp.Field<string>("Department")} | {emp.Field<decimal>("Salary")}");
            }
        }

}
    public class DisconnectArchitecture
    {
        
        public static void Main(string[] args)
        {
            OperationsLocal operations = new OperationsLocal();

            while (true)
            {
                Console.WriteLine("\n1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. LINQ Display");
                Console.WriteLine("5. Display");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Department: ");
                        string dept = Console.ReadLine();

                        Console.Write("Salary: ");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());

                        operations.InsertRecord(name, dept, salary);
                        Console.WriteLine("Inserted Successfully");
                        break;

                    case 2:
                        Console.Write("Employee Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("New Name: ");
                        string newName = Console.ReadLine();

                        Console.Write("New Salary: ");
                        decimal newSalary = Convert.ToDecimal(Console.ReadLine());

                        operations.UpdateRecords(id, newName, newSalary);
                        Console.WriteLine("Updated Successfully");
                        break;

                    case 3:
                        Console.Write("Employee Id: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        operations.DeleteRecords(deleteId);
                        Console.WriteLine("Deleted Successfully");
                        break;

                    case 4:
                        operations.LinqDisplay();
                        break;

                    case 5:
                        operations.Display();
                        break;
                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }

        }
    }
}
