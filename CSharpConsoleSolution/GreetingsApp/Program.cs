using ProjectE;
namespace GreetingApp
{
    public class Program
    {
        public static void Main(string[]args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWelcome to our application\n");
            Console.ResetColor();
            Connector.DisplayConnector();
            
           
        }
    }
}