using FinanceTracker.Controller;
using FinanceTracker.Model;
using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    internal class ExpenseMenu
    {
        public static void ExpenseTransactionManager(string userName,string password,TransactionManager transactionManager)
        {
            bool isExit = false;
            while (!isExit)
            {
                Helper.WriteInYellow("\n1.Add Expense Transaction\n2.Edit Expense Transaction\n3.View Expense Summary\n4.Delete Expense Transaction\n5.Back to Menu\n");
                int choice = Validator.GetValidInteger("your choice");

                switch (choice)
                {
                    case 1:
                        Transaction? transaction = Helper.FetchUserData(userName, "expense category");
                        if (transaction == null)
                            Console.WriteLine("Canceling...");
                        else
                        {
                            transactionManager.AddTransaction(transaction,"Expense",password);
                            Helper.WriteInGreen("Expense Tracked Successfully....");
                        }
                        break;

                    case 2:
                        transactionManager.EditTransaction(userName,"Expense",password);
                        break;

                    case 3:
                        transactionManager.ViewTransaction(userName,"Expense",password);
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        break;

                    case 4:
                        transactionManager.DeleteTransaction(userName,"Expense",password);
                        break;

                    case 5:
                        Helper.WriteInRed("");
                        isExit = true;
                        break;

                    default:
                        Helper.WriteInRed("Please choose from given options");
                        break;
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
