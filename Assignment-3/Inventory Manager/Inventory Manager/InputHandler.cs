using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    internal class InputHandler
    {
        public Product GetProductDetails(List<Product> Products)
        {
            int productID = Validator.IsIdAvailable(Validator.GetValidNumber("productid :"), Products);
            string productname = Validator.IsNameAvailable(Validator.GetValidName("product name :"), Products);
            double price = Validator.GetValidPrice();
            int quantityinstock = Validator.GetValidNumber("stock quantity :");
            return new Product(productID, productname, price, quantityinstock);
        }
    }
}
