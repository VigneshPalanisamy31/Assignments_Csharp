using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mock = (ICalculator)MockBuilder.CreateMock(typeof(ICalculator));
            Console.WriteLine(mock.Calculate(2, 3));
            Console.ReadKey();
        }
    }
}
