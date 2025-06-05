using System.Globalization;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using FinanceTracker.Controller;
namespace FinanceTracker.Utilities
{
    internal class Validator
    {
        //Regex pattern to ensure the string starts with an alphabet ends with an alphabet and may contain specified special characters ( '-.)
        static string pattern = @"^[A-Za-z]+([ '-.][A-Za-z]+)*$";
        static string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        /// <summary>
        /// Function to get a valid integer from user .
        /// </summary>
        /// <returns>Validated integer</returns>
        public static int GetValidInteger(string prompt)
        {
            Console.WriteLine($"Please enter {prompt} :");
            bool isValid = int.TryParse(Console.ReadLine(), out int validNumber);
            while (!isValid)
            {
                Helper.WriteInRed($"Please enter a valid input :");
                isValid = int.TryParse(Console.ReadLine(), out validNumber);
            }
            return validNumber;
        }

        /// <summary>
        /// Function to get a valid amount from user .
        /// </summary>
        /// <returns>Validated Amount</returns>
        public static decimal GetValidAmount()
        {
            Console.WriteLine("Please enter the amount :");
            bool isValid = decimal.TryParse(Console.ReadLine(), out decimal validAmount);
            while (!isValid || validAmount <= 0)
            {
                Helper.WriteInRed("Please enter a valid amount (Rs and Paise):");
                isValid = decimal.TryParse(Console.ReadLine(), out validAmount);
            }
            return validAmount;
        }

        /// <summary>
        /// Function to get a valid string from user .
        /// </summary>
        /// <returns>Validated string</returns>
        public static string GetValidString(string input)
        {
            Console.WriteLine($"Please enter  {input} :");
            string? userInput = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userInput) || !Regex.IsMatch(userInput, pattern))
            {
                Helper.WriteInRed($"Please enter a valid {input}:");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        /// <summary>
        /// Function to get a valid date from user .
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
                    Helper.WriteInRed("Please follow the format (dd-MM-yyyy)");
                    userInput = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Function to get a valid password from user
        /// </summary>
        /// <returns>Validated password</returns>
        public static string GetValidPassword()
        {
            Console.WriteLine("Enter the password:");
            string? password = ReadPassword();
            while (!Regex.IsMatch(password,passwordPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid PassWord");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Password must have atleast one uppercase letter,one lowercase letter,one digit and length must be within 8 to 15");
                Console.ResetColor();
                Console.WriteLine("Enter the password:");
                password = ReadPassword();

            }
            return password;
        }

        /// <summary>
        /// Function to read password from console without exposing it 
        /// </summary>
        /// <returns></returns>
        public static string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInformation = Console.ReadKey(intercept: true);
                key = keyInformation.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInformation.KeyChar))
                {
                    Console.Write("*");
                    password += keyInformation.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;
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
