using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class InputHandler
    {
        public Product GetProductDetails(List<Product> Products)
        {
            int productID = Validator.IsIdAvailable(Validator.GetValidNumber("productid :"), Products);
            if (productID == -1)
                return null;
            string productname = Validator.IsNameAvailable(Validator.GetValidName("product name :"), Products);
            double price = Validator.GetValidPrice();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string category = textInfo.ToTitleCase(Validator.GetValidName("category :"));
            return new Product(productID, productname, price, category);
        }
    }
}
