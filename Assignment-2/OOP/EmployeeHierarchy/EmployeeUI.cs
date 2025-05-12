using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Hierarchy
{
    internal class EmployeeUI
    {
        public static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("\nWelcome to bank hierarchy....");
                Console.WriteLine("1.Manager");
                Console.WriteLine("2.Developer");
                Console.WriteLine("3.Exit");
                bool isInteger = int.TryParse(Console.ReadLine(), out int _choice);
                if (isInteger)
                {

                    switch (_choice)
                    {
                        case 1:
                            Manager manager = new Manager();
                            Console.WriteLine("Enter the name of the manager");
                            manager.Name = Validator.GetValidName();
                            Console.WriteLine("Enter the salary of the manager");
                            manager.Salary = Validator.GetValidSalary();
                            manager.PrintDetails();
                            break;

                        case 2:
                            Developer developer = new Developer();
                            Console.WriteLine("Enter the name of the developer");
                            developer.Name = Validator.GetValidName();
                            Console.WriteLine("Enter the salary of the developer");
                            developer.Salary = Validator.GetValidSalary();
                            developer.PrintDetails();
                            break;

                        case 3: stop = true; break;

                        default: Console.WriteLine("Invalid choice"); break;


                    }

                }
                else
                    Console.WriteLine("Please enter a valid choice");
            }
            Console.ReadKey();
        }
    }
}
