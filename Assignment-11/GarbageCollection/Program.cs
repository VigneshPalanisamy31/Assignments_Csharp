namespace GarbageCollection
{
    internal class SampleObject
    {
        public int[] array = new int[10];
        public String[] stringArray = new String[10];
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting memory usage profiling...");
                PrintMemory("\nBefore object creation");
                CreateObjects();
                PrintMemory("\nAfter object creation");
                Console.WriteLine("\nTriggering GC.Collect...");
                GC.Collect();
                PrintMemory("\nAfter garbage collection (GC.Collect)");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Creates multiple objects in a for loop.
        /// </summary>
        public static void CreateObjects()
        {
            const int objectCount = 10000;
            for (int i = 0; i < objectCount; i++)
            {
                SampleObject sampleObject = new SampleObject();
            }
        }

        /// <summary>
        /// Prints current heap memory usage.
        /// </summary>
        /// <param name="displayMessage">Print message</param>
        public static void PrintMemory(string displayMessage)
        {
            long totalMemory = GC.GetTotalMemory(false);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{displayMessage}: {totalMemory / (1024 * 1024)}MB");
            Console.ResetColor();
        }
    }
}
