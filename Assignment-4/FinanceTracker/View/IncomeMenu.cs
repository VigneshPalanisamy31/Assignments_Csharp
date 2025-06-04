using FinanceTracker.Controller;
using FinanceTracker.Model;
using FinanceTracker.Utilities;
namespace FinanceTracker.View
{
    internal class IncomeMenu
    {    
        public static void IncomeTransactionManager(string userName)
        {
            bool isExit = false;
            while (!isExit)
            {
                Helper.WriteInYellow("1.Add Income Transaction\n2.Edit Income Transaction\n3.View Income Summary\n4.Delete Income Transaction\n5.Back To Menu\n");
                int choice = Validator.GetValidInteger("your choice");

                switch (choice)
                {
                    case 1:
                        Transaction? transaction = Helper.FetchUserData(userName, "income source");
                        if (transaction == null)
                            Console.WriteLine("Going Back to menu...");
                        else
                        {
                            TransactionManager.AddTransaction(transaction, "Income");
                            Helper.WriteInGreen("Income Tracked Successfully...");
                        }
                        break;

                    case 2:
                        TransactionManager.EditTransaction(userName, "Income");
                        break;

                    case 3:
                        TransactionManager.ViewTransaction(userName, "Income");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 4:
                        TransactionManager.DeleteTransaction(userName, "Income");
                        break;

                    case 5:
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
