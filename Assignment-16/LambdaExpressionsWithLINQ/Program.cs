using SortWithAnonymousMethod;
namespace LambdaExpressionsWithLINQ
{
    internal class Program
    {
        static void Main(string[]args)
        {
            try
            {
                List<int> integerList = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                int arraySize = Helper.GetValidInteger("count of integers you wish to add to the existing list");
                for (int i = 0; i < arraySize; i++)
                {
                    integerList.Add(Helper.GetValidInteger($"number{i + 1}"));
                }
                //Using where to filter out even numbers and select to square the odd numbers
                List<int> squaredOddList = integerList.Where(i => i % 2 != 0).Select(i => i * i).ToList();
                foreach (int number in squaredOddList)
                    Console.WriteLine(number);
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
