using System.Text.RegularExpressions;
namespace Collections
{
    internal class Validator
    {
        /// <summary>
        /// Function to validate user-entered integer value.
        /// </summary>
        /// <param name="displaymsg">Message to display to the console</param>
        /// <returns>valid integer</returns>
        public static int GetValidInt(string displaymsg)
        {
            while(true)
            {
                Console.WriteLine($"\nEnter the {displaymsg} :");
                string? input=Console.ReadLine();
                if(int.TryParse(input, out int value)&&value>0 )
                    return value;
                else
                   Helper.WriteinRed($"\nInvalid {displaymsg} (required format:positive integer");
           }
        }

        /// <summary>
        /// Function to validate user-entered string value.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>valid string</returns>

        public static string GetValidString(string input)
        {
            while (true)
            {
                Console.WriteLine($"\nEnter the {input}");
                string? validName=Console.ReadLine();
                if (validName!=null&&Regex.IsMatch(validName,@"^[A-Za-z][A-Za-z0-9]{2,}"))
                    return validName;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Name");
                    Console.ResetColor();
                }
            }
        }
    }
}
