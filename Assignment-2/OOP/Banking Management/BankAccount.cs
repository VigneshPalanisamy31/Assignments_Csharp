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
        public virtual void Deposit(double amount)
        {

            Console.WriteLine("Deposit Successfull....");
            Console.WriteLine($"Updated Balance : Rs. {Math.Round(Balance + amount, 2)}");
        }
        public BankAccount()
        {
            Console.WriteLine("Enter the current balance");
            Balance = Validators.getValidAmount();

        }
        public abstract void Withdraw(double amount);
    }
}
