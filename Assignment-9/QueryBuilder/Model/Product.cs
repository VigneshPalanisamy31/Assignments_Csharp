namespace LINQ.Model
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public Product(int productID, string productname, decimal price, string category)
        {
            ProductID = productID;
            ProductName = productname;
            Price = price;
            Category = category;
        }
    }
}


