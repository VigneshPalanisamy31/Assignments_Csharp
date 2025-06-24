using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal abstract class BankAccount
    {
        string _accountnumber;
        public string AccountNumber { get; set; }
        double _balance;
        public double Balance { get; set; }

        /// <summary>
        /// Function to deposit into user account
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Deposit(double amount)
        {

            Console.WriteLine("Deposit Successful....");
            Console.WriteLine($"Updated Balance : Rs. {Math.Round(Balance + amount, 2)}");
        }

        /// <summary>
        /// Constructor to get current balance
        /// </summary>
        public BankAccount()
        {
            Console.WriteLine("Enter the current balance");
            Balance = Validator.GetValidAmount();

        }
        public abstract void Withdraw(double amount);
    }
}
