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
            bool isUniqueProduct = !products.Any(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (isUniqueProduct)
            {
                return productName;
            }
            Helper.WriteInColor("A product with same name exists..", ConsoleColor.Red);
            return GetUniqueProductName(Helper.GetValidName("a different product name :"), products);
        }

        /// <summary>
        /// Function to get unique product id.
        /// </summary>
        /// <param name="productID">Product ID to be checked</param>
        /// <param name="products">List of products to check from</param>
        /// <returns>New unique product id</returns>
        public static int GetUniqueProductID(int productID, List<Product> products)
        {
            bool isUniqueProductID = !products.Any(p => p.ProductID == productID);
            if (isUniqueProductID)
            {
                return productID;
            }
            Helper.WriteInColor("A product with same id exists..", ConsoleColor.Red);
            return GetUniqueProductID(Helper.GetValidNumber("different product id :"), products);

        }

        /// <summary>
        /// Function to check if the inventory is empty.
        /// </summary>
        /// <param name="products">List of products</param>
        /// <returns>True if inventory is is empty and false if not</returns>
        public static bool isEmpty(List<Product> products)
        {
            if (!products.Any())
            {
                Helper.WriteInColor("No products available in the inventory", ConsoleColor.Red);
                return true;
            }
            return false;
        }
    }
}
