namespace ConfigureAwaitInThreadTracking
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            int result = await ProcessDataAsync();
            Console.WriteLine($"Final result: {result}");
            Console.ReadKey();
        }

        static async Task<int> SimulateHeavyWorkAsync()
        {
            Console.WriteLine($"[MethodA] Before await - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            // Simulate long-running operation
            await Task.Delay(2000).ConfigureAwait(false);

            Console.WriteLine($"[MethodA] After await - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            return GetNumber();
        }

        public static int GetNumber()
        {
            int number;
            Console.Write("Enter a integer to get its square: ");

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
            }
            return number;
        }
        static async Task<int> ProcessDataAsync()
        {
            Console.WriteLine($"[MethodB] Before awaiting MethodA - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            int value = await SimulateHeavyWorkAsync();

            Console.WriteLine($"[MethodB] After awaiting MethodA - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            // Simulate further processing
            int processedValue = value * value;

            return processedValue;
        }
    }
}