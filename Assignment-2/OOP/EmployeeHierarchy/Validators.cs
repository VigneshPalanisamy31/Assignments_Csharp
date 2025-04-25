using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee_Hierarchy
{
    internal class Validators
    {
        public static double getValidSalary()
        {
            while (true)
            {
                bool isValid = double.TryParse(Console.ReadLine(), out double value);
                if (isValid)
                    return value;
                else
                    Console.WriteLine("Please enter a valid number:");

            }
        }
        public static string getValidName()
        {

            string pattern = @"^\D+$";
            string name = Console.ReadLine();
            while (!Regex.IsMatch(name, pattern))
            {
                Console.WriteLine("Please enter a valid name");
                name = Console.ReadLine();
            }
            return name;

        }
    }
}
