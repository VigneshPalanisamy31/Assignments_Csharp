﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Function to withdraw money from checking account
        /// </summary>
        /// <param name="amount"></param>
        public override void Withdraw(double amount)
        {

            if (Balance - amount >= 0)
            {
                Console.WriteLine("Withdrawal Successful....");
                Console.WriteLine($"Updated Balance : Rs. {Math.Round(Balance - amount, 2)}");
            }
            else
            {
                Console.WriteLine("Withdrawal denied due to insufficient funds....");
            }

        }
    }
}
