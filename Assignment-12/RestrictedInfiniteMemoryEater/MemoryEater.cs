namespace RestrictedInfiniteMemoryEater
{
    public class MemoryEater
    {
        private List<int[]> _memoryAllocator = new List<int[]>();

        /// <summary>
        /// Create List of Arrays infinitely but triggers garbage collection after every 1000 arrays
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                _memoryAllocator.Add(new int[1000]);
                Console.WriteLine(_memoryAllocator.Count);
                if (_memoryAllocator.Count > 1000)
                {
                    Console.WriteLine("Clearing memory list to prevent overflow...");
                    _memoryAllocator.Clear();
                    GC.Collect();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
