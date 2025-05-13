using ClosedXML.Excel;
namespace FinanceTracker
{
    internal class NewUser
    {

        static XLWorkbook workbook;
        static IXLWorksheet incomeSheet;
        static IXLWorksheet expenseSheet;
        static string filepath;
        public NewUser(string filePath)
        {
            filepath = filePath;
            workbook = new XLWorkbook(filepath);
            expenseSheet = workbook.Worksheet("Expense");
            incomeSheet = workbook.Worksheet("Income");
        }

        /// <summary>
        /// Function to ensure user is not available already .
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Bool value whether the user is new or not .</returns>
        public bool IsNewUser(string name)
        {
            int count = 0;
            bool incomeAvailable = incomeSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
            bool expenseAvailable = expenseSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
            if (incomeAvailable || expenseAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User Already Exists");
                Console.ResetColor();
                return false;
            }
            return true;

        }


        public void NewUserFunctions(string name, FinanceTransactions financer)
        {
            if (IsNewUser(name))
            {

                bool exit = false;
                while (!exit)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n1.Add Income Transaction\n2.Add Expense Transaction\n3.Exit\n");
                    Console.ResetColor();
                    int _choice = Validation.GetValidInteger("your choice");
                    Transaction transaction = null;
                    if (_choice > 0 && _choice < 3)
                    {
                        transaction = UserInteract.GetUserInput(name, _choice == 1 ? "income source" : "expense category");
                        if (transaction == null)
                        {
                            Console.WriteLine("Exiting....\nPress any key to continue...");
                            Console.ReadKey(); Console.Clear();
                            continue;
                        }
                    }

                    switch (_choice)
                    {
                        case 1:
                            financer.AddTransaction(transaction, filepath, "Income");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Income Tracked Successfully....");
                            Console.ResetColor();
                            break;
                        case 2:
                            financer.AddTransaction(transaction, filepath, "Expense");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Expense Tracked Successfully....");
                            Console.ResetColor();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Exiting....");
                            Console.ResetColor();
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
}
