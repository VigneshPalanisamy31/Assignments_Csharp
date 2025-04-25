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
                bool isInteger = int.TryParse(Console.ReadLine(), out int _choice);
                if (isInteger)
                {

                    switch (_choice)
                    {
                        case 1:
                            return 1;

                        case 2:
                            return 2;

                        case 3: return 3;

                        default: Console.WriteLine("Please enter a valid choice"); return 0;
                    }

                }
                else
                    Console.WriteLine("Please enter a valid choice");
            }
            return 0;
        }
    }
}
