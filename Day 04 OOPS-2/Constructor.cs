using System;

namespace CAP2025.Day4
{
    /// <summary>
    /// class Visitor in which i have created constructors(default, parameterized(single, double, triple)) and accessed through the main class
    /// </summary>
    public class Visitor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Requirement { get; set; }
        public string LogHistory { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Visitor()
        {
            LogHistory = $"Object created at {DateTime.Now.ToString()}\n";
        }
        /// <summary>
        /// constructor with only single parameter
        /// </summary>
        /// <param name="id"></param>
        public Visitor(int id):this()
        {
            this.ID=id;
            LogHistory += $"ID is created at {DateTime.Now.ToString()}\n";
        }
        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Visitor(int id, string name):this(id)
        {
            ///<summary>
            ///this if condition checks the name parameter and if there is a "bad" word then it will throw the message that is written in the quotes
            /// </summary>
            if (name.ToLower().Contains("bad"))
                throw new Exception("Do not enter such words");
            this.Name = name;
            LogHistory += $"Name is created at {DateTime.Now.ToString()}\n";
        }
        /// <summary>
        /// constructor with three parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="requirement"></param>
        public Visitor(int id, string name, string requirement) : this(id,name)
        {
            this.Requirement = requirement;
            LogHistory += $"Requirement is created at {DateTime.Now.ToString()}\n";
        }


    }
    public class Constructor
    {
        public static void Main(string[] args)
        {
            /// <summary>
            /// here in this object, it will call the constructor based on the initialization
            /// </summary>
            try
            {
                Visitor visitor = new Visitor(12204083, "Bejjipuram Indra Kumar", "Please accept the request");
                Console.WriteLine($"ID: {visitor.ID}\nName: {visitor.Name}\nRequirement: {visitor.Requirement}");
                Console.WriteLine($"Log Histroy: \n{visitor.LogHistory}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
