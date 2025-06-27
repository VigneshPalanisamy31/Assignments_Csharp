using System.Text.RegularExpressions;
namespace Collections
{
    internal class Validator
    {
        /// <summary>
        /// Function to validate user-entered integer value.
        /// </summary>
        /// <param name="displayMessage">Message to display to the console</param>
        /// <returns>valid integer</returns>
        public static int GetValidInt(string displayMessage)
        {
            while(true)
            {
                Console.WriteLine($"\nEnter the {displayMessage} :");
                string? input=Console.ReadLine();
                if(int.TryParse(input, out int value)&&value>0 )
                    return value;
                else
                   Helper.WriteInColor($"\nInvalid {displayMessage} (required format:positive integer",ConsoleColor.Red);
           }
        }

        /// <summary>
        /// Function to validate user-entered string value.
        /// </summary>
        /// <param name="displayMessage">Message to display to the console</param>
        /// <returns>valid string</returns>

        public static string GetValidString(string displayMessage)
        {
            while (true)
            {
                Console.WriteLine($"\nEnter the {displayMessage}");
                string? validName=Console.ReadLine();
                if (validName!=null&&Regex.IsMatch(validName,@"^[A-Za-z][A-Za-z0-9]{2,}"))
                    return validName;
                else
                {
                    Helper.WriteInColor("\nInvalid Name", ConsoleColor.Red);
                }
            }
        }
    }
}
