using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// in this program we are harnessing the field examples
/// </summary>
    public class Employee
    {
        private int id;

        public int Id
        {
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    id = 0;
                    throw new InvalidOperationException("How id can be less than Zero");
                }
            }
        }

        public string DisplayEmpDetails()
        {
            return $"Employee Id is {id}";
        }
    }
    public class CallField
    {
        public static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Id = 100;
            //Console.WriteLine(employee.id);
            string result = employee.DisplayEmpDetails();
            Console.WriteLine(result);
        }
    }