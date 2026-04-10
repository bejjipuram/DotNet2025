using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_20
{
    public class UserMember
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string message) : base(message) { }
    }

    public class UserVerification
    {
        public UserMember ValidatePhoneNumber(string name, string phoneNumber)
        {
            if (phoneNumber != null && phoneNumber.Length == 10)
            {
                return new UserMember
                {
                    Name = name,
                    PhoneNumber = phoneNumber
                };
            }

            throw new InvalidPhoneNumberException("Invalid phone number");
        }

        public static void Main()
        {
            UserVerification p = new UserVerification();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            try
            {
                UserMember u = p.ValidatePhoneNumber(name, phone);
                Console.WriteLine("User Verified");
            }
            catch (InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
