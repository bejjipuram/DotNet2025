using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day4
{
    /// <summary>
    /// this program demonstrates that if you use virtual keyword in method in parent class and override keyword in method in child class it will override the parent class method.
    /// </summary>
    public class Father
    {
        public virtual string InterestOn()
        {
            return "I like to play cricket";
        }
    }
    public class Son : Father
    {
        public override string InterestOn()
        {
            return "Mobile Games";
        }
    }
    /// <summary>
    /// main class in which the object is created and been called
    /// </summary>
    public class Virtual
    {
        public static void Main(string[] args)
        {
            Father f = new Son();
            string result= f.InterestOn();
            Console.WriteLine(result);
        }
    }
}
