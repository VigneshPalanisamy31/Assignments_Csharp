namespace FinanceTracker
{
    internal class Expense
    {
        public static void ExpenseFunctions(FinanceTransactions financer, string name, string filepath)
        {


            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1.Add Expense Transaction\n2.Edit Expense Transaction\n3.View Expense Stats\n4.Delete Expense Transaction\n5.Exit");
                int _choice = Validation.GetValidInteger("your choice");

                switch (_choice)
                {
                    case 1:
                        financer.AddTransaction(UserInteract.GetUserInput(name, "expense category"), filepath, "Expense");
                        Console.WriteLine("Expense Tracked Successfully....");
                        break;

                    case 2:
                        financer.EditTransaction(name, filepath, "Expense");
                        break;

                    case 3:
                        financer.ViewTransaction(name, filepath, "Expense");
                        break;

                    case 4:
                        financer.DeleteTransaction(name, filepath, "Expense");
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
