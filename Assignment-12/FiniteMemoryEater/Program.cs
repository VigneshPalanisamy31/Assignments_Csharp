namespace FiniteMemoryEater
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MemoryEater finiteMemoryEater = new MemoryEater();
            finiteMemoryEater.Allocate();
        }
    }
}
