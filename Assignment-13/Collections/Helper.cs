namespace Collections
{
    internal class Helper
    {
        /// <summary>
        /// Function to display message in given color
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in colors</param>
        public static void WriteInColor(string displayMessage,ConsoleColor color)
        {
            Console.ForegroundColor=color;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
    }
}
