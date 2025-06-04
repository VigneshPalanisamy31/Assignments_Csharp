using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicArithmetic
{
    internal class Program
    {
        /// <summary>
        /// Function to return a valid integer from the user-end.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>validated integer</returns>
        public static int GetValidatedInteger(string input) 
        {
            int result;
            while(!int.TryParse(input, out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid integer ");
                Console.ResetColor();
                Console.WriteLine("Enter a number :");
                input= Console.ReadLine();
            }
            return result; 
        
        }
        public static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("========Basic ArithMetics========");
                Console.WriteLine("\n\nEnter Number 1: ");
                int firstNum = GetValidatedInteger(Console.ReadLine());
                Console.WriteLine("\nEnter Number 2: ");
                int secondNum = GetValidatedInteger(Console.ReadLine());
                Console.WriteLine("\n\n1.Add\n2.Subtract\n3.Multiply\n4.Divide\n5.Exit\n");
                Console.WriteLine("Enter your choice:");
                int _choice = GetValidatedInteger(Console.ReadLine());
                switch (_choice)
                {
                    case 1:
                        Console.WriteLine($"The sum of {firstNum} and {secondNum} is {MathUtils.Add(firstNum, secondNum)}");
                        break;

                    case 2:
                        Console.WriteLine($"The difference between {firstNum} and {secondNum} is {MathUtils.Subtract(firstNum, secondNum)}");
                        break;

                    case 3:
                        Console.WriteLine($"The product of {firstNum} and {secondNum} is {MathUtils.Multiply(firstNum, secondNum)}");
                        break;

                    case 4:
                        if(MathUtils.Divide(firstNum, secondNum)!=0)
                         Console.WriteLine($"The quotient of {firstNum} and {secondNum} is {MathUtils.Divide(firstNum, secondNum)}");
                        break;

                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting ....");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice\n");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }     
    }
}
