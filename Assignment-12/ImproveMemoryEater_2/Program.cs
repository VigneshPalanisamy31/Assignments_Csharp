using System;
using System.Collections.Generic;
using System.Threading;
namespace ImproveMemoryEater_2
{
    public class MemoryEater
    {
        List<int[]> memAlloc = new List<int[]>();

        public void Allocate()
        {
            while (memAlloc.Count<1000)
            {
                memAlloc.Add(new int[1000]);
                   
                

                Thread.Sleep(10);
            }
            memAlloc.Clear();
            Console.WriteLine("Improving memory by restricting loop to a finite limit...");
            Console.ReadKey();

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
