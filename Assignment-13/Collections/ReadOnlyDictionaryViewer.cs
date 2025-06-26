namespace Collections
{
    public class ReadOnlyDictionaryViewer
    {
        /// <summary>
        /// Function that calculates the sum of elements in the given collection.
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <returns>sum of elements</returns>
        public static int SumOfElements(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        /// <summary>
        /// Function to test the SumOfElements() for various collection inputs.
        /// </summary>
       public static void TestSumOfElements()
        {
            List<int> integerList = new List<int> { 1, 2, 3, 4 };
            int[] array = { 5, 6, 7 };
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            Console.Write("List Elements :");
            foreach (var item in integerList)
                Console.Write(item + " ");
            Console.Write("\nArray Elements :");
            foreach (var item in array)
                Console.Write(item + " ");
            Console.Write("\nQueue Elements :");
            foreach (var item in queue)
                Console.Write(item + " ");
            Console.WriteLine($"\nList Sum: {SumOfElements(integerList)}");
            Console.WriteLine($"Array Sum: {SumOfElements(array)}");
            Console.WriteLine($"Queue Sum: {SumOfElements(queue)}");
        }
       
        /// <summary>
        /// Function to generate a read-only dictionary
        /// </summary>
        /// <returns>IReadOnlyDictionary object</returns>
        public static IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            var dict = new Dictionary<string, int>
        {
            { "Aston Martin", 100 },
            { "BMW", 200 },
            { "Chevrolet", 50 }
        };
            return new System.Collections.ObjectModel.ReadOnlyDictionary<string, int>(dict);
        }

        /// <summary>
        /// Function to print a read-only dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        public static void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine($"{keyValuePair.Key} = {keyValuePair.Value}");
            }
        }

        /// <summary>
        /// Function to display message that readonly dictionary cannot be modified
        /// </summary>
        /// <param name="dictionary">Read-only Dictionary</param>
        public static void AttemptToModifyDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            //try { dictionary["BMW"] = 10; }
            Console.WriteLine("Cannot modify IReadOnlyDictionary directly.");
        }
    }
}
