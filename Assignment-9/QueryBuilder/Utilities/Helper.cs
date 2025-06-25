namespace LINQ.Utilities
{
    internal class Helper
    {
        /// <summary>
        /// Function to print the given statement in red color.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInRed(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to print the given statement in green color.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInGreen(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to print the given statement in yellow color.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInYellow(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }
    }
}
