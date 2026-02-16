using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_42_M1Practice.SmartBank
{
    public class InvalidCreditException : Exception
    {
        public InvalidCreditException(string message) : base(message)
        {

        }
    }
}
