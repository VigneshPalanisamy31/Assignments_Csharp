using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    internal class QueryTask3
    {
        public static void Execute()
        {
            int arraySize = Validator.GetValidNumber("array size ");
            int[] array = new int[arraySize];
            Console.WriteLine("Enter the array elements");
            for (int i = 0; i < arraySize; i++)
            {
                if(!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Operation terminated due to invalid input\nExpected input:Valid Integers...");
                    return;
                }
            }
            int secondHighest = array.OrderByDescending(n => n).Distinct().Skip(1).First();
            int target = Validator.GetValidNumber("Target sum:");
            var TargetPairs=array.SelectMany((value,index)=>array.Skip(index+1),
                                             (first,second)=>new { first, second }).Where(pair=>pair.first+pair.second==target).Distinct().ToList();
            Console.WriteLine("Second Highest Number" + secondHighest);
            Console.WriteLine("Pairs summing up to target :");
            foreach (var pair in TargetPairs)
            {
                Console.WriteLine($"({pair.first},{pair.second})");
            }

        }
    }
}
