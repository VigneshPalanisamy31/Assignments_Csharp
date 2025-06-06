using FinanceTracker.Controller;
using FinanceTracker.Model;
using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    internal class ExpenseMenu
    {
        public static void ExpenseTransactionManager(string userID,TransactionManager transactionManager)
        {
            bool isExit = false;
            while (!isExit)
            {
                Helper.WriteInYellow("\n1.Add Expense Transaction\n2.Edit Expense Transaction\n3.View Expense Summary\n4.Delete Expense Transaction\n5.Back to Menu\n");
                int choice = Validator.GetValidInteger("your choice");

                switch (choice)
                {
                    case 1:
                        Transaction? transaction = Helper.FetchUserData(userID, "expense category");
                        if (transaction == null)
                            Console.WriteLine("Canceling...");
                        else
                        {
                            transactionManager.AddTransaction(transaction,"Expense",userID);
                            Helper.WriteInGreen("Expense Tracked Successfully....");
                        }
                        break;

                    case 2:
                        transactionManager.EditTransaction(userID,"Expense");
                        break;

                    case 3:
                        transactionManager.ViewTransaction(userID,"Expense");
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        break;

                    case 4:
                        transactionManager.DeleteTransaction(userID, "Expense");
                        break;

                    case 5:
                        Helper.WriteInRed("");
                        isExit = true;
                        break;

                    default:
                        Helper.WriteInRed("Choose from given options");
                        break;
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
