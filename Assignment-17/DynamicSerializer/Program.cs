using System.Diagnostics;
namespace DynamicSerializer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Product product = new("Bat", 10, "Sports", 10000);
                Stopwatch serializerTimer = Stopwatch.StartNew();
                for (int i = 0; i < 100000; i++)
                    Serializer.Serialize(product);
                serializerTimer.Stop();
                Stopwatch emitSerializerTimer = Stopwatch.StartNew();
                Func<Product, string> serializer = EmitSerializer.CreateSerializer<Product>();
                for (int i = 0; i < 100000; i++)
                    serializer(product);
                emitSerializerTimer.Stop();
                Console.WriteLine($"Reflection Serializer: {(double)serializerTimer.ElapsedMilliseconds / 1000}s");
                Console.WriteLine($"Emit Serializer: {(double)emitSerializerTimer.ElapsedMilliseconds / 1000}s");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
