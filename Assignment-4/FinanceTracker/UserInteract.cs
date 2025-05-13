

namespace FinanceTracker
{
    internal class UserInteract
    {
        /// <summary>
        /// Function to get required details from the user .
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceOrCategory"></param>
        /// <returns>A transaction object with user details</returns>
        public static Transaction GetUserInput(string name, string sourceOrCategory)
        {
            Console.WriteLine("Enter the date (dd-MM-yyyy):\n(press -1 to exit)");
            string userInput = Console.ReadLine();
            if (userInput.Equals("-1"))
                return null;
            DateTime date = Validation.GetValidDate(userInput);
            string category;
            if (sourceOrCategory.Equals("income source"))
                category = SelectIncomeSource();
            else
                category = SelectExpenseCategory();
            double amount = Validation.GetValidAmount();

            return new Transaction(date, name, category, amount);
        }
        public static string SelectIncomeSource()
        {
            Console.WriteLine("\nSelect your income source");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1.Salary\n2.Business Income\n3.Rental Income\n4.Investment returns\n5.Royalties\n6.Other sources");
            Console.ResetColor();
            int _choice = Validation.GetValidInteger("your choice");
            while(_choice<=0||_choice>6)
            {
                Console.WriteLine("Please choose from given choice");
                _choice = Validation.GetValidInteger("your choice");
            }
            return _choice switch
            {
                1=>"Salary",
                2=>"Business Income",
                3=>"Rental Income",
                4=>"Investment Returns",
                5=>"Royalties",
                _=>GetCustomIncome()
            };
        }
        public static string GetCustomIncome()
        {
            return Validation.GetValidString("income source");
        }
        public static string SelectExpenseCategory()
        {
            Console.WriteLine("\nSelect your expense category");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1.Housing\n2.Utilities\n3.Transportation\n4.Groceries\n5.Health-care\n6.Education\n7.Entertainment\n8.Savings & Investments\n9.Other expenses\n");
            Console.ResetColor();
            int _choice = Validation.GetValidInteger("your choice");
            while (_choice <= 0 || _choice > 9)
            {
                Console.WriteLine("Please choose from given choice");
                _choice = Validation.GetValidInteger("your choice");
            }
            return _choice switch
            {
                1 => "Housing",
                2 => "Utilities",
                3 => "Transportation",
                4 => "Groceries",
                5 => "Health-care",
                6 => "Education",
                7 => "Entertainment",
                8 => "Savings & Investments",
                _ => GetCustomExpense()
            };
        }
        public static string GetCustomExpense()
        {
            return Validation.GetValidString("expense category");
        }

    

}
}
