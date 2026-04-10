using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_10
{
    public class BigBoy : IDisposable
    {
        public ArrayList Names { get; set; }
        public void Dispose()
        {
            Names = null;
            Console.WriteLine("Working Successful");
        }
        public BigBoy()
        {
            Names = null;
        }
    }
    public class DisposeMain
    {
        public static void Main(string[] args)
        {
            BigBoy bigboy = new BigBoy();
            try
            {
                bigboy.Names = new System.Collections.ArrayList();
                for(int i = 0; i < 10; i++)
                {
                    bigboy.Names.Add(i.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bigboy.Dispose();
            }
        }
    }
}
