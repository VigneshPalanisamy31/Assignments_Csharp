using FinanceTracker.Controller;
using FinanceTracker.Model;
using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    internal class IncomeMenu
    {    
        public static void IncomeTransactionManager(string userID,TransactionManager transactionManager)
        {
            bool isExit = false;
            while (!isExit)
            {
                Helper.WriteInYellow("1.Add Income Transaction\n2.Edit Income Transaction\n3.View Income Summary\n4.Delete Income Transaction\n5.Back To Menu\n");
                int choice = Validator.GetValidInteger("your choice");

                switch (choice)
                {
                    case 1:
                        Transaction? transaction = Helper.FetchUserData(userID, "income source");
                        if (transaction == null)
                            Console.WriteLine("Going Back to menu...");
                        else
                        {
                            transactionManager.AddTransaction(transaction, "Income", userID);
                            Helper.WriteInGreen("Income Tracked Successfully...");
                        }
                        break;

                    case 2:
                        transactionManager.EditTransaction(userID, "Income");  
                        break;

                    case 3:
                        transactionManager.ViewTransaction(userID, "Income");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 4:
                        transactionManager.DeleteTransaction(userID, "Income");
                        break;

                    case 5:
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
