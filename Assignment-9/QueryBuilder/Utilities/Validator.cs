using LINQ.Model;
namespace LINQ.Utilities
{
    internal class Validator
    {

        /// <summary>
        /// Function to get unique product name.
        /// </summary>
        /// <param name="productName">Product name to be checked</param>
        /// <param name="products">List of products to check from</param>
        /// <returns>New unique product name</returns>
        public static string GetUniqueProductName(string productName, List<Product> products)
        {
            while (true)
            {
                bool isUniqueProduct = true;
                foreach (Product product in products)
                {
                    if (product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("A product with same name exists..");
                        isUniqueProduct = false;
                        break;
                    }
                }
                if (isUniqueProduct)
                {
                    return productName;
                }
                productName = Helper.GetValidName("a different product name :");
            }
        }

        /// <summary>
        /// Function to get unique product id.
        /// </summary>
        /// <param name="productID">Product ID to be checked</param>
        /// <param name="products">List of products to check from</param>
        /// <returns>New unique product id</returns>
        public static int GetUniqueProductID(int productID, List<Product> products)
        {
            bool canExit = false;
            while (!canExit)
            {
                foreach (Product product in products)
                {
                    if (product.ProductID == productID)
                    {
                        Helper.WriteInColor("A product with same id exists..", ConsoleColor.Red);
                        return GetUniqueProductID(Helper.GetValidNumber("different product id :"), products);
                    }
                }
                canExit = true;
            }
            return productID;
        }

        /// <summary>
        /// Function to check if the inventory is empty.
        /// </summary>
        /// <param name="products">List of products</param>
        /// <returns>True if inventory is is empty and false if not</returns>
        public static bool isEmpty(List<Product> products)
        {
            if (products.Count == 0)
            {
                Helper.WriteInColor("No products available in the inventory", ConsoleColor.Red);
                return true;
            }
            return false;
        }
    }
}
