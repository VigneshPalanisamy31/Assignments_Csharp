using System.Diagnostics;
namespace LoggingSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                bool canExit = false;
                while (!canExit)
                {
                    Console.WriteLine("Choose Logging Method:");
                    Console.WriteLine("1. Shared Log File (thread-safe)");
                    Console.WriteLine("2. Independent Log File Per User");
                    Console.WriteLine("3. Compare Sync and Async Logging");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = LoggerUtils.GetValidInteger();
                    if (choice > 0 && choice < 3)
                    {
                        Console.Write("\nEnter number of users to simulate: ");
                        int userCount = LoggerUtils.GetValidInteger();
                        Console.Write("\nEnter the error message to log: ");
                        string errorMessage = Console.ReadLine() ?? "Default Error Message";
                        Console.Write("\nEnter the file path to log shared log messages: ");
                        string filePath = Console.ReadLine() ?? "logger.log";
                        Console.WriteLine("\nLogging in progress...");
                        Logger logger = new(filePath);
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        if (choice == 1)
                        {
                            var tasks = Enumerable.Range(0, userCount)
                                .Select(i => logger.LogErrorThreadSafe($"User{i}: {errorMessage}{Environment.NewLine}"));
                            await Task.WhenAll(tasks);
                        }
                        else
                        {
                            var tasks = Enumerable.Range(0, userCount)
                                .Select(i => logger.LogErrorInUserSpecificFile($"user{i}", $"{errorMessage}{Environment.NewLine}"));
                            await Task.WhenAll(tasks);
                        }
                        stopwatch.Stop();
                        Console.WriteLine($"\nDone! Logging completed in {stopwatch.ElapsedMilliseconds} ms.");
                    }
                    else if (choice == 3)
                    {
                        CompareSyncAndAsyncLoggers();
                    }
                    else if (choice == 4)
                    {
                        canExit = true;
                    }
                    else
                    {
                        Console.WriteLine("Choose from given choices.");
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Execution interrupted!!!\n" + e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Function to compare Synchronous and Asynchronous loggers.
        /// </summary>
        private static void CompareSyncAndAsyncLoggers()
        {
            Console.Write("\nEnter the error message to log: ");
            string errorMessage = Console.ReadLine() ?? "Default Error Message";
            Console.Write("\nEnter the file path to log shared log messages: ");
            string filePath = Console.ReadLine() ?? "logger.log";
            Logger logger = new(filePath);
            Console.WriteLine("---Sync logger---");
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            logger.LogErrorInefficiently(errorMessage);
            stopwatch.Stop();
            Console.WriteLine("TimeTaken: " + stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine("---Async logger---");
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            stopwatch2.Start();
            logger.LogErrorEfficiently(errorMessage);
            stopwatch2.Stop();
            Console.WriteLine("TimeTaken: " + stopwatch2.ElapsedMilliseconds + "ms");
        }
    }
}
