using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_20
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
    }

    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException(string message) : base(message) { }
    }

    public class UserAuthentication
    {
        public User ValidatePassword(string name, string password, string confirmationPassword)
        {
            if (!password.Equals(confirmationPassword, StringComparison.Ordinal)) // case-sensitive
                throw new PasswordMismatchException("Password entered does not match");

            return new User
            {
                Name = name,
                Password = password,
                ConfirmationPassword = confirmationPassword
            };
        }

        public static void Main()
        {
            UserAuthentication p = new UserAuthentication();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter password: ");
            string pass = Console.ReadLine();

            Console.Write("Confirm password: ");
            string confirm = Console.ReadLine();

            try
            {
                User u = p.ValidatePassword(name, pass, confirm);
                Console.WriteLine("Registered Successfully");
            }
            catch (PasswordMismatchException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
