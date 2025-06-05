using ClosedXML.Excel;
using FinanceTracker.Controller;
using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
   class UserMenu
    {
        /// <summary>
        /// Function to display user menu and call the required functionalities
        /// </summary>
        /// <param name="name"></param>
        public static void DisplayUserMenu(string name,string password)
        {
                bool isExit = false;
                TransactionManager transactionManager = new TransactionManager();
                while (!isExit)
                {
                    Helper.WriteInYellow("\n1.Income Manager\n2.Expense Manager\n3.Finance Summary\n4.Log Out");
                    int choice = Validator.GetValidInteger("your choice");

                    switch (choice)
                    {
                        case 1:
                            IncomeMenu.IncomeTransactionManager(name,password, transactionManager);
                            break;

                        case 2:
                            ExpenseMenu.ExpenseTransactionManager(name,password, transactionManager);
                            break;

                        case 3:
                            transactionManager.FinanceSummary(name, TransactionManager.filepath, password);
                            break;

                        case 4:
                            Helper.WriteInRed("Logging Out...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            isExit = true;
                            break;

                        default:
                             Helper.WriteInRed("Invalid Choice");
                             Helper.WriteInYellow("Please enter a valid choice");
                             Thread.Sleep(1000);
                             Console.Clear();
                        break;
                    }
                }
        }
    }
}
