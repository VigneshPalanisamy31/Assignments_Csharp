namespace RestrictedInfinteMemoryEater
{
    public class MemoryEater
    {
        List<int[]> memoryAllocator = new List<int[]>();

        /// <summary>
        /// Function to create List of Arrays infinitely and trigger garbage collection after every 1000 arrays
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
        static void Main(string[] args)
        {
            MemoryEater restrictedMemoryEater = new MemoryEater();
            restrictedMemoryEater.Allocate();
        }
    }
}
