using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee_Hierarchy
{
    internal class Validator
    {
        public static double getValidSalary()
        {
            while (true)
            {
                string value = Console.ReadLine();
                if (!Regex.IsMatch(value, @"^\d+(\.\d{1,2})?$"))

                {
                    Console.WriteLine("Please enter a valid salary: [Rupees and paise]");

                }
                else
                {
                    double.TryParse(value, out double amount);
                    return amount;
                }


            }
        }
        public static string getValidName()
        {
            string name = Console.ReadLine();
            while (!Regex.IsMatch(name, @"^[A-za-z]+([ '.-][A-Za-z]+)*$"))
            {
                Console.WriteLine("Please enter a valid name");
                name = Console.ReadLine();
            }
            return name;

        }
    }
}
