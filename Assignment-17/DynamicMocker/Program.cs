namespace DynamicMocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var mock = (ICalculator)MockBuilder.CreateMock(typeof(ICalculator));
                Console.WriteLine(mock.Calculate(2, 3));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
