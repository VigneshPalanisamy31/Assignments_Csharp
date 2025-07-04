namespace FiniteMemoryEater
{
    public class MemoryEater
    {
        private List<int[]> _memoryAllocator = new List<int[]>();

        /// <summary>
        /// Creates a list of 1000 arrays and then triggers garbage collection.
        /// </summary>
        public void Allocate()
        {
            while (_memoryAllocator.Count < 1000)
            {
                _memoryAllocator.Add(new int[1000]);
                Thread.Sleep(10);
            }
            GC.Collect();
            Console.WriteLine("Improved memory consumption by restricting the loop to a finite limit...");
            Console.ReadKey();
        }
    }
}
