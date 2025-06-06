using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using FinanceTracker.Controller;
using FinanceTracker.View;
namespace FinanceTracker.Utilities
{
    internal class UserService
    {
        string filepath = TransactionManager.filepath;
        XLWorkbook? workbook;
        IXLWorksheet? userSheet;
        /// <summary>
        /// Function to check if user already exits 
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <returns>Boolean value based on the presence or absence of userName</returns>
        public bool IsExisitingUser(string userName,string password)
        {
            workbook = new XLWorkbook(filepath);
            //expenseSheet = workbook.Worksheet("Expense");
            //incomeSheet = workbook.Worksheet("Income");
            userSheet = workbook.Worksheet("Users");
            //bool incomeAvailable = incomeSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
            //                                                              && row.Cell(5).GetString().Equals(password));
            //bool expenseAvailable = expenseSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
            //                                                                && row.Cell(5).GetString().Equals(password));
            bool isUserAvailable = userSheet.RowsUsed().Skip(1).Any(row=>row.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                       &&row.Cell(3).GetString().Equals(password));
            if (isUserAvailable)
            {
                return true;
            }
            return false;
        }
        public string CreateNewUserID(string userName,string password)
        {
            workbook = new XLWorkbook(filepath);
            userSheet = workbook.Worksheet("Users");
            int id=userSheet.LastRowUsed().RowNumber()+1;
            userSheet.Cell(id , 1).Value = id;
            userSheet.Cell(id , 2).Value = userName;
            userSheet.Cell(id , 3).Value = password;
            workbook.Save();
            return id.ToString();
        }

        public string FetchUserID(string userName,string password)
        {
            workbook = new XLWorkbook(filepath);
            userSheet = workbook.Worksheet("Users");
            IXLRow? matchingRow = userSheet.RowsUsed()
              .FirstOrDefault(r =>
                  r.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                  r.Cell(3).GetString().Equals(password, StringComparison.OrdinalIgnoreCase)
              );
            return matchingRow.Cell(1).Value.ToString();
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
                string userID=CreateNewUserID(userName,password);
                Thread.Sleep(1000);
                Console.Clear();
                UserMenu.DisplayUserMenu(userID);
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
                string userID=FetchUserID(userName,password);
                Thread.Sleep(1000);
                Console.Clear();
                UserMenu.DisplayUserMenu(userID);
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
