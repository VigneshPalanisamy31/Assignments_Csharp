namespace RestrictedInfiniteMemoryEater
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MemoryEater restrictedMemoryEater = new MemoryEater();
            restrictedMemoryEater.Allocate();
        }
    }
}
