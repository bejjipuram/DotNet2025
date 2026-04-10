using CAP2025.Day_46_M1Practice.LogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_46_M1Practice.LogAnalyzer.Services
{
    public class LogAnalyzerValidations
    {
        public string AnalyzeLog(string log)
        {
            LogEntry entry = ParseLog(log);
            if (entry == null)
            {
                return "INVALID: Log format incorrect";

            }
            string validationResult = ValidateLog(entry);
            if (validationResult != "VALID")
            {
                return "INVALID: " + validationResult;
            }
            return $"VALID: {entry.User} performed {entry.Action} from {entry.IP}";
        }
        private LogEntry ParseLog(string log)
        {
            if (string.IsNullOrWhiteSpace(log))
            {
                return null;
            }
            string[] parts = log.Split('|');
            LogEntry entry = new LogEntry();
            foreach (string part in parts)
            {
                string[] keyValue = part.Split(':');
                if (keyValue.Length != 2)
                {
                    continue;
                }
                string key = keyValue[0].Trim().ToLower();
                string value = keyValue[1].Trim();
                switch (key)
                {
                    case "user":
                        entry.User = value;
                        break;
                    case "action":
                        entry.Action = value.ToLower();
                        break;
                    case "status":
                        entry.Status = value;
                        break;
                    case "ip":
                        entry.IP = value;
                        break;
                }
            }
            return entry;
        }
        private string ValidateLog(LogEntry entry)
        {
            if (string.IsNullOrEmpty(entry.User))
            {
                return "Missing USER";
            }
            if (!IsValidUser(entry.User))
            {
                return "Invalid UserName";

            }
            if (string.IsNullOrEmpty(entry.Action))
            {
                return "Missing ACTION";
            }
            if (!IsValidAction(entry.Action))
            {
                return "Invalid Action";
            }
            if (string.IsNullOrEmpty(entry.Status))
            {
                return "Missing STATUS";
            }
            if (!IsValidStatus(entry.Status))
            {
                return "Invalid STATUS";
            }
            if (string.IsNullOrEmpty(entry.IP))
            {
                return "Missing IP";
            }
            if (!IsValidIP(entry.IP))
            {
                return "Invalid IP Address";
            }
            return "VALID";
        }
        private bool IsValidUser(string user)
        {
            foreach(char c in user)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }

            }
            return true;
        }
        private bool IsValidAction(string action)
        {
            return action == "login" || action == "logout" || action == "upload" || action == "download";
        }
        private bool IsValidStatus(string status)
        {
            return status == "success" || status == "failure";
        }
        private bool IsValidIP(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length != 4)
            {
                return false;
            }
            foreach(string part in parts)
            {
                if(!int.TryParse(part,out int number))
                {
                    return false;
                }
                if (number < 0 || number > 255)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
