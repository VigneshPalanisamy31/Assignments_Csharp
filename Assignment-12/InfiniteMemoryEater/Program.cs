//Given code that consumes memory infinitely
namespace InfiniteMemoryEater
{
    public class MemoryEater
    {
        List<int[]> memoryAllocator = new List<int[]>();

        /// <summary>
        /// Creates arrays infinitely
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                memoryAllocator.Add(new int[1000]);
                Thread.Sleep(10);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryEater infiniteMemoryEater = new MemoryEater();
            infiniteMemoryEater.Allocate();
        }
    }
}
