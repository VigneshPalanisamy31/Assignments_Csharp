using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class BankingUI
    {
        public static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("\nWelcome to bank hierarchy....");
                Console.WriteLine("1.Savings Account");
                Console.WriteLine("2.Checking Account");
                Console.WriteLine("3.Exit");
                bool isInteger = int.TryParse(Console.ReadLine(), out int _choice);
                if (isInteger)
                {

                    switch (_choice)
                    {
                        case 1:
                            SavingsAccount savingsaccount = new SavingsAccount();
                            switch (MoneyOperations.MoneyHandling())
                            {
                                case 1:
                                    Console.WriteLine("Enter the amount");
                                    savingsaccount.Deposit(Validator.GetValidAmount());
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the amount");
                                    savingsaccount.Withdraw(Validator.GetValidAmount());
                                    break;
                                default: Console.WriteLine("Exiting..."); break;
                            }
                            break;

                        case 2:
                            CheckingAccount checkingaccount = new CheckingAccount();
                            switch (MoneyOperations.MoneyHandling())
                            {
                                case 1:
                                    Console.WriteLine("Enter the amount");
                                    checkingaccount.Deposit(Validator.GetValidAmount());
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the amount");
                                    checkingaccount.Withdraw(Validator.GetValidAmount());
                                    break;
                                default: Console.WriteLine("Exiting..."); break;
                            }
                            break;

                        case 3: stop = true; break;

                        default: Console.WriteLine("Invalid choice"); break;


                    }

                }
                else
                    Console.WriteLine("Please enter a valid choice");
            }
            Console.ReadKey();
        }
    }
}
