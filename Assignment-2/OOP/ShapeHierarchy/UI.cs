using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP;

namespace Shape_Hierarchy
{
    internal class UI
    {
        public static void Main(String[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Welcome to shape hierarchy....");
                Console.WriteLine("1.Circle");
                Console.WriteLine("2.Rectangle");
                Console.WriteLine("3.Exit");
                bool isInteger = int.TryParse(Console.ReadLine(), out int _choice);
                if (isInteger)
                {

                    switch (_choice)
                    {
                        case 1:
                            Circle circle = new Circle();
                            Console.WriteLine("Enter the color of the circle");
                            circle.Color = Validator.getValidColor();
                            Console.WriteLine("Enter the radius of the circle");
                            circle.Radius = Validator.getValidInput();
                            circle.PrintDetails();
                            break;
                        case 2:
                            Rectangle rectangle = new Rectangle();
                            Console.WriteLine("Enter the color of the rectangle");
                            rectangle.Color = Validator.getValidColor();
                            Console.WriteLine("Enter the length of the rectangle");
                            rectangle.Length = Validator.getValidInput();
                            Console.WriteLine("Enter the breadth of the rectangle");
                            rectangle.Breadth = Validator.getValidInput();
                            rectangle.PrintDetails();
                            break;
                        case 3: stop = true; break;
                        default: Console.WriteLine("Invalid choice"); break;


                    }

                }
                else
                    Console.WriteLine("Please enter a valid choice");
            }
        }
    }
}
