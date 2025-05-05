using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shape_Hierarchy
{
    internal class Validator
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

            string color = Console.ReadLine();
            while (!Regex.IsMatch(color, @"^[A-Za-z]+([-][A-Za-z]+)*$"))
            {
                Console.WriteLine("Please enter a valid color name: ");
                color = Console.ReadLine();
            }
            return color;

        }
    }
}
