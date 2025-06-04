using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagementProfiling
{

    public class MemoryEater
    {
        List<int[]> memAlloc = new List<int[]>();

        public void Allocate()
        {
            while (true)
            {
                memAlloc.Add(new int[1000]);

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
