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
        static int SortByName(Product a, Product b)
        {
            return a.Name.CompareTo(b.Name);
        }
        static int SortByCategory(Product a, Product b)
        {
            return a.Category.CompareTo(b.Category);
        }
        static int SortByPrice(Product a, Product b)
        {
            return a.Price.CompareTo(b.Price);
        }

        static void SortAndDisplay(SortDelegate sorter, List<Product> products)
        {
            products.Sort((a, b) => sorter(a, b));
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
