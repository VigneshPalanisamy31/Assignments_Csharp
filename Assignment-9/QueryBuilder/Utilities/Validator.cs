using System.Text.RegularExpressions;
using LINQ.Model;
namespace LINQ.Utilities
{
    internal class Validator
    {
        
        /// <summary>
        /// Function to check if product name is already available in the inventory.
        /// </summary>
        /// <param name="productName">Product name to be checked</param>
        /// <param name="Products">List of products to check from</param>
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
                    productName = Helper.GetValidName("a different product name :");
            }
        }

        /// <summary>
        /// Function to check if product id is already available in inventory.
        /// </summary>
        /// <param name="productID">Product ID to be checked</param>
        /// <param name="Products">List of products to check from</param>
        /// <returns>New unique product id</returns>
        public static int IsProductIdAvailable(int productID, List<Product> Products)
        {
            bool canExit = false;
            while (!canExit)
            {
                foreach (Product p in Products)
                {
                    if (p.ProductID == productID)
                    {
                        Helper.WriteInRed("A product with same id exists..");
                        return IsProductIdAvailable(Helper.GetValidNumber("different product id :"), Products);
                    }
                }
                canExit = true;
            }
            return productID;
        }

        /// <summary>
        /// Funntion to check if the inventory is empty.
        /// </summary>
        /// <param name="products">List of products</param>
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
