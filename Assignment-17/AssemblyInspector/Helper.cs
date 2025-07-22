using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInspector
{
    internal class Helper
    {
        /// <summary>
        /// Writes diplay message in red colour.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInRed(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
        /// <summary>
        /// Writes display message in green.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInGreen(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
        /// <summary>
        /// Writes display message in yellow.
        /// </summary>
        /// <param name="displayMessage"></param>
        public static void WriteInYellow(string displayMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }
    }
}
