using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace WorkingWithMultipleThreads
{
    namespace ThreadPerformanceDemo
    {
        class Program
        {
            static long primeCount1 = 0;
            static long primeCount2 = 0;
            static void Main(string[] args)
            {
                try
                {
                    int halfLimit = 5000000;
                    Console.WriteLine("Finding Prime numbers parallely");
                    Stopwatch parallelTimer = new Stopwatch();
                    parallelTimer.Start();
                    Thread thread1 = new Thread(() => CountPrimes(halfLimit, out primeCount1));
                    Thread thread2 = new Thread(() => CountPrimes(halfLimit, out primeCount2));
                    thread1.Start();
                    thread2.Start();
                    thread1.Join();
                    thread2.Join();
                    parallelTimer.Stop();
                    Console.WriteLine($"[Parallel] Total primes found: {primeCount1 + primeCount2}");
                    Console.WriteLine($"[Parallel] Time taken: {parallelTimer.ElapsedMilliseconds} ms\n");
                    primeCount1 = 0;
                    primeCount2 = 0;
                    Console.WriteLine("Finding Prime numbers sequentially");
                    Stopwatch sequentialTimer = new Stopwatch();
                    sequentialTimer.Start();
                    CountPrimes(halfLimit, out primeCount1);
                    CountPrimes(halfLimit, out primeCount2);
                    sequentialTimer.Stop();
                    Console.WriteLine($"[Sequential] Total primes found: {primeCount1 + primeCount2}");
                    Console.WriteLine($"[Sequential] Time taken: {sequentialTimer.ElapsedMilliseconds} ms");
                    Console.ReadKey();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            static void CountPrimes(int limit, out long count)
            {
                count = 0;
                for (int num = 2; num <= limit; num++)
                {
                    if (IsPrime(num))
                        count++;
                }
            }
            static bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }
        }
    }

}
