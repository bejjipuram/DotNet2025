using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_12
{
    public delegate int DelegateAddFunctionName(int a, int b);
    public class Delegate
    {
        public void DeligateMethod()
        {
            DelegateAddFunctionName deleg = new DelegateAddFunctionName(AddMethod);
            int result = deleg(1, 2);
            Console.WriteLine("Result: "+result);
        }
        private int AddMethod(int a, int b)
        {
            return a + b;
        }
    }
    public class DelegateMain
    {
        public static void Main(string[] args)
        {
            Delegate del = new Delegate();
            del.DeligateMethod();
            Console.ReadLine();
        }
    }
}
