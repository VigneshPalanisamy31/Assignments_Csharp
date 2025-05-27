using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityApp
{
    public class Helper
    {
        public static int ValidInt(string input)
        {
            int result;
            while (!int.TryParse(input, out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid integer ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                input = Console.ReadLine();
            }
            return result;

        }
    }
}
