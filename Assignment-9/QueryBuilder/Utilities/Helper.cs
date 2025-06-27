using System.Text.RegularExpressions;

namespace LINQ.Utilities
{
    internal class Helper
    {
        /// <summary>
        /// Prints the given message in the specified console color.
        /// </summary>
        /// <param name="displayMessage">The message to display.</param>
        /// <param name="color">The ConsoleColor to use.</param>
        public static void WriteInColor(string displayMessage, ConsoleColor color)
        {
            Console.ForegroundColor = color;
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
                    Helper.WriteInColor($"Please enter a valid {displayMessage}",ConsoleColor.Red);
                    canExit = false;
                }
                if (displayMessage.Contains("stock quantity"))
                    Helper.WriteInColor("(Quantity must be a whole number)",ConsoleColor.Yellow);
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
                    Helper.WriteInColor($"Please enter a valid {displayMessage}", ConsoleColor.Red);
            }
            return string.Empty;
        }

        /// <summary>
        /// Function to get valid price from user
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
                    Helper.WriteInColor($"Please enter a valid price:", ConsoleColor.Red);
            } while (!canExit);
            return 0;
        }

        /// <summary>
        /// Function to get a valid number from user
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
                    Helper.WriteInColor($"Please enter a valid {displayMessage}", ConsoleColor.Red);
                }
            }
            return 0;
        }

    }
}
