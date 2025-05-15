using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.Utilities;

namespace LINQ.Controller.QueryHandler
{
    internal class QueryTask3
    {
        /// <summary>
        /// Function to display second highest number and pairs that sum up to given target .
        /// </summary>
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
            if (arraySize < 2)
            {
                Console.WriteLine("Insufficient Elements to find second highest element");
                return;
            }
            try
            {
                int secondHighest = array.OrderByDescending(n => n).Distinct().Skip(1).First();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Second Highest Number : " + secondHighest);
                Console.ResetColor();
            }
            catch(Exception e)
            {
                Console.WriteLine("Insufficient Distinct Elements to find second highest element");
            }
            int target = Validator.GetValidNumber("Target sum:");
            var TargetPairs=array.SelectMany((value,index)=>array.Skip(index+1),
                                             (first,second)=>new { first, second }).Where(pair=>pair.first+pair.second==target).Distinct().ToList();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pairs summing up to target :");
            Console.ResetColor();
            foreach (var pair in TargetPairs)
            {
                Console.WriteLine($"({pair.first},{pair.second})");
            }

        }
    }
}
