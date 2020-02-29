using System;
using System.Text.RegularExpressions;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex ValidEmailRegex = CreateValidEmailRegex();
            int parsedValue; // used to hold out variable
            string mockingText;
            bool lowerOdds = false;
            bool lowerEvens = false;
            bool upperOdds = false;
            bool upperEvens = false;
            var isMocking = false;

            Console.WriteLine("Please enter a pin that is between 4-8 numbers long...");
            var pinCode = Console.ReadLine();

            if (pinCode.Length > 3 && pinCode.Length < 9 && int.TryParse(pinCode, out parsedValue))
                Console.WriteLine("Pin is accepted");
            else
                Console.WriteLine("Invalid Pin");

            Console.WriteLine("Please enter a phone number...");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", IsPhoneNumber(phoneNumber) ? "" : "in");

            Console.WriteLine("Please enter an e-mail address...");
            var email = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", ValidEmailRegex.IsMatch(email) ? "" : "in");

            Console.WriteLine("Say something...");
            mockingText = Console.ReadLine();

            mockingText = mockingText.Replace(" ", "");

            for (int i = 0; i < mockingText.Length; i++)
            {
                if (i % 2 != 0)
                {
                    lowerOdds = char.IsLower(mockingText[i]);
                    upperOdds = char.IsUpper(mockingText[i]);
                }
                else
                {
                    upperEvens = char.IsUpper(mockingText[i]);
                    lowerEvens = char.IsLower(mockingText[i]);
                }


                if (lowerOdds && upperEvens || lowerEvens && upperOdds)
                {
                    isMocking = true;
                }
                else
                {
                    isMocking = false;
                }
            }

            if(isMocking == true)
            {
                Console.WriteLine("Are you mocking me?");
            }
            else
            {
                Console.WriteLine("At least you're not mocking me.");
            }

            Console.ReadKey();
        }

        public static bool IsPhoneNumber(string number)
        {
            string numOnly = Regex.Replace(number, @"[^0-9]+", "");
            if (numOnly.Length == 10 && numOnly.Substring(0, 3) != "555")
                return true;
            else
                return false;
        }

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
    }
}
