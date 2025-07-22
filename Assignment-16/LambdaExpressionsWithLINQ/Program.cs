using SortWithAnonymousMethod;
namespace LambdaExpressionsWithLINQ
{
    internal class Program
    {
        static void Main(string[]args)
        {
            try
            {
                List<int> integers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                int arraySize = Helper.GetValidInteger(" count of integers you wish to add to the existing list");
                for (int i = 0; i < arraySize; i++)
                {
                    integers.Add(Helper.GetValidInteger($"number{i + 1}"));
                }
                integers.Where(i => i % 2 != 0).Select(i => i * i).ToList().ForEach(i => Console.WriteLine(i));
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
