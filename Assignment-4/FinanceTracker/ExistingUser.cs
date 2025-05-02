<<<<<<< HEAD

﻿using ClosedXML.Excel;

=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
>>>>>>> f1ac8c4 (feat: develop finance tracker functionalities for existing user)

namespace FinanceTracker
{
    internal class ExistingUser
    {
        string filepath;
        static XLWorkbook workbook;
        static IXLWorksheet incomeSheet;
        static IXLWorksheet expenseSheet;
        public ExistingUser(string filePath)
        {
            filepath = filePath;
            workbook = new XLWorkbook(filepath);
            expenseSheet = workbook.Worksheet("Expense");
            incomeSheet = workbook.Worksheet("Income");
        }

        public bool IsUser(string name)
        {
            bool incomeAvailable = incomeSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
            bool expenseAvailable = expenseSheet.RowsUsed().Skip(1).Any(row => row.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
            if (!incomeAvailable && !expenseAvailable)
            {
                Console.WriteLine("User Not Found");
                return false;
            }
            return true;

        }


        public void UserFunctions(string name, FinanceTransactions financer)
        {
            if (IsUser(name))
            {

                bool exit = false;
                while (!exit)
                {
<<<<<<< HEAD

                    Console.WriteLine("1.Income Tracker\n2.Expense Tracker\n3.Finance Summary\n4.Exit");

=======
                    Console.WriteLine("1.Income Tracker\n2.Expense Tracker\n3.Finance Summarry\n4.Exit");
>>>>>>> f1ac8c4 (feat: develop finance tracker functionalities for existing user)

                    int _choice = Validation.GetValidInteger("your choice");

                    switch (_choice)
                    {
                        case 1:
                            Income.IncomeFunctions(financer, name, filepath);
                            break;
                        case 2:
                            Expense.ExpenseFunctions(financer, name, filepath);
                            break;
                        case 3:
                            financer.FinanceSummary(name, filepath);
                            break;
                        case 4:
                            Console.WriteLine("Exiting....");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Please choose from given options");
                            break;


                    }
                    if (_choice > 2)
                    {
                        Console.WriteLine("Press any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

            }


        }
    }
}
