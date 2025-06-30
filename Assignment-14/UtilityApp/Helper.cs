namespace UtilityApp
{
    public class Helper
    {
        /// <summary>
        /// Function to get a valid number from user.
        /// </summary>
        /// <param name="userEnteredNumber">user entered number</param>
        /// <returns>Validated number</returns>
        public static float GetValidNumber()
        {
            string inputNumber=Console.ReadLine();
            float validNumber;
            while (!float.TryParse(inputNumber, out validNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                inputNumber = Console.ReadLine();
            }
            return validNumber;
        }

        /// <summary>
        /// Function to get a valid choice from user.
        /// </summary>
        /// <param name="userEnteredChoice">User entered choice</param>
        /// <returns>Validated choice(Integer)</returns>
        public static int GetValidChoice()
        {
            string choice=Console.ReadLine();
            int validChoice;
            while (!int.TryParse(choice, out validChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid choice");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                choice = Console.ReadLine();
            }
            return validChoice;
        }
    }
}
