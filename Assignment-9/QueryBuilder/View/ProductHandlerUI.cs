using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.Controller.ProductHandler;
using LINQ.Model;
using LINQ.Utilities;

namespace LINQ.View
{
    internal class ProductHandlerUI
    {
        public static void ProductHandlingFunctions(List<Product> products,List<Supplier> suppliers)
        {

            bool stop = false;
            do
            {
                ProductManager inventory = new ProductManager(products,suppliers);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1.Add Product");
                Console.WriteLine("2.Edit Product");
                Console.WriteLine("3.Search Product");
                Console.WriteLine("4.Delete Product");
                Console.WriteLine("5.View Inventory");
                Console.WriteLine("6.Exit");
                Console.ResetColor();

                int _choice = Validator.GetValidNumber("your choice :");
                switch (_choice)
                {
                    case 1:
                        inventory.AddNewProduct();
                        break;
                    case 2:
                        inventory.EditProduct();
                        break;
                    case 3:
                        inventory.SearchProduct();
                        break;
                    case 4:
                        inventory.DeleteProduct();
                        break;
                    case 5:
                        inventory.ViewProducts();
                        break;
                    case 6:
                        stop = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid input");
                        Console.ResetColor();
                        break;

                }
                Console.WriteLine("\n\nPress any key to continue.."); Console.ReadKey(); Console.Clear();
            } while (!stop);

        }
    }
}
