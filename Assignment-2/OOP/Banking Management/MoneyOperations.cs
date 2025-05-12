using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class MoneyOperations
    {
        public static int MoneyHandling()
        {

            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.Exit");
                if (int.TryParse(Console.ReadLine(), out int _choice) && _choice >= 1 && _choice <= 3)
                    return _choice;
                else
                    Console.WriteLine("Please enter a valid choice");
            }
            return 0;
        }
    }
}
