namespace UtilityApp
{
    public class Helper
    {
        /// <summary>
        /// Function to get a valid number from user.
        /// </summary>
        /// <param name="userEnteredNumber">user entered number</param>
        /// <returns>Validated number</returns>
        public static float GetValidNumber(string? userEnteredNumber)
        {
            float validNumber;
            while (!float.TryParse(userEnteredNumber, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number" +
                    " ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                userEnteredNumber = Console.ReadLine();
            }
            return validNumber;
        }

        /// <summary>
        /// Function to get a valid choice from user.
        /// </summary>
        /// <param name="userEnteredChoice">User entered choice</param>
        /// <returns>Validated choice(Integer)</returns>
        public static int GetValidChoice(string? userEnteredChoice)
        {
            int validChoice;
            while (!int.TryParse(userEnteredChoice, out validChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid choice");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                userEnteredChoice = Console.ReadLine();
            }
            return validChoice;
        }
    }
}
