using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithTaskParallelLibrary
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Enumerable.Range(1, 10000).ToArray();
            int[] parallelSquaredResults = new int[numbers.Length];
            int[] squaredResults = new int[numbers.Length];
            Stopwatch parallelTimer = new Stopwatch();
            parallelTimer.Start();
            Parallel.ForEach(numbers, (number, state, index) =>
            {
                parallelSquaredResults[index] = number * number;
            });
            parallelTimer.Stop();
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            for (int index = 0; index < numbers.Length; index++)
            {
                squaredResults[index] = numbers[index] * numbers[index];
            }
            Timer.Stop();
            Console.WriteLine($"Time taken by Parallel foreach loop : {(double)parallelTimer.ElapsedMilliseconds}ms");
            Console.WriteLine($"Time taken by simple for loop : {(double)Timer.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }
    }

}
