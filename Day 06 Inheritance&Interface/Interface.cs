using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_6
{
    /// <summary>
    /// this program is an example for interface class and how it works is demonstrated in here. In interface class we only define the methods, we dont initiate them
    /// </summary>
    public interface IPrint
    {
        public void Print();
    }
    /// <summary>
    /// this is a child class which inherits the interface class
    /// </summary>
    public class Child : IPrint
    {
        /// <summary>
        /// the method is already defined in the parent class that is an interface class, here in the child class we are initializing the method
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Output");
        }
    }
    public class InterfaceMain
    {
        /// <summary>
        /// in this mian method we are creating an object and calling the function using it.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IPrint c = new Child();
            c.Print();
        }
    }
}
