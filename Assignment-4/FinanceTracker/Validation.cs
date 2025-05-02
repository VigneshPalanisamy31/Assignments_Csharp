using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace FinanceTracker
{
    internal class Validation
    {

        public static int GetValidInteger(string prompt)
        {
            Console.WriteLine($"Please enter {prompt} :");
            bool valid = int.TryParse(Console.ReadLine(), out int choice);
            while (!valid)
            {
                Console.WriteLine($"Please enter a valid input :");
                valid = int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }

        public static double GetValidAmount()
        {
            Console.WriteLine("Please enter the amount :");
            bool valid = double.TryParse(Console.ReadLine(), out double amount);
            while (!valid || amount <= 0)
            {
                Console.WriteLine("Please enter a valid amount :");
                valid = double.TryParse(Console.ReadLine(), out amount);
            }
            return amount;
        }


        public static string GetValidString(string input)
        {
            Console.WriteLine($"Please enter  {input} :");
            string category = Console.ReadLine();
            string pattern = @"^\D+$";
            while (!Regex.IsMatch(category, pattern) || String.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine($"Please enter a valid {input}:");
                category = Console.ReadLine();
            }
            return category;
        }

        public static DateTime GetValidDate()
        {
            Console.WriteLine("Enter the date of the transaction (dd-MM-yyyy) :");
            DateTime date;
            while (true)
            {
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out date))
                    return date;
                else
                    Console.WriteLine("Please follow the format (dd-MM-yyyy)");
            }
        }

        public static void FileIntegrity(string filepath)
        {
            if (!File.Exists(filepath))
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



                workbook.SaveAs(filepath);
            }
        }
    }
}
