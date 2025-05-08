using ClosedXML.Excel;

namespace FinanceTracker
{
    internal class FinanceTransactions
    {

        /// <summary>
        /// Function to create a transaction and write it to the file .
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="filepath"></param>
        /// <param name="worksheetname"></param>
        public void AddTransaction(Transaction transaction, string filepath, string worksheetname)
        {

            using (var workbook = new XLWorkbook(filepath))
            {
                var worksheet = workbook.Worksheet(worksheetname);
                var lastrow = worksheet.LastRowUsed().RowNumber() + 1;
                worksheet.Cell(lastrow, 1).Value = transaction.date;
                worksheet.Cell(lastrow, 2).Value = transaction.name;
                worksheet.Cell(lastrow, 3).Value = transaction.category;
                worksheet.Cell(lastrow, 4).Value = transaction.amount;
                var range = worksheet.Range(2, 1, lastrow, worksheet.LastColumnUsed().ColumnNumber());
                range.Sort("A", XLSortOrder.Ascending);

                workbook.Save();

            }
        }


        /// <summary>
        /// Function to view income/expense transactions of a user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filepath"></param>
        /// <param name="worksheetname"></param>
        /// <param name="editIndex"></param>
        /// <returns>Boolean whether transactions are available are not. </returns>

        public bool ViewTransaction(string name, string filepath, string worksheetname, int editIndex = -1)
        {
            int c = 0;
            using (var workbook = new XLWorkbook(filepath))
            {
                var worksheet = workbook.Worksheet(worksheetname);
                var rows = worksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
                if (!rows.Any())
                { Console.WriteLine($"Sorry there are no {worksheetname} Transactions for {name} ."); return false; }
                else
                {
                    Console.WriteLine($"{"ID",-10}{"Date",-30}{(worksheetname.Equals("Income") ? "income_source" : "expense_category"),5}{"Amount",15}");
                    foreach (var row in rows)
                    {
                        c++;
                        string date = row.Cell(1).GetDateTime().ToString();
                        string sourceORcategory = row.Cell(3).GetString();
                        double amount = row.Cell(4).GetDouble();
                        if (c == editIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{c,-10}{date,-30}{sourceORcategory,10}{amount,20}  (edited)");
                        }
                        else
                        {

                            Console.ForegroundColor = worksheetname.Equals("Income") ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.WriteLine($"{c,-10}{date,-30}{sourceORcategory,10}{amount,20}");
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
        /// <param name="name"></param>
        /// <param name="filepath"></param>
        /// <param name="worksheetname"></param>


        public void EditTransaction(string name, string filepath, string worksheetname)
        {
            using (var workbook = new XLWorkbook(filepath))
            {
                if (ViewTransaction(name, filepath, worksheetname))
                {

                    int id = Validation.GetValidInteger("id of the transaction you wish to edit :");
                    var worksheet = workbook.Worksheet(worksheetname);
                    var rows = worksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
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

                                row.Cell(3).Value = Validation.GetValidString($"{(worksheetname.Equals("Income") ? "revised income source" : "revised expense category")}");
                                row.Cell(4).Value = Validation.GetValidAmount();
                                break;
                            }
                        }
                        var range = worksheet.Range(2, 1, worksheet.LastRowUsed().RowNumber(), worksheet.LastColumnUsed().ColumnNumber());
                        range.Sort("A", XLSortOrder.Ascending);
                        workbook.Save();
                        ViewTransaction(name, filepath, worksheetname, id);

                        Console.WriteLine("\nEdited Succesfully......!!!");
                    }
                }
            }

        }


        /// <summary>
        /// Function to delete a transaction from user history.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filepath"></param>
        /// <param name="worksheetname"></param>

        public void DeleteTransaction(string name, string filepath, string worksheetname)
        {
            using (var workbook = new XLWorkbook(filepath))
            {
                if (ViewTransaction(name, filepath, worksheetname))
                {
                    int id = Validation.GetValidInteger("id of the transaction you wish to delete :");
                    var worksheet = workbook.Worksheet(worksheetname);
                    var rows = worksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
                    if (id > rows.Count() || id < 1)
                    {
                        Console.WriteLine("Sorry id not found....");
                    }
                    else
                    {
                        int count = 0;
                        foreach (var row in rows)
                        {
                            count++;
                            if (count == id)
                            {
                                Console.WriteLine($"{row.Cell(1).GetDateTime(),-30}{row.Cell(3).GetString(),10}{row.Cell(4).GetDouble(),20}\n");
                                string ch = "a";
                                while (!ch.Equals("y") && !ch.Equals("Y") && !ch.Equals("n") && !ch.Equals("N"))
                                {
                                    Console.WriteLine($"Do you wish to delete this {worksheetname} transaction?[y/n]");
                                    ch = Validation.GetValidString("choice");
                                }
                                if (ch.Equals("y") || ch.Equals("Y"))
                                {
                                    row.Delete();
                                    Console.WriteLine("Deletion Successful...");
                                }
                                else
                                    Console.WriteLine("Cancelling Delete...");
                                break;
                            }
                        }
                        workbook.Save();
                        ViewTransaction(name, filepath, worksheetname);
                    }
                }

            }

        }


        /// <summary>
        /// Function to view all financial transactions summary of user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filepath"></param>


        public void FinanceSummary(string name, string filepath)
        {
            var FinanceList = new List<(DateTime date, string type, string source, double amount)>();
            double netBalance = 0;
            using (var workbook = new XLWorkbook(filepath))
            {
                var incomeworksheet = workbook.Worksheet("Income");
                var incomerows = incomeworksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
                var expenseworksheet = workbook.Worksheet("Expense");
                var expenserows = expenseworksheet.RowsUsed().Skip(1).Where(r => r.Cell(2).GetString().Equals(name, StringComparison.OrdinalIgnoreCase));
                foreach (var row in incomerows)
                {
                    FinanceList.Add(new(row.Cell(1).GetDateTime(), "Income", row.Cell(3).GetString(), row.Cell(4).GetDouble()));
                    netBalance += row.Cell(4).GetDouble();
                }
                foreach (var row in expenserows)
                {
                    FinanceList.Add(new(row.Cell(1).GetDateTime(), "Expense", row.Cell(3).GetString(), row.Cell(4).GetDouble()));
                    netBalance -= row.Cell(4).GetDouble();
                }
                var sortedTransactions = FinanceList.OrderBy(t => t.date);
                Console.WriteLine($"{"Date",-30}{"Type",-10}{"Category",10}{"Amount",25}");
                foreach (var t in sortedTransactions)
                {
                    Console.ForegroundColor = t.type == "Income" ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine($"{t.date,-30}{t.type,-10}{t.source,10}{t.amount,25}");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nNET BALANCE  :  {netBalance}");
                Console.ResetColor();
            }
        }
    }
}
