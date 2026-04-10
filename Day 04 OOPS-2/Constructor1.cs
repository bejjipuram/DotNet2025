using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day4
{
    /// <summary>
    /// class in which constructor is created
    /// </summary>
    public class Constructor1
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Result { get;}

        /// <summary>
        /// constructor for calculating or adding two numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public Constructor1(int num1, int num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
            this.Result = num1 + num2; //only in constructor get properties can be set(result have only get in declaration but we have set the value in the constructor)
            //Console.WriteLine("Result is ",result);
        }
    }
    /// <summary>
    /// main class in which the object is created
    /// </summary>
    public class Constructor1Main
    {
        public static void Main(string[] args)
        {
            Constructor1 cons = new Constructor1(10, 20);
            Console.Write("The total is "+ cons.Result);
        }
    }
}
