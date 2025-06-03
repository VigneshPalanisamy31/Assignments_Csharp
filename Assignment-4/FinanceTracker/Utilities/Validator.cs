using System.Globalization;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using FinanceTracker.Controller;

namespace FinanceTracker.Utilities
{
    internal class Validator
    {

        /// <summary>
        /// Function to get an integer from user .
        /// </summary>
        /// <returns>Validated integer</returns>
        public static int GetValidInteger(string prompt)
        {
            Console.WriteLine($"Please enter {prompt} :");
            bool valid = int.TryParse(Console.ReadLine(), out int choice);
            while (!valid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Please enter a valid input :");
                Console.ResetColor();
                valid = int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }


        /// <summary>
        /// Function to get a amount from user .
        /// </summary>
        /// <returns>Validated Amount</returns>

        public static decimal GetValidAmount()
        {
            Console.WriteLine("Please enter the amount :");
            bool isValid = decimal.TryParse(Console.ReadLine(), out decimal amount);
            while (!isValid || amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid amount :");
                Console.ResetColor();
                isValid = decimal.TryParse(Console.ReadLine(), out amount);
            }
            return amount;
        }

        /// <summary>
        /// Function to get a string from user .
        /// </summary>
        /// <returns>Validated string</returns>
        public static string GetValidString(string input)
        {
            int wrongAttemptCount = 0;
            Console.WriteLine($"Please enter  {input} :");
            string? userInput = Console.ReadLine();
            //Regex pattern to ensure the string starts with an alphabet ends with an alphabet and may contain specified special characters ( '-.)
            string? pattern = @"^[A-Za-z]+([ '-.][A-Za-z]+)*$";
            while (string.IsNullOrWhiteSpace(userInput) || !Regex.IsMatch(userInput, pattern))
            { wrongAttemptCount++;
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"Please enter a valid {input}:");
                Console.ResetColor();
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        /// <summary>
        /// Function to get date from user .
        /// </summary>
        /// <returns>Validated date</returns>
        public static DateOnly GetValidDate(string? userInput)
        {
            
            DateOnly date;
            while (true)
            {
                if (DateOnly.TryParseExact(userInput, "dd-MM-yyyy", null, DateTimeStyles.None, out date))
                    return date;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please follow the format (dd-MM-yyyy)");
                    Console.ResetColor();
                    userInput = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Function to create a file if it doesn't exist .
        /// </summary>
        /// <param name="filepath"></param>
        public static void CreateFileIfMissing()
        {
            if (!File.Exists(TransactionManager.filepath))
            {
                var workbook = new XLWorkbook();
                var incomeWorksheet = workbook.Worksheets.Add("Income");
                incomeWorksheet.Cell(1, 1).Value = "Date";
                incomeWorksheet.Cell(1, 2).Value = "Name";
                incomeWorksheet.Cell(1, 3).Value = "Source";
                incomeWorksheet.Cell(1, 4).Value = "Income";

                var expenseWorksheet = workbook.Worksheets.Add("Expense");
                expenseWorksheet.Cell(1, 1).Value = "Date";
                expenseWorksheet.Cell(1, 2).Value = "Name";
                expenseWorksheet.Cell(1, 3).Value = "Category";
                expenseWorksheet.Cell(1, 4).Value = "Expense";

                workbook.SaveAs(TransactionManager.filepath);
            }
        }
    }
}
