namespace LoggingSystem
{
    public class LoggerUtils
    {
        /// <summary>
        /// Reads a choice from user
        /// </summary>
        /// <returns>user's choice</returns>
        public static int ReadChoice()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
                    return choice;
                Console.Write("Invalid choice. Please enter 1 or 2: ");
            }
        }

        /// <summary>
        /// Gets a positive integer from user.
        /// </summary>
        /// <returns>positive integer</returns>
        public static int ReadIntInput()
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