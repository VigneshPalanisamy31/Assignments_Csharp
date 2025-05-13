using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class ApplicationUI
    {
        public static void Main(string[]args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "Laptop", 70000, "Electronics"));
            products.Add(new Product(2, "AC", 20000, "Electronics"));
            products.Add(new Product(3, "BookA", 2000, "books"));
            products.Add(new Product(4, "BookB", 2000, "books"));
            List<Supplier> suppliers = new List<Supplier>();
            bool exit = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1.ProductHandler\n2.QueryHandler");
                Console.ResetColor();
                int _choice = Validator.GetValidNumber("your choice :");
                switch (_choice)
                {
                    case 1:
                        ProductHandlerUI.ProductHandlingFunctions(products,suppliers);
                        break;
                    case 2:
                        QueryUI.QueryTasks(products,suppliers);
                        break;
                    case 3:Console.WriteLine("Exiting......");
                        exit = true;
                        break;

                }
                

            } while (!exit);

        }
    }
}
