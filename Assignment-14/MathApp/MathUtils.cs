using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp
{
    public class MathUtils
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a > b ? a - b : b - a;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int Divide(int a, int b)
        {
            try
            {
                return a > b ? a / b : b / a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Execution interrupted due to an attempt to divide by 0 ");
                return 0;
            }
        }
    }
}
