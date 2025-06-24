namespace DynamicAndVar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Using var ===");
                var number = 10;
                Console.WriteLine($"Value: {number}, Type: {number.GetType()}");
                // number = "Hello"; 
                //  Cannot implicitly convert type 'string' to 'int'
                Console.WriteLine("\n=== Using dynamic ===");
                dynamic value = 10;
                Console.WriteLine($"Value: {value}, Type: {value.GetType()}");
                value = "Hello";
                Console.WriteLine($"Value: {value}, Type: {value.GetType()}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
