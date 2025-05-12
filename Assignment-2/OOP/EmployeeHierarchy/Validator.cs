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
        /// <summary>
        /// Function to validate user entered salary
        /// </summary>
        /// <returns></returns>
        public static double GetValidSalary()
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
        /// <summary>
        /// Function to validate user entered name.
        /// </summary>
        /// <returns></returns>
        public static string GetValidName()
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
