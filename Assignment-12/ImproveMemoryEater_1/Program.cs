 using System;
 using System.Collections.Generic;
 using System.Threading;
namespace ImproveMemoryEater_1
{
    public class MemoryEater
    {
        List<int[]> memAlloc = new List<int[]>();

        public void Allocate()
        {
            while (true)
            {
                memAlloc.Add(new int[1000]);

                if (memAlloc.Count > 1000)
                {
                    Console.WriteLine("Clearing memory list to prevent overflow...");
                    memAlloc.Clear();
                }

                Thread.Sleep(10);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
        }
    }
}
