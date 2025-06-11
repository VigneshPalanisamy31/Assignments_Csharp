namespace AdvancedDelegates
{
    internal class Program
    {
     public delegate int SortDelegate(Product firstProduct,Product secondProduct);
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Laptop", "Electronics", 75000),
                new Product("Shampoo", "Personal Care", 250),
                new Product("Smartphone", "Electronics", 50000),
                new Product("Notebook", "Stationery", 40),
                new Product("Toothpaste", "Personal Care", 90)
            };
            SortDelegate sortByName = SortByName;
            SortDelegate sortByCategory = SortByCategory;
            SortDelegate sortByPrice = SortByPrice;

            Console.WriteLine("Sorted by Name:");
            SortAndDisplay(sortByName,products);
            Console.WriteLine("\nSorted by Category:");
            SortAndDisplay(sortByCategory,products);
            Console.WriteLine("\nSorted by Price:");
            SortAndDisplay(sortByPrice,products);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        static int SortByName(Product product_A, Product product_B)
        {
            return product_A.Name.CompareTo(product_B.Name);
        }
        static int SortByCategory(Product product_A, Product product_B)
        {
            return product_A.Category.CompareTo(product_B.Category);
        }
        static int SortByPrice(Product product_A, Product product_B)
        {
            return product_A.Price.CompareTo(product_B.Price);
        }

        static void SortAndDisplay(SortDelegate sorter, List<Product> products)
        {
            products.Sort((product_A, product_B) => sorter(product_A, product_B));
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
