using FinanceTracker.Controller;
using FinanceTracker.Model;
using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    internal class ExpenseMenu
    {
        public static void ExpenseTransactionManager(string userName)
        {
            bool isExit = false;
            while (!isExit)
            {
                Helper.WriteInYellow("\n1.Add Expense Transaction\n2.Edit Expense Transaction\n3.View Expense Summary\n4.Delete Expense Transaction\n5.Exit\n");
                int choice = Validator.GetValidInteger("your choice");

                switch (choice)
                {
                    case 1:
                        Transaction? transaction = Helper.FetchUserData(userName, "expense category");
                        if (transaction == null)
                            Console.WriteLine("Canceling...");
                        else
                        {
                            TransactionManager.AddTransaction(transaction,"Expense");
                            Helper.WriteInGreen("Expense Tracked Successfully....");
                        }
                        break;

                    case 2:
                        TransactionManager.EditTransaction(userName,"Expense");
                        break;

                    case 3:
                        TransactionManager.ViewTransaction(userName,"Expense");
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        break;

                    case 4:
                        TransactionManager.DeleteTransaction(userName,"Expense");
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
