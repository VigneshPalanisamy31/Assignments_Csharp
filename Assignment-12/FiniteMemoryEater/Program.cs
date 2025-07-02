namespace FiniteMemoryEater
{
    public class MemoryEater
    {
        private List<int[]> memoryAllocator = new List<int[]>();

        /// <summary>
        /// Creates a list of 1000 arrays and then triggers garbage collection.
        /// </summary>
        public void Allocate()
        {
            while (memoryAllocator.Count < 1000)
            {
                memoryAllocator.Add(new int[1000]);
                Thread.Sleep(10);
            }
            GC.Collect();
            Console.WriteLine("Improved memory by restricting loop to a finite limit...");
            Console.ReadKey();
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            MemoryEater finiteMemoryEater = new MemoryEater();
            finiteMemoryEater.Allocate();
        }
    }
}
