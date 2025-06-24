using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inventory_Management
{
    internal class Validator
    {
        public static int GetValidNumber(string value)
        {
            bool stop = false;
            Console.WriteLine($"Enter {value}");
            do
            {
                stop = int.TryParse(Console.ReadLine(), out int number);
                if (stop)
                    return number;
                else
                    Console.WriteLine($"Please enter a valid {value}");
                if (value.Contains("stock quantity"))
                    Console.WriteLine("(Quantity must be a whole number)");

            } while (!stop);
            return 0;
        }

        public static string GetValidName(string value)
        {
            bool stop = false;
            Console.WriteLine($"Enter {value}");
            do
            {
                string name = Console.ReadLine();
                stop = Regex.IsMatch(name, @"^[A-Za-z]+([ '-.][A-Za-z]+)*$");
                if (stop)
                    return name;
                else
                    Console.WriteLine($"Please enter a valid {value}");

            } while (!stop);
            return "";
        }
        public static string IsNameAvailable(string name, List<Product> Products)
        {
            bool stop = false;
            while (!stop)
            {
                foreach (Product p in Products)
                {
                    if (p.ProductName.Equals(name,StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("A product with same name exists..");
                        return IsNameAvailable(GetValidName("a different product name :"), Products);

                    }
                }
                stop = true;
            }
            return name;
        }

        public static int IsIdAvailable(int id, List<Product> Products)
        {
            bool stop = false;
            while (!stop)
            {
                foreach (Product p in Products)
                {
                    if (p.ProductID == id)
                    {
                        Console.WriteLine("A product with same id exists..");
                        return IsIdAvailable(GetValidNumber("different product id :"), Products);

                    }
                }
                stop = true;
            }
            return id;
        }
        public static double GetValidPrice()
        {
            bool stop = false;
            Console.WriteLine($"Enter the price :");
            do
            {
                stop = double.TryParse(Console.ReadLine(), out double number);
                if (stop)
                    return number;
                else
                    Console.WriteLine($"Please enter a valid price:");

            } while (!stop);
            return 0;
        }
        public static bool isEmpty(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available in the inventory");
                return true;
            }
            return false;
        }
    }
}
