using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class Validators
    {
        public static double getValidAmount()
        {
            while (true)
            {
                bool isValid = double.TryParse(Console.ReadLine(), out double value);
                if (isValid)
                    return value;
                else
                    Console.WriteLine("Please enter a valid amount:");

            }
        }
    }
}
