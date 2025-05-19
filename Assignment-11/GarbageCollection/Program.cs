using System;
using System.Diagnostics;
using System.Threading;

namespace GarbageCollection
{
    class LargeObject
    {
        int []array=new int[10];
        String []stringarray=new String[10];
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting memory usage profiling...");

            PrintMemory("\nBefore object creation");

            CreateObjects();

            PrintMemory("\nAfter object creation");

            Console.WriteLine("\nTriggering GC.Collect...");
            GC.Collect();

            PrintMemory("\nAfter GC.Collect");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void CreateObjects()
        {
            const int objectCount = 10000;
            for (int i = 0; i < objectCount; i++)
            {
                LargeObject obj = new LargeObject();
            }
        }

        static void PrintMemory(string label)
        {
            long totalMemory = GC.GetTotalMemory(false);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{label}: {totalMemory/(1024*1024)}MB");
            Console.ResetColor();
        }
    }
}
