using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_46_M1Practice.LogAnalyzer.Models
{
    public class LogEntry
    {
        public string User { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
        public string IP { get; set; }
    }
}
