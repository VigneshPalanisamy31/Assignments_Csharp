using ClosedXML.Excel;
using FinanceTracker.Controller;
using FinanceTracker.View;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
namespace FinanceTracker.Utilities
{
    internal class Validator
    {
        //Regex pattern to ensure the string starts with an alphabet ends with an alphabet and may contain specified special characters ( '-.)
        static string pattern = @"^[A-Za-z]+([ '-.][A-Za-z]+)*$";
        static string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$#!%*?&^])[A-Za-z\d@$#!%*?&^]{8,}$";
        /// <summary>
        /// Function to get a valid integer from user .
        /// </summary>
        /// <returns>Validated integer</returns>
        public static int GetValidInteger(string prompt)
        {
            Console.WriteLine($"Enter {prompt} :");
            bool isValid = int.TryParse(Console.ReadLine(), out int validNumber);
            while (!isValid)
            {
                Helper.WriteInRed($"Enter a valid input :");
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
            Console.WriteLine("Enter the amount:");
            bool isValid = decimal.TryParse(Console.ReadLine(), out decimal validAmount);
            while (!isValid || validAmount <= 0)
            {
                Helper.WriteInRed("Enter a valid amount (Rs and Paise):");
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
            Console.WriteLine($"Enter {input}:");
            string? userInput = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userInput) || !Regex.IsMatch(userInput, pattern))
            {
                Helper.WriteInRed($"Enter a valid {input}:");
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
                if (DateOnly.TryParseExact(userInput, "yyyy-MM-dd", null, DateTimeStyles.None, out date))
                    return date;
                else
                {
                    Helper.WriteInRed("Please follow the format (yyyy-mm-dd)");
                    userInput = Console.ReadLine();
                }
            }
        }

        public static string GetHashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())  
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder(); 
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2")); 
                return sb.ToString();
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
                XLWorkbook workbook = new();
                IXLWorksheet incomeWorksheet = workbook.Worksheets.Add("Income");
                incomeWorksheet.Cell(1, 1).Value = "Date";
                incomeWorksheet.Cell(1, 2).Value = "UserID";
                incomeWorksheet.Cell(1, 3).Value = "Source";
                incomeWorksheet.Cell(1, 4).Value = "Income";

                IXLWorksheet expenseWorksheet = workbook.Worksheets.Add("Expense");
                expenseWorksheet.Cell(1, 1).Value = "Date";
                expenseWorksheet.Cell(1, 2).Value = "UserID";
                expenseWorksheet.Cell(1, 3).Value = "Category";
                expenseWorksheet.Cell(1, 4).Value = "Expense";

                IXLWorksheet UserList = workbook.Worksheets.Add("Users");
                UserList.Cell(1, 1).Value = "ID";
                UserList.Cell(1, 2).Value = "Name";
                UserList.Cell(1, 3).Value = "Password";

                workbook.SaveAs(TransactionManager.filepath);
            }
            else
            {
                XLWorkbook workbook = new(TransactionManager.filepath);
                if (!workbook.Worksheets.Contains("Users"))
                    {
                    IXLWorksheet UserList = workbook.Worksheets.Add("Users");
                    UserList.Cell(1, 1).Value = "ID";
                    UserList.Cell(1, 2).Value = "Name";
                    UserList.Cell(1, 3).Value = "Password";
                }
                if (!workbook.Worksheets.Contains("Income"))
                {
                    IXLWorksheet incomeWorksheet = workbook.Worksheets.Add("Income");
                    incomeWorksheet.Cell(1, 1).Value = "Date";
                    incomeWorksheet.Cell(1, 2).Value = "UserID";
                    incomeWorksheet.Cell(1, 3).Value = "Source";
                    incomeWorksheet.Cell(1, 4).Value = "Income";
                }
                if(!workbook.Worksheets.Contains("Expense"))
                {
                    IXLWorksheet expenseWorksheet = workbook.Worksheets.Add("Expense");
                    expenseWorksheet.Cell(1, 1).Value = "Date";
                    expenseWorksheet.Cell(1, 2).Value = "UserID";
                    expenseWorksheet.Cell(1, 3).Value = "Category";
                    expenseWorksheet.Cell(1, 4).Value = "Expense";
                }
                workbook.Save();
            }
        }
    }
}
