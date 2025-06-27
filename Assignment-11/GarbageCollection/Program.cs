namespace GarbageCollection
{
    class SampleObject
    {
        public int[] array = new int[10];
        public String[] stringarray = new String[10];
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting memory usage profiling...");
                PrintMemory("\nBefore object creation");
                CreateObjects();
                PrintMemory("\nAfter object creation");
                Console.WriteLine("\nTriggering GC.Collect...");
                GC.Collect();
                PrintMemory("\nAfter GC.Collect");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Function to create multiple objects in a for loop.
        /// </summary>
        static void CreateObjects()
        {
            const int objectCount = 10000;
            for (int i = 0; i < objectCount; i++)
            {
                SampleObject obj = new SampleObject();
            }
        }

        /// <summary>
        /// Function to print current heap memory usage.
        /// </summary>
        /// <param name="label">Print message</param>
        static void PrintMemory(string label)
        {
            long totalMemory = GC.GetTotalMemory(false);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{label}: {totalMemory / (1024 * 1024)}MB");
            Console.ResetColor();
        }
    }
}
