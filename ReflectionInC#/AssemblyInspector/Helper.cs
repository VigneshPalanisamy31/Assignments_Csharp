using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInspector
{
    internal class Helper
    {
        public static void WriteInRed(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
        public static void WriteInGreen(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
        public static void WriteInYellow(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }

    }
}
