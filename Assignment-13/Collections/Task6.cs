using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Task6
    {
        public static int SumOfElements(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }
       public static void TestSumOfElements()
        {
            List<int> list = new List<int> { 1, 2, 3, 4 };
            int[] array = { 5, 6, 7 };
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            Console.WriteLine("List Elements :");
            foreach (var item in list)
                Console.Write(item + " ");
            Console.WriteLine("Array Elements :");
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine("Queue Elements :");
            foreach (var item in queue)
                Console.Write(item + " ");

            Console.WriteLine("List Sum: " + SumOfElements(list));
            Console.WriteLine("Array Sum: " + SumOfElements(array));
            Console.WriteLine("Queue Sum: " + SumOfElements(queue));
        }
       

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

        public static void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} = {kvp.Value}");
            }
        }

        public static void AttemptToModifyDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            
              //  dictionary["BMW"] = 10;
            

           
            Console.WriteLine("Cannot modify IReadOnlyDictionary directly.");
        }
    }
}
