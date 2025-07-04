﻿using FinanceTracker.Model;
namespace FinanceTracker.Utilities
{
    internal class Helper
    {
        /// <summary>
        /// Function to get required details from the user .
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceOrCategory"></param>
        /// <returns>A transaction object with user details</returns>
        public static Transaction? FetchUserData(string userID, string sourceOrCategory)
        {
            Console.WriteLine("Enter the date (yyyy-mm-dd):\n(press -1 to exit)");
            string? userInput = Console.ReadLine();
            if (userInput==null||userInput.Equals("-1"))
                return null;
            DateOnly date = Validator.GetValidDate(userInput);
            string category;
            if (sourceOrCategory.Equals("income source"))
                category = SelectIncomeSource();
            else
                category = SelectExpenseCategory();

            decimal amount = Validator.GetValidAmount();
            return new Transaction(date, userID, category, amount);
        }

        /// <summary>
        /// Function to allow user to view income sources and make selection
        /// </summary>
        /// <returns>income source (string)</returns>
        public static string SelectIncomeSource()
        {
            Console.WriteLine("\nSelect your income source");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1.Salary\n2.Business Income\n3.Rental Income\n4.Investment returns\n5.Royalties\n6.Other sources");
            Console.ResetColor();
            int choice = Validator.GetValidInteger("your choice");
            while(choice<=0||choice>6)
            {
                Console.WriteLine("Choose from given choice");
                choice = Validator.GetValidInteger("your choice");
            }
            return choice switch
            {
                1=>"Salary",
                2=>"Business Income",
                3=>"Rental Income",
                4=>"Investment Returns",
                5=>"Royalties",
                _=> Validator.GetValidString("income source")
            };
        }

        /// <summary>
        /// Function to allow user to view expense categories and make selection
        /// </summary>
        /// <returns>expense category (string)</returns>
        public static string SelectExpenseCategory()
        {
            Console.WriteLine("\nSelect your expense category");
            Helper.WriteInYellow("1.Housing\n2.Utilities\n3.Transportation\n4.Groceries\n5.Health-care\n6.Education\n7.Entertainment\n8.Savings & Investments\n9.Other expenses\n");
            int choice = Validator.GetValidInteger("your choice");
            while (choice <= 0 || choice > 9)
            {
                Console.WriteLine("Choose from given choice");
                choice = Validator.GetValidInteger("your choice");
            }
            return choice switch
            {
                1 => "Housing",
                2 => "Utilities",
                3 => "Transportation",
                4 => "Groceries",
                5 => "Health-care",
                6 => "Education",
                7 => "Entertainment",
                8 => "Savings & Investments",
                _ => Validator.GetValidString("expense category")
            };
        }

        /// <summary>
        /// Function to print the given statement in red color.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInRed(string displayMessage)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to print the given statement in green color.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInGreen(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Function to print the given statement in yellow color.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInYellow(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(displayMessage + "\n");
            Console.ResetColor();
        }
    }
}
