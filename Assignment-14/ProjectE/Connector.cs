using DisplayApp;
namespace ProjectE
{
    public class Connector
    {
        /// <summary>
        /// Function to connect the displayer.
        /// </summary>
        public static void DisplayConnector()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPlease hang in there while we get the application up for you");
            for(int i=0;i<3;i++)
            {
                Console.Write(". ");
                Thread.Sleep(1000);
            }
            Console.ResetColor();
            Console.WriteLine("\n");
            Displayer.ConsoleDisplay();
        }
    }
}
