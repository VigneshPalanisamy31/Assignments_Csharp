using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    internal class Product
    {
        int _productID;
        public int ProductID { get => _productID; set => _productID = value; }

        string _productname;
        public string ProductName { get => _productname; set => _productname = value; }

        double _price;
        public double Price { get => _price; set => _price = value; }

        int _quantityInStock;
        public int QuantityInStock { get => _quantityInStock; set => _quantityInStock = value; }

        public Product(int productID, string productname, double price, int quantityInStock)
        {
            ProductID = productID;
            ProductName = productname;
            Price = price;
            QuantityInStock = quantityInStock;
        }
    }
}
