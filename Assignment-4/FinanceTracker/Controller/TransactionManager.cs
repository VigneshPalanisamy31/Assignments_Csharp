using ClosedXML.Excel;
using FinanceTracker.Model;
using FinanceTracker.Utilities;
namespace FinanceTracker.Controller
{
    internal class TransactionManager
    {
        public static string filepath = Path.Combine(Environment.CurrentDirectory, "FinanceTracker.xlsx");

        /// <summary>
        /// Function to create a transaction and write it to the file .
        /// </summary>
        /// <param name="transaction">object of type transaction</param>
        /// <param name="worksheetname">Name of the Worksheet to work with </param>
        public  void AddTransaction(Transaction transaction, string worksheetname,string password)
        {
            using (XLWorkbook workbook = new(filepath))
            {
                IXLWorksheet worksheet = workbook.Worksheet(worksheetname);
                //worksheet.LastRowUsed() could possibly be null if the worksheet is empty
                var lastRowUsed = worksheet.LastRowUsed();
                int lastRow = lastRowUsed==null?1: lastRowUsed.RowNumber() + 1;

                worksheet.Cell(lastRow, 1).Value = transaction.Date.ToString();
                worksheet.Cell(lastRow, 2).Value = transaction.Name;
                worksheet.Cell(lastRow, 3).Value = transaction.Category;
                worksheet.Cell(lastRow, 4).Value = transaction.Amount;
                worksheet.Cell(lastRow, 5).Value = password;

                //worksheet.LastColumnUsed() could possibly be null if the worksheet is empty
                var lastColumnUsed = worksheet.LastColumnUsed();
                int lastColumn = lastColumnUsed == null ? 1 : lastColumnUsed.ColumnNumber() + 1;
                var range = worksheet.Range(2, 1, lastRow, lastColumn);
                range.Sort("A", XLSortOrder.Ascending);
                workbook.Save();
            }
        }

