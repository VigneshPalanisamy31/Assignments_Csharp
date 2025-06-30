using LINQ.Model;
using System.Globalization;
namespace LINQ.Utilities
{
    internal class ProductInputHandler
    {
        /// <summary>
        /// Function to get product details from user
        /// </summary>
        /// <param name="Products">List of products</param>
        /// <returns>A new product with user ggiven details</returns>
        public Product? GetProductDetails(List<Product> Products)
        {
            int productID = Validator.GetUniqueProductID(Helper.GetValidNumber("productid :"), Products);
            if (productID == -1)
                return null;
            string productName = Validator.GetUniqueProductName(Helper.GetValidName("product name :"), Products);
            decimal price = Helper.GetValidPrice();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string category = textInfo.ToTitleCase(Helper.GetValidName("category :"));
            return new Product(productID, productName, price, category);
        }
    }
}
