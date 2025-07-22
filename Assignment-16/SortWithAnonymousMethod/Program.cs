namespace SortWithAnonymousMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int arraySize = Helper.GetValidInteger("array size");
                int[] numbers = new int[arraySize];
                for (int i = 0; i < arraySize; i++)
                {
                    numbers[i] = Helper.GetValidInteger($"number{i + 1}");
                }
                Console.WriteLine("Original Array:");
                PrintArray(numbers);
                Array.Sort(numbers, delegate (int a, int b)
                {
                    return a.CompareTo(b);
                });
                Console.WriteLine("\nSorted Array (Ascending):");
                PrintArray(numbers);
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        } 
        /// <summary>
        /// Prints the array elements
        /// </summary>
        /// <param name="array">an integer aarray</param>
        static void PrintArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