        /// <summary>
        /// Function to view income/expense transactions of a user.
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="worksheetname">name of the worksheet</param>
        /// <param name="editIndex"></param>
        /// <returns>Boolean whether transactions are available are not. </returns>
        public  bool ViewTransaction(string userName, string worksheetname,string password,Transaction? editedTransaction = null)
        {
            int transactionCount = 0;
            using (XLWorkbook workbook = new(filepath))
            {
                IXLWorksheet? worksheet = workbook.Worksheet(worksheetname);
                IEnumerable<IXLRow> rows = worksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                && r.Cell(5).GetString().Equals(password));
                if (!rows.Any())
                { Helper.WriteInRed($"Sorry there are no {worksheetname} Transactions for {userName} ."); return false; }
                else
                {
                    Console.WriteLine($"{"ID",-10}{"Date",-30}{(worksheetname.Equals("Income") ? "income_source" : "expense_category"),5}{"Amount",15}");
                    foreach (var row in rows)
                    {
                        transactionCount++;
                        string date = row.Cell(1).GetString();
                        string sourceORcategory = row.Cell(3).GetString();
                        decimal amount = (decimal)row.Cell(4).GetDouble();

                        if (editedTransaction != null && editedTransaction.Date.ToString().ToString().Equals(date) && editedTransaction.Amount == amount && editedTransaction.Category.Equals(sourceORcategory))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{transactionCount,-10}{date,-30}{sourceORcategory,10}{amount,20}  (edited)");
                        }
                        else
                        {
                            Console.ForegroundColor = worksheetname.Equals("Income") ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.WriteLine($"{transactionCount,-10}{date,-30}{sourceORcategory,10}{amount,20}");
                        }
                        Console.ResetColor();
                    }
                    return true;
                }
            }
        }

        /// <summary>
        /// Function to edit income/expense transactions of a user.
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="worksheetname">Name of the worksheet to work with</param>
        public  void EditTransaction(string userName, string worksheetname,string password)
        {
            using (XLWorkbook workbook = new(filepath))
            {
                if (ViewTransaction(userName, worksheetname,password))
                {
                    int id = Validator.GetValidInteger("id of the transaction you wish to edit :\n(press -1 to exit)");
                    if (id == -1)
                    {
                        Console.WriteLine("Canceling...");
                        return;
                    }
                    Transaction? editedTransaction = null;
                    IXLWorksheet worksheet = workbook.Worksheet(worksheetname);
                    IEnumerable<IXLRow> rows = worksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                    && r.Cell(5).GetString().Equals(password));
                    int count = 0;
                    if (id > rows.Count() || id < 1)
                    {
                        Console.WriteLine("Sorry id not found....");
                    }
                    else
                    {
                        foreach (var row in rows)
                        {
                            count++;
                            if (count == id)
                            {
                                Console.WriteLine("Enter the revised date:(dd-MM-yyyy)");
                                row.Cell(1).Value = Validator.GetValidDate(Console.ReadLine()).ToString();
                                row.Cell(3).Value = worksheetname.Equals("Income") ? Helper.SelectIncomeSource() : Helper.SelectExpenseCategory();
                                row.Cell(4).Value = Validator.GetValidAmount();
                                editedTransaction = new Transaction(DateOnly.Parse(row.Cell(1).Value.ToString()), row.Cell(2).Value.ToString(), row.Cell(3).Value.ToString(),decimal.Parse(row.Cell(4).Value.ToString()));
                                break;
                            }
                        }
                        //worksheet.LastRowUsed() and worksheet.LastColumnUsed() could possibly be null if the worksheet is empty
                        IXLRow? lastRowUsed = worksheet.LastRowUsed();
                        int lastRow = lastRowUsed == null ? 1 : lastRowUsed.RowNumber();
                        //worksheet.LastColumnUsed() could possibly be null if the worksheet is empty
                        IXLColumn? lastColumnUsed = worksheet.LastColumnUsed();
                        int lastColumn = lastColumnUsed == null ? 1 : lastColumnUsed.ColumnNumber() + 1;
                        IXLRange? range = worksheet.Range(2, 1, lastRow, lastColumn);
                        range.Sort("A", XLSortOrder.Ascending);
                        workbook.Save();
                        ViewTransaction(userName, worksheetname,password,editedTransaction);
                        Helper.WriteInGreen("\nEdited Succesfully......!!!");
                    }
                }
            }
        }

        /// <summary>
        /// Function to delete a transaction from user history.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="filepath"></param>
        /// <param name="worksheetname"></param>
        public  void DeleteTransaction(string userName, string worksheetname,string password)
        {
            using (XLWorkbook workbook = new(filepath))
            {
                if (ViewTransaction(userName, worksheetname,password))
                {
                    int id = Validator.GetValidInteger("id of the transaction you wish to delete: \n(press -1 to exit)");
                    if (id == -1)
                    {
                        return;
                    }
                    IXLWorksheet worksheet = workbook.Worksheet(worksheetname);
                    IEnumerable<IXLRow> rows = worksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                    && r.Cell(5).GetString().Equals(password));
                    if (id > rows.Count() || id < 1)
                    {
                        Helper.WriteInRed("Sorry id not found....");
                    }
                    else
                    {
                        int count = 0;
                        foreach (var row in rows)
                        {
                            count++;
                            if (count == id)
                            {
                                Console.WriteLine($"{row.Cell(1).GetString(),-30}{row.Cell(3).GetString(),10}{row.Cell(4).GetString(),20}\n");
                                string ch = "a";
                                while (!ch.Equals("y") && !ch.Equals("Y") && !ch.Equals("n") && !ch.Equals("N"))
                                {
                                    Console.WriteLine($"Do you wish to delete this {worksheetname} transaction?[y/n]");
                                    ch = Validator.GetValidString("choice");
                                }
                                if (ch.Equals("y") || ch.Equals("Y"))
                                {
                                    row.Delete();
                                    Helper.WriteInGreen("Deletion Successful...");
                                }
                                else
                                    Helper.WriteInRed("Canceling Delete...");
                                break;
                            }
                        }
                        workbook.Save();
                        if(rows.Count()>0)
                          ViewTransaction(userName, worksheetname,password);
                    }
                }
            }
        }

        /// <summary>
        /// Function to view all financial transactions summary of user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="filepath"></param>
        public  void FinanceSummary(string userName, string filepath,string password)
        {
            List<(string date, string type, string source, double amount)> FinanceList = new();
            double netBalance = 0;
            using (XLWorkbook workbook = new(filepath))
            {
                IXLWorksheet incomeworksheet = workbook.Worksheet("Income");
                IEnumerable<IXLRow> incomerows = incomeworksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                            && r.Cell(5).GetString().Equals(password));
                IXLWorksheet expenseworksheet = workbook.Worksheet("Expense");
                IEnumerable<IXLRow> expenserows = expenseworksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                                              && r.Cell(5).GetString().Equals(password));
                foreach (var row in incomerows)
                {
                    FinanceList.Add(new(row.Cell(1).GetString(), "Income", row.Cell(3).GetString(), row.Cell(4).GetDouble()));
                    netBalance += row.Cell(4).GetDouble();
                }
                foreach (var row in expenserows)
                {
                    FinanceList.Add(new(row.Cell(1).GetString(), "Expense", row.Cell(3).GetString(), row.Cell(4).GetDouble()));
                    netBalance -= row.Cell(4).GetDouble();
                }
                IOrderedEnumerable<(string date, string type, string source, double amount)> sortedTransactions = FinanceList.OrderBy(t => t.date);
                Console.WriteLine($"{"Date",-30}{"Type",-10}{"Category",10}{"Amount",25}");
                foreach (var t in sortedTransactions)
                {
                    Console.ForegroundColor = t.type == "Income" ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine($"{t.date,-30}{t.type,-10}{t.source,10}{t.amount,25}");
                }
                Helper.WriteInYellow($"\nNET BALANCE  :  {netBalance}");
                Console.WriteLine("\nPress any key to go back to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
