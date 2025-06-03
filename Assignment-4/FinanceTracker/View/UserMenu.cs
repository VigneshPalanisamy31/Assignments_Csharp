using ClosedXML.Excel;
using FinanceTracker.Controller;
using FinanceTracker.Utilities;

namespace FinanceTracker.View
{
     class UserMenu
    {
        string filepath=TransactionManager.filepath;
         XLWorkbook? workbook;
         IXLWorksheet? incomeSheet;
         IXLWorksheet? expenseSheet;

        /// <summary>
        /// Function to check if user already exits 
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <returns>Boolean value based on the presence or absence of userName</returns>
        public bool IsExisitingUser(string userName)
        {
            workbook = new XLWorkbook(filepath);
            expenseSheet = workbook.Worksheet("Expense");
            incomeSheet = workbook.Worksheet("Income");
            bool incomeAvailable = incomeSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase));
            bool expenseAvailable = expenseSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (!incomeAvailable && !expenseAvailable)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Function to check if user is new, prompt with suitable message and enable functionalities
        /// </summary>
        /// <param name="userName"></param>
        public void RegisterNewUser(string userName)
        {
            if (!IsExisitingUser(userName))
            {
                Helper.WriteInGreen($"Welcome {userName} !");
                Thread.Sleep(1000);
                Console.Clear();
                DisplayUserMenu(userName);
            }
            else
            {
                Helper.WriteInRed("User Already Exists");
                Helper.WriteInYellow("Try Loging in...");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        /// <summary>
        /// Function to check if user exists , prompt with suitable message and enable functionalities
        /// </summary>
        /// <param name="userName"></param>
        public void LoginExistingUser(string userName)
        {
            if (IsExisitingUser(userName))
            {
                Helper.WriteInGreen($"Welcome back {userName} !");
                Thread.Sleep(1000);
                Console.Clear();
                DisplayUserMenu(userName);
            }
            else
            {
                Helper.WriteInRed("User Name Not Found");
                Helper.WriteInYellow("Try Registering in...");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        /// <summary>
        /// Function to display user menu and call the required functionalities
        /// </summary>
        /// <param name="name"></param>
        public  void DisplayUserMenu(string name)
        {
                bool exit = false;
                while (!exit)
                {
                    Helper.WriteInYellow("\n1.Income Manager\n2.Expense Manager\n3.Finance Summary\n4.Log Out");
                    int choice = Validator.GetValidInteger("your choice");

                    switch (choice)
                    {
                        case 1:
                            IncomeMenu.IncomeTransactionManager(name);
                            break;

                        case 2:
                            ExpenseMenu.ExpenseTransactionManager(name);
                            break;

                        case 3:
                            TransactionManager.FinanceSummary(name, filepath);
                            break;

                        case 4:
                            Helper.WriteInRed("Logging Out...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            exit = true;
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
