using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inventory_Management
{
    internal class UI
    {
        public static void Main(string[] args)
        {
            ProductManager inventory = new ProductManager();

            bool stop = false;
            do
            {
                Console.WriteLine("------------Welcome to Inventory Manager -------------");
                Console.WriteLine("1.Add Product");
                Console.WriteLine("2.Edit Product");
                Console.WriteLine("3.Search Product");
                Console.WriteLine("4.Delete Product");
                Console.WriteLine("5.View Inventory");
                Console.WriteLine("6.Exit");

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
                        Console.WriteLine("Please enter a valid input");
                        break;

                }
                Console.WriteLine("\n\nPress any key to continue.."); Console.ReadKey(); Console.Clear();
            } while (!stop);

        }
    }
}
