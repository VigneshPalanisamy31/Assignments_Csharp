using System.Diagnostics;
namespace DynamicSerializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch serializerTimer = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
                Console.WriteLine(Serializer.Serialize(new Product("Bat", i, "Sports", 10000)));
            serializerTimer.Stop();


            Stopwatch emitSerializerTimer = Stopwatch.StartNew();
            Func<Product,string> serializer = EmitSerializer.CreateSerializer<Product>();
            for (int i = 0; i < 1000; i++)
                Console.WriteLine(serializer(new Product("Bat",i,"Sports",10000)));
            emitSerializerTimer.Stop();

            Console.WriteLine($"Reflection: {(double)serializerTimer.ElapsedMilliseconds/1000}s");
            Console.WriteLine($"Emit: {(double)emitSerializerTimer.ElapsedMilliseconds/1000}s");
            Console.ReadKey();
        }
    }
}
