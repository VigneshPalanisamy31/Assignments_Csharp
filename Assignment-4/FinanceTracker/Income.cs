namespace FinanceTracker
{
    internal class Income
    {

        public static void IncomeFunctions(FinanceTransactions financer, string name, string filepath)
        {


            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1.Add Income Transaction\n2.Edit Income Tansaction\n3.View Income Stats\n4.Delete Income Transaction\n5.Exit");
                int _choice = Validation.GetValidInteger("your choice");

                switch (_choice)
                {
                    case 1:
                        Transaction transaction = UserInteract.GetUserInput(name, "income source");
                        if (transaction == null)
                            Console.WriteLine("Exiting...");
                        else
                        {
                            financer.AddTransaction(transaction, filepath, "Income");
                            Console.WriteLine("Income Tracked Successfully....");
                        }

                        break;
                    case 2:
                        financer.EditTransaction(name, filepath, "Income");
                        break;

                    case 3:
                        financer.ViewTransaction(name, filepath, "Income");
                        break;
                    case 4:
                        financer.DeleteTransaction(name, filepath, "Income");
                        break;

                    case 5:
                        Console.WriteLine("Exiting....");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please choose from given options");
                        break;


                }
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
