using System.Globalization;
using LINQ.Model;
namespace LINQ.Utilities
{
    internal class FetchUserData
    {
        /// <summary>
        /// Function to get product details from user
        /// </summary>
        /// <param name="Products"></param>
        /// <returns></returns>
        public Product? GetProductDetails(List<Product> Products)
        {
            int productID = Validator.IsProductIdAvailable(Validator.GetValidNumber("productid :"), Products);
            if (productID == -1)
                return null;
            string productname = Validator.IsProductNameAvailable(Validator.GetValidName("product name :"), Products);
            decimal price = Validator.GetValidPrice();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string category = textInfo.ToTitleCase(Validator.GetValidName("category :"));
            return new Product(productID, productname, price, category);
        }
    }
}
