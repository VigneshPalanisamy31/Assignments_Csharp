using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    internal class DivideByZero
    {
        //Task-1
        public static void Divide()
        {
            
            try
            {
                Console.WriteLine("Enter the dividend :");
                int dividend = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the divisor :");
                int divisor=int.Parse(Console.ReadLine());
                Console.WriteLine(dividend / divisor);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division by zero is not possible : {0}", e.Message);

            }
            finally
            {
                Console.WriteLine("Operation completed");
            }
        }
    }
}
