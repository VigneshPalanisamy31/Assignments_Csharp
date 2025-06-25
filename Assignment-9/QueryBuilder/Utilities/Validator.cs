using System.Text.RegularExpressions;
using LINQ.Model;
namespace LINQ.Utilities
{
    internal class Validator
    {
        /// <summary>
        /// Function to get a number from user
        /// </summary>
        /// <param name="displayMessage"></param>
        /// <returns>Valid Number</returns>
        public static float GetValidFloat(string displayMessage)
        {
            bool isExit = false;
            Console.WriteLine($"Enter {displayMessage}");
            while (!isExit)
            {
                isExit = float.TryParse(Console.ReadLine(), out float validNumber);
                if (isExit && validNumber > 0)
                    return validNumber;
                else
                {
                    Helper.WriteInRed($"Please enter a valid {displayMessage}");
                }
            }
            return 0;
        }
        /// <summary>
        /// Function to get a valid integer input from user.
        /// </summary>
        /// <param name="displayMessage"></param>
        /// <returns>Valid Integer</returns>
        public static int GetValidNumber(string displayMessage)
        {
            bool isExit = false;
            Console.WriteLine($"Enter {displayMessage}");
            while (!isExit)
            {
                isExit = int.TryParse(Console.ReadLine(), out int number);
                if (isExit&&number>0)
                    return number;
                else
                {
                    Helper.WriteInRed($"Please enter a valid {displayMessage}");
                    isExit = false;
                }
                if (displayMessage.Contains("stock quantity"))
                    Helper.WriteInYellow("(Quantity must be a whole number)");
            }
            return 0;
        }

        /// <summary>
        /// Function to get a valid name from user.
        /// </summary>
        /// <param name="displayMessage"></param>
        /// <returns></returns>
        public static string GetValidName(string displayMessage)
        {
            bool isExit = false;
            Console.WriteLine($"Enter {displayMessage}");
            while (!isExit)
            {
                string? name = Console.ReadLine();
                isExit = Regex.IsMatch(name, @"^[A-Za-z]+([ '-.]*[A-Za-z0-9]+)*$");
                if (isExit)
                    return name;
                else
                    Helper.WriteInRed($"Please enter a valid {displayMessage}");
            }
            return "";
        }

        /// <summary>
        /// Function to check if product name is already available in the inventory.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="Products"></param>
        /// <returns>New unique product name</returns>
        public static string IsProductNameAvailable(string productName, List<Product> Products)
        {
            while (true)
            {
                bool isUniqueProduct = true;
                foreach (Product p in Products)
                {
                    if (p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("A product with same name exists..");
                        isUniqueProduct = false;
                        break;
                    }
                }
                if (isUniqueProduct)
                    return productName;
                else
                    productName = GetValidName("a different product name :");
            }
        }
        /// <summary>
        /// Function to check if product id is already available in inventory.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="Products"></param>
        /// <returns>New unique product id</returns>
        public static int IsProductIdAvailable(int productID, List<Product> Products)
        {
            bool isExit = false;
            while (!isExit)
            {
                foreach (Product p in Products)
                {
                    if (p.ProductID == productID)
                    {
                        Helper.WriteInRed("A product with same id exists..");
                        return IsProductIdAvailable(GetValidNumber("different product id :"), Products);
                    }
                }
                isExit = true;
            }
            return productID;
        }

        /// <summary>
        /// Function to validate price given by user.
        /// </summary>
        /// <returns>Valid Price</returns>
        public static decimal GetValidPrice()
        {
            bool isExit = false;
            Console.WriteLine($"Enter the price :");
            do
            {
                isExit = decimal.TryParse(Console.ReadLine(), out decimal validPrice);
                if (isExit)
                    return validPrice;
                else
                    Helper.WriteInRed($"Please enter a valid price:");
            } while (!isExit);
            return 0;
        }
        /// <summary>
        /// Funntion to check if the inventory is empty.
        /// </summary>
        /// <param name="products"></param>
        /// <returns>True if inventory is is empty and false if not</returns>
        public static bool isEmpty(List<Product> products)
        {
            if (products.Count == 0)
            {
                Helper.WriteInRed("No products available in the inventory");
                return true;
            }
            return false;
        }
    }
}
