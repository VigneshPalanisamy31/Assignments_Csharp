using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shape_Hierarchy
{
    internal class Validators
    {
        public static double getValidInput()
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
        public static string getValidColor()
        {

            string pattern = @"^\D+$";
            string color = Console.ReadLine();
            while (!Regex.IsMatch(color, pattern))
            {
                Console.WriteLine("Colorname cannot contain numbers");
                color = Console.ReadLine();
            }
            return color;

        }
    }
}
