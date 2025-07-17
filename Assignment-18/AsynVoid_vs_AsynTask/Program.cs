using System;
using System.Threading.Tasks;

namespace AsyncVoid_vs_AsyncTask
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Async Void vs Async Task Exception Handling ===");
            Console.ResetColor();
            // Async Task - exception can be awaited and caught
            Console.WriteLine("\nCalling async Task method...");
            try
            {
                await TaskMethod(); //Can be awaited and exception caught
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception from TaskMethod: {ex.Message}");
            }

            Console.WriteLine("\nCalling async void method...");
            try
            {
                VoidMethod(); // Cannot be awaited, exception will crash the app
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception from VoidMethod: {ex.Message}");
            }

            await Task.Delay(1000); // Give VoidMethod time to throw (unhandled)

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Async void - exception can't be caught outside
        static async void VoidMethod()
        {
            await Task.Delay(500);
            throw new Exception("Exception from async void method");
        }


        static async Task TaskMethod()
        {
            await Task.Delay(500);
            throw new Exception("Exception from async Task method");
        }
    }
}
