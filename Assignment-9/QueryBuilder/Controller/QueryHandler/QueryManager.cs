using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;

namespace LINQ.Controller.QueryHandler
{
    internal class QueryManager
    {
        /// <summary>
        /// Displays products of given category with price greater than given value .
        /// </summary>
        /// <param name="products">List of products</param>
        public void FilterProductsWithGreaterPrice(List<Product> products, string category, decimal price)
        {
            IEnumerable<Product> result = products.Where(product => product.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase) && product.Price > 500)
                                                  .OrderByDescending(product => product.Price);
            decimal avgPrice = result.Average(product => product.Price);
            Helper.WriteInYellow("Electronics with price greater than 500$\n\n");
            ConsoleTable table = new("Product Name", "Price");
            foreach (Product product in result)
            {
                table.AddRow(product.ProductName, product.Price);
            }
            table.Write(Format.Alternative);
            Console.WriteLine("\nAverage Price = " + avgPrice);
        }

        /// <summary>
        /// Function to display products grouped by category along with most expensive product of each category .
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public void GroupProductsByCategory(List<Product> products, List<Supplier> suppliers)
        {
            var productGroups = products.GroupBy(p => p.Category)
                .Select(grp => new
                {
                    Category = grp.Key,
                    Count = grp.Count(),
                    MostExpensiveProduct = grp.OrderByDescending(p => p.Price).FirstOrDefault()
                });
            ConsoleTable table = new("Category", "Count", "MostExpensive Product", "Highest Price");
            foreach (var productGroup in productGroups)
            {
                table.AddRow(productGroup.Category, productGroup.Count, productGroup.MostExpensiveProduct.ProductName, productGroup.MostExpensiveProduct.Price);
            }
            Helper.WriteInYellow("Products grouped based on categories along with the most expensive product");
            table.Write(Format.Alternative);
        }

        /// <summary>
        /// Function to join and display products with suppliers 
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public void JoinProductsWithSuppliers(List<Product> products, List<Supplier> suppliers)
        {
            var productSuppliers = from product in products
                                   join supplier in suppliers
                                   on product.ProductID equals supplier.ProductID
                                   select new
                                   {
                                       product.ProductID,
                                       product.ProductName,
                                       supplier.SupplierName,
                                   };
            ConsoleTable table = new("ProductId", "Product Name", "Supplier Name");
            foreach (var product in productSuppliers)
                table.AddRow(product.ProductID, product.ProductName, product.SupplierName); ;
            Helper.WriteInYellow("\nProducts along with their suppliers");
            table.Write(Format.Alternative);
        }

        /// <summary>
        /// Function to display second highest number and pairs that sum up to given target .
        /// </summary>
        public void DisplayPairsSummingUptoTarget()
        {
            int arraySize = Helper.GetValidNumber("array size ");
            float[] array = new float[arraySize];
            Console.WriteLine("Enter the array elements");
            for (int i = 0; i < arraySize; i++)
            {
                if (!float.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Operation terminated due to invalid input\nExpected input:Valid Integers...");
                    return;
                }
            }
            if (arraySize < 2)
            {
                Console.WriteLine("Insufficient Elements to find second highest element");
                return;
            }
            try
            {
                float secondHighest = array.OrderByDescending(n => n).Distinct().Skip(1).First();
                Helper.WriteInGreen("Second Highest Number : " + secondHighest);
            }
            catch (Exception e)
            {
                Console.WriteLine("Insufficient Distinct Elements to find second highest element");
            }
            float target = Helper.GetValidFloat("Target sum:");
            var TargetPairs = array.SelectMany((value, index) => array.Skip(index + 1),
                                             (first, second) => new { first, second }).Where(pair => pair.first + pair.second == target).Distinct().ToList();
            Helper.WriteInYellow("Pairs summing up to target :");
            foreach (var pair in TargetPairs)
            {
                Console.WriteLine($"({pair.first},{pair.second})");
            }
        }

       /// <summary>
       /// Function to sort products of given category by given key.
       /// </summary>
       /// <typeparam name="TKey"></typeparam>
       /// <param name="products">List of products</param>
       /// <param name="category">Category of products to sort</param>
       /// <param name="KeyField">Key to sort by</param>
        public void SortProductsOfCategoryByKey<TKey>(List<Product> products,string category,Func<Product,TKey>KeyField)
        {
            List<Product>? books = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).OrderByDescending(KeyField).ToList();
            Helper.WriteInYellow("Books sorted by price (Highest to Lowest)\n");
            ConsoleTable table = new("Book Name", "Price");
            foreach (Product p in books)
            {
                table.AddRow(p.ProductName, p.Price);
            }
            table.Write(Format.Alternative);
        }
    }
}
