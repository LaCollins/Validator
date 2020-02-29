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
            bool lowerOdds = false;
            bool lowerEvens = false;
            bool upperOdds = false;
            bool upperEvens = false;
            var isMocking = false;

            //Validate a pin

            Console.WriteLine("Please enter a pin that is between 4-8 numbers long...");
            var pinCode = Console.ReadLine();

            if (pinCode.Length > 3 && pinCode.Length < 9 && int.TryParse(pinCode, out parsedValue))
                Console.WriteLine("Pin is accepted");
            else
                Console.WriteLine("Invalid Pin");

            //Validate a phone number

            Console.WriteLine("Please enter a phone number...");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", IsPhoneNumber(phoneNumber) ? "" : "in");

            //Validate an e-mail

            Console.WriteLine("Please enter an e-mail address...");
            var email = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", ValidEmailRegex.IsMatch(email) ? "" : "in");

            //Validate spongebop style mockery

            Console.WriteLine("Say something...");
            var mockingText = Console.ReadLine();

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

            //Validate a power ranger
            Console.WriteLine("Name an original power ranger...");
            var rangerName = Console.ReadLine();

            switch (rangerName)
            {
                case "Jason Lee Scott":
                    Console.WriteLine("Correct, he was the Red Ranger");
                    break;
                case "Geki":
                    Console.WriteLine("Correct, he was the Red Ranger");
                    break;
                case "Zack Taylor":
                    Console.WriteLine("Correct, he was the Black Ranger");
                    break;
                case "Goushi":
                    Console.WriteLine("Correct, he was the Black Ranger");
                    break;
                case "Trini Kwan":
                    Console.WriteLine("Correct, she was the Yellow Ranger");
                    break;
                case "Boi":
                    Console.WriteLine("Correct, he was the Yellow Ranger");
                    break;
                case "Kimberly Hart":
                    Console.WriteLine("Correct, she was the Pink Ranger");
                    break;
                case "Mei":
                    Console.WriteLine("Correct, she was the Pink Ranger");
                    break;
                case "Dan":
                    Console.WriteLine("Correct, he was the Blue Ranger");
                    break;
                case "Burai":
                    Console.WriteLine("Correct, he was the Green Ranger");
                    break;
                case "Tommy Oliver":
                    Console.WriteLine("Correct, he was the Green Ranger");
                    break;
                default:
                    Console.WriteLine("That is not a Power Ranger.");
                    break;
            }

            Console.ReadKey();
        }


        public static bool IsPhoneNumber(string number) //Regex for checking valid phone number
        {
            string numOnly = Regex.Replace(number, @"[^0-9]+", "");
            if (numOnly.Length == 10 && numOnly.Substring(0, 3) != "555")
                return true;
            else
                return false;
        }

        private static Regex CreateValidEmailRegex() //Regex for checking valid e-mail
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
    }
}
