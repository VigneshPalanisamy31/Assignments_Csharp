using ClosedXML.Excel;
using FinanceTracker.Controller;
using FinanceTracker.View;
namespace FinanceTracker.Utilities
{
    internal class UserService
    {
        string filepath = TransactionManager.filepath;
        XLWorkbook? workbook;
        IXLWorksheet? incomeSheet;
        IXLWorksheet? expenseSheet;
        /// <summary>
        /// Function to check if user already exits 
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <returns>Boolean value based on the presence or absence of userName</returns>
        public bool IsExisitingUser(string userName,string password)
        {
            workbook = new XLWorkbook(filepath);
            expenseSheet = workbook.Worksheet("Expense");
            incomeSheet = workbook.Worksheet("Income");
            bool incomeAvailable = incomeSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                          && row.Cell(5).GetString().Equals(password));
            bool expenseAvailable = expenseSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                            && row.Cell(5).GetString().Equals(password));
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
        public void RegisterNewUser(string userName,string password)
        {
            if (!IsExisitingUser(userName,password))
            {
                Helper.WriteInGreen($"Welcome {userName} !");
                Thread.Sleep(1000);
                Console.Clear();
                UserMenu.DisplayUserMenu(userName,password);
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
        public void LoginExistingUser(string userName,string password)
        {
            if (IsExisitingUser(userName,password))
            {
                Helper.WriteInGreen($"Welcome back {userName} !");
                Thread.Sleep(1000);
                Console.Clear();
                UserMenu.DisplayUserMenu(userName,password);
            }
            else
            {
                Helper.WriteInRed("\nIncorrect username or password...");
                Helper.WriteInYellow("\nTry Registering new user...");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
