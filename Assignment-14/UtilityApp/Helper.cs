namespace UtilityApp
{
    public class Helper
    {
        /// <summary>
        /// Function to get a valid number from user.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Validated number</returns>
        public static float GetValidNumber(string? input)
        {
            float validNumber;
            while (!float.TryParse(input, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number" +
                    " ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                input = Console.ReadLine();
            }
            return validNumber;
        }

        /// <summary>
        /// Function to get a valid choice from user.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Validated choice(Integer)</returns>
        public static int GetValidChoice(string? input)
        {
            int validChoice;
            while (!int.TryParse(input, out validChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid choice");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                input = Console.ReadLine();
            }
            return validChoice;
        }
    }
}
