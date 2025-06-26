using System.Text.RegularExpressions;

namespace LINQ.Utilities
{
    internal class Helper
    {
        /// <summary>
        /// Function to print the given statement in red color.
        /// </summary>
        /// <param name="displayMessage">Message that is to be printed in colors</param>
        public static void WriteInRed(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to print the given statement in green color.
        /// </summary>
        /// <param name="displayMessage">Message that is to be printed in colors</param>
        public static void WriteInGreen(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to print the given statement in yellow color.
        /// </summary>
        /// <param name="displayMessage">Message that is to be printed in colors</param>
        public static void WriteInYellow(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to get a valid integer input from user.
        /// </summary>
        /// <param name="displayMessage">Message that is to be printed in console</param>
        /// <returns>Valid Integer</returns>
        public static int GetValidNumber(string displayMessage)
        {
            bool canExit = false;
            Console.WriteLine($"Enter {displayMessage}");
            while (!canExit)
            {
                canExit = int.TryParse(Console.ReadLine(), out int number);
                if (canExit && number > 0)
                    return number;
                else
                {
                    Helper.WriteInRed($"Please enter a valid {displayMessage}");
                    canExit = false;
                }
                if (displayMessage.Contains("stock quantity"))
                    Helper.WriteInYellow("(Quantity must be a whole number)");
            }
            return 0;
        }

        /// <summary>
        /// Function to get a valid name from user.
        /// </summary>
        /// <param name="displayMessage">Message that is to be printed in console</param>
        /// <returns>Validated name</returns>
        public static string GetValidName(string displayMessage)
        {
            bool canExit = false;
            Console.WriteLine($"Enter {displayMessage}");
            while (!canExit)
            {
                string? name = Console.ReadLine();
                canExit = Regex.IsMatch(name, @"^[A-Za-z]+([ '-.]*[A-Za-z0-9]+)*$");
                if (canExit)
                    return name;
                else
                    Helper.WriteInRed($"Please enter a valid {displayMessage}");
            }
            return string.Empty;
        }

        /// <summary>
        /// Function to validate price given by user.
        /// </summary>
        /// <returns>Valid Price</returns>
        public static decimal GetValidPrice()
        {
            bool canExit = false;
            Console.WriteLine($"Enter the price :");
            do
            {
                canExit = decimal.TryParse(Console.ReadLine(), out decimal validPrice);
                if (canExit)
                    return validPrice;
                else
                    Helper.WriteInRed($"Please enter a valid price:");
            } while (!canExit);
            return 0;
        }

        /// <summary>
        /// Function to get a number from user
        /// </summary>
        /// <param name="displayMessage">Message that is to be printed in console</param>
        /// <returns>Valid Number</returns>
        public static float GetValidFloat(string displayMessage)
        {
            bool canExit = false;
            Console.WriteLine($"Enter {displayMessage}");
            while (!canExit)
            {
                canExit = float.TryParse(Console.ReadLine(), out float validNumber);
                if (canExit && validNumber > 0)
                    return validNumber;
                else
                {
                    Helper.WriteInRed($"Please enter a valid {displayMessage}");
                }
            }
            return 0;
        }

    }
}
