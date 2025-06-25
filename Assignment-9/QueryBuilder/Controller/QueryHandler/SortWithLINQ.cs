using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.Controller.QueryHandler
{
    internal class SortWithLINQ
    {
        /// <summary>
        /// Function to display all books sorted by price (high to low) .
        /// </summary>
        /// <param name="products">List of products</param>
        public static void SortAllBooksByPrice(List<Product> products)
        {
            List<Product>?books=products.Where(p=>p.Category.Equals("Books",StringComparison.OrdinalIgnoreCase)).OrderByDescending(p=>p.Price).ToList();
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
