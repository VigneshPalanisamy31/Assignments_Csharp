using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Collections
{
    internal class Validator
    {
        public static int GetValidInt(string displaymsg)
        {
            while(true)
            {
                Console.WriteLine($"\nEnter the {displaymsg} :");
                string input=Console.ReadLine();
                if(int.TryParse(input, out int value)&&value>0 )
                    return value;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInvalid {displaymsg} (required format:positive integer");
                    Console.ResetColor();
                }
           }
        }

        public static string GetValidString(string input)
        {
            while (true)
            {
                Console.WriteLine($"\nEnter the {input}");
                string validName=Console.ReadLine();
                if (Regex.IsMatch(validName,@"^[A-Za-z][A-Za-z0-9]{2,}"))
                    return validName;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Name");
                    Console.ResetColor();
                }
            }

        }
    }
}
