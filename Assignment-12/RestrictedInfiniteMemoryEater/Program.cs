namespace RestrictedInfinteMemoryEater
{
    public class MemoryEater
    {
        private List<int[]> memoryAllocator = new List<int[]>();

        /// <summary>
        /// Create List of Arrays infinitely but triggers garbage collection after every 1000 arrays
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                memoryAllocator.Add(new int[1000]);
                Console.WriteLine(memoryAllocator.Count);
                if (memoryAllocator.Count > 1000)
                {
                    Console.WriteLine("Clearing memory list to prevent overflow...");
                    memoryAllocator.Clear();
                    GC.Collect();
                    Thread.Sleep(1000);
                }
            }
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            MemoryEater restrictedMemoryEater = new MemoryEater();
            restrictedMemoryEater.Allocate();
        }
    }
}
