namespace Collections
{
    internal class Helper
    {

        /// <summary>
        /// Displays message in given color
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in colors</param>
        /// <param name="color">Console color in which the message is supposed to be displayed</param>
        public static void WriteInColor(string displayMessage, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
    }
}


