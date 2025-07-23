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
        /// Writes display message in red color.
        /// </summary>
        /// <param name="displayMessage">Message to be displayed in the console</param>
        /// <param name="color">Console</param>
        public static void WriteInColor(string displayMessage,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(displayMessage);
            Console.ResetColor();
        }

    }
}
