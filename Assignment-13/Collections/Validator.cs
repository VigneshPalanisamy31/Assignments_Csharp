using System.Text.RegularExpressions;
namespace Collections
{
    internal class Validator
    {

        /// <summary>
        /// Gets a valid integer from user.
        /// </summary>
        /// <param name="displayMessage">Message to display to the console</param>
        /// <returns>valid integer</returns>
        public static int GetValidInt(string displayMessage)
        {
            while (true)
            {
                Console.WriteLine(displayMessage);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Helper.WriteInColor($"\nInvalid input (required format:positive integer)", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Gets a valid string from user.
        /// </summary>
        /// <param name="displayMessage">Message to display to the console</param>
        /// <returns>valid string</returns>
        public static string GetValidString(string displayMessage)
        {
            while (true)
            {
                Console.WriteLine(displayMessage);
                string? validName = Console.ReadLine();
                if (validName != null && Regex.IsMatch(validName, @"^[A-Za-z][A-Za-z0-9]{2,}"))
                {
                    return validName;
                }
                else
                {
                    Helper.WriteInColor("\nInvalid Input", ConsoleColor.Red);
                }
            }
        }
    }
}
