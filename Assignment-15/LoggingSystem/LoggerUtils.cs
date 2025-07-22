namespace LoggingSystem
{
    public class LoggerUtils
    {

        /// <summary>
        /// Gets a positive integer from user.
        /// </summary>
        /// <returns>positive integer</returns>
        public static int GetValidInteger()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number > 0)
                    return number;
                Console.Write("Please enter a valid positive number: ");
            }
        }
    }
}