using ProjectE;
namespace GreetingApp
{
    public class Program
    {
        public static void Main(string[]args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWelcome to our application\n");
                Console.ResetColor();
                Connector.DisplayConnector();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Execution interrupted due to an unexpected error.\n{e.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you...");
                Thread.Sleep(1000);
            }
        }
    }
}