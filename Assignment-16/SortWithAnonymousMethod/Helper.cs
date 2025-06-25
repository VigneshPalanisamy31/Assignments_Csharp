namespace SortWithAnonymousMethod
{
    public class Helper
    {
        /// <summary>
        /// Gets valid number from user
        /// </summary>
        /// <param name="displayMessage">Message to be displayed to the console</param>
        /// <returns>a valid integer</returns>
        public static int GetValidInteger(string displayMessage)
        {
            Console.WriteLine($"Enter{displayMessage}:");
            string userInput=Console.ReadLine();
            int validNumber;
            while (!int.TryParse(userInput, out validNumber))
            {
                Console.WriteLine("Invalid Number!!\n");
                Console.WriteLine($"Enter{displayMessage}");
            }
            return validNumber;
        }
    }
}
