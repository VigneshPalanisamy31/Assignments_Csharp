namespace DynamicSerializer
{
    internal class Product
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public Product(string productName, int productId, string productCategory, decimal productPrice)
        {
            ProductName = productName;
            ProductId = productId;
            ProductCategory = productCategory;
            ProductPrice = productPrice;
        }
    }
}
