using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool IsNewUser(string name)
        {
            int count = 0;
            bool incomeAvailable = incomeSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
            bool expenseAvailable = expenseSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
            if (incomeAvailable || expenseAvailable)
            {
                Console.WriteLine("User Already Exists");
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
                    Console.WriteLine("1.Add Income Transaction\n2.Add Expense Tansaction\n3.Exit");
                    int _choice = Validation.GetValidInteger("your choice");

                    switch (_choice)
                    {
                        case 1:
                            financer.AddTransaction(UserInteract.GetUserInput(name, "income source"), filepath, "Income");
                            Console.WriteLine("Income Tracked Successfully....");
                            break;
                        case 2:
                            financer.AddTransaction(UserInteract.GetUserInput(name, "expense category"), filepath, "Expense");
                            Console.WriteLine("Expense Tracked Successfully....");
                            break;
                        case 3:
                            Console.WriteLine("Exiting....");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Please choose from given options");
                            break;


                    }
                }
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
            }


        }
    }
}
