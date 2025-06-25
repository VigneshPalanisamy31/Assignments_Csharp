namespace Collections
{
    internal class Helper
    {
        /// <summary>
        /// Function to display message in red color
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in colors</param>
        public static void WriteinRed(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
        /// <summary>
        /// Function to display message in green color
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in colors</param>
        public static void WriteinGreen(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
        /// <summary>
        /// Function to display message in yellow color
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in colors</param>
        public static void WriteinYellow(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
    }
}
