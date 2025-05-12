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
        /// <summary>
        /// Function to validate and return a valid double value
        /// </summary>
        /// <returns>valid value(double)</returns>
        public static double GetValidInput()
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
        /// <summary>
        /// Function to validate and return a string(color)
        /// </summary>
        /// <returns></returns>
        public static string GetValidColor()
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
