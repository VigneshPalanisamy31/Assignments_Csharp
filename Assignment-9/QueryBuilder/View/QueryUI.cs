using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class QueryUI
    {
        public static void QueryTasks(List<Product> products, List<Supplier> suppliers)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nQuerying Tasks\n");
                Console.WriteLine("1.Electronics greater than $500");
                Console.WriteLine("2.Product groups along with most expensive product");
                Console.WriteLine("3.Products along with suppliers");
                Console.WriteLine("4.Second Highest element in an array and pairs summing up to target");
                Console.WriteLine("5.All books sorted by price");
                Console.WriteLine("6.QueryBuilder\n7.Exit\n");
                Console.ResetColor();
                int _choice = Validator.GetValidNumber("your choice :");
                switch (_choice)
                {
                    case 1:
                        QueryTask1.Execute(products);
                        break;
                    case 2:
                        QueryTask2.Execute1(products, suppliers);
                        break;
                    case 3:
                        QueryTask2.Execute2(products, suppliers);
                        break;
                    case 4:
                        QueryTask3.Execute();
                        break;
                    case 5:
                        QueryTask4.Execute(products);
                        break;
                    case 6:
                        QueryTask5.QueryBuilderFunctions(products, suppliers);
                        break;
                    case 7:
                        Console.WriteLine("Exiting....");
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid choice");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\nPress any key to continue....");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
