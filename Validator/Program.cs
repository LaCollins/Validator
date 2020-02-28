using System;
using System.Text.RegularExpressions;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a pin that is between 4-8 numbers long...");
            var pinCode = Console.ReadLine();
            int parsedValue;

            if (pinCode.Length > 3 && pinCode.Length < 9 && int.TryParse(pinCode, out parsedValue))
            {
                Console.WriteLine("Pin is accepted");
            }
            else
            {
                Console.WriteLine("Invalid Pin");
            }

            Console.WriteLine("Please enter a phone number...");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", IsPhoneNumber(phoneNumber) ? "" : "in");

            Console.WriteLine("Please enter an e-mail address...");
            var email = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", IsValidEmail(email) ? "" : "in");

            Console.ReadKey();
        }

        public static bool IsPhoneNumber(string number)
        {
            var numOnly = RemoveNonNumeric(number);
            if (numOnly.Length == 10 && numOnly.Substring(0, 3) != "555")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RemoveNonNumeric(string phoneNum)
        {
            return Regex.Replace(phoneNum, @"[^0-9]+", "");
        }

        internal static bool IsValidEmail(string email)
        {
            bool isValid = ValidEmailRegex.IsMatch(email);

            return isValid;
        }

        static Regex ValidEmailRegex = CreateValidEmailRegex();

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
    }
}
