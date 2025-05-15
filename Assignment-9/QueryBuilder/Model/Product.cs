using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Model
{
    internal class Product
    {
        private int _productID;
        public int ProductID { get => _productID; set => _productID = value; }

        private string _productname;
        public string ProductName { get => _productname; set => _productname = value; }

        private double _price;
        public double Price { get => _price; set => _price = value; }

        private string _category;
        public string Category { get => _category; set => _category = value; }

        public Product(int productID, string productname, double price, string category)
        {
            ProductID = productID;
            ProductName = productname;
            Price = price;
            Category = category;
        }
    }
}


