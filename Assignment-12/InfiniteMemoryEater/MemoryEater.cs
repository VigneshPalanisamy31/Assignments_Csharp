namespace InfiniteMemoryEater
{
    public class MemoryEater
    {
        private List<int[]> _memoryAllocator = new List<int[]>();

        /// <summary>
        /// Creates arrays infinitely
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                _memoryAllocator.Add(new int[1000]);
                Thread.Sleep(10);
            }
        }
    }
}
