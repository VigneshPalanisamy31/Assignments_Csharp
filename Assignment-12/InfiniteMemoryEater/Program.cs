//Given code that consumes memory infinitely
namespace InfiniteMemoryEater
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MemoryEater infiniteMemoryEater = new MemoryEater();
            infiniteMemoryEater.Allocate();
        }
    }
}
