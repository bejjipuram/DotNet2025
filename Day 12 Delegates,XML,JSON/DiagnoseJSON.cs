using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.Json;

namespace CAP2025.Day_12
{
    public class ProcessInfo
    {
        public string ProcessName { get; set; }
        public int Id { get; set; }
    }
    public class DiagnoseJSONMain
    {
        public static void Main(string[] args)
        {
            Process[] p = Process.GetProcesses();
            List<ProcessInfo> ps = new List<ProcessInfo>();
            foreach(Process i in p)
            {
                try
                {
                    ps.Add(new ProcessInfo {ProcessName = i.ProcessName, Id = i.Id});
                }
                catch
                {

                }
            }
            string joi = JsonSerializer.Serialize(ps, new JsonSerializerOptions { WriteIndented=true});
            Console.WriteLine(joi);
        }
    }
}
