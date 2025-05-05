using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class SavingsAccount : BankAccount
    {
      
        public override void Withdraw(double amount)
        {

            if (Balance - amount > 500)
            {
                Console.WriteLine("Withdrawal Successfull....");
                Console.WriteLine($"Updated Balance : Rs.  {Math.Round(Balance - amount, 2)}");
            }
            else
            {
                Console.WriteLine("Withdrawal denied due to insufficient funds....");
            }
        }
    }
}
