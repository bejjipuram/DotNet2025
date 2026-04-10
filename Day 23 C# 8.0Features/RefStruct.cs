using System;

namespace CAP2025.Day_23_C__8._0Features
{
    // ref struct - stack-only type
    public ref struct RefStruct
    {
        public void Dispose()
        {
            Console.WriteLine("RefStruct disposed");
        }
    }

    public class RefStructMain
    {
        public static void UseBuffer()
        {
            // C# 8.0 using declaration
            using var buf = new RefStruct();

            Console.WriteLine("Using RefStruct");
        }

        public static void Main(string[] args)
        {
            UseBuffer();
            Console.WriteLine("End of Main");
        }
    }
}

