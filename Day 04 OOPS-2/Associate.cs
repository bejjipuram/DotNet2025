using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day4
{
    /// <summary>
    /// here in this program we are practicing the field applications and storing the errors in a single variable and printing it in a single go
    /// </summary>
    public class Associate
    {
        private int id;
        private string name;
        private int rank;
        public string Error;
        public int Id
        {
            set
            {
                if (value > 0)
                {
                    id=value;
                }
                else
                {
                    Error += "Id must be greater than zero\n";
                }
            }
        }
        public string Name
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name=value;
                }
                else
                {
                    Error += "Name must be entered\n"; 
                }
            }
        }
        /// <summary>
        /// we are incrementing the error varibale so that all the errors will be stored and can not be over written
        /// </summary>
        public int Rank
        {
            set
            {
                if (value > 0)
                {
                    rank=value;
                }
                else
                {
                    Error += "Rank must be greater than zero\n";
                }
            }

        }
        public string DisplayDetails()
        {
            return $"Employee Details: \nID: {id}\nName: {name}\nRank: {rank}";
        }
    }
    public class AssociateMain
    {
        public static void Main(string[] args)
        {
            Associate asco = new Associate();
            asco.Id = 12204083;
            asco.Name = string.Empty;
            asco.Rank = -1;
            string result = asco.DisplayDetails();
            Console.WriteLine(asco.Error);
            Console.WriteLine(result);
        }
    }
}
