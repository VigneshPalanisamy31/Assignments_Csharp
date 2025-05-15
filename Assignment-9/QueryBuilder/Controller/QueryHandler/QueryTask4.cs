using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using LINQ.Model;

namespace LINQ.Controller.QueryHandler
{
    internal class QueryTask4
    {
        /// <summary>
        /// Function to display all books sorted by price (high to low) .
        /// </summary>
        /// <param name="products"></param>
        public static void Execute(List<Product> products)
        {
            var books=products.Where(p=>p.Category.Equals("Books",StringComparison.OrdinalIgnoreCase)).OrderByDescending(p=>p.Price).ToList();
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("Books sorted by price (Highest to Lowest)\n");
            Console.ResetColor();
            var table = new ConsoleTable("Book Name", "Price");
            foreach (Product p in books)
            {
                table.AddRow(p.ProductName, p.Price);
            }
            table.Write(Format.Alternative);
        }
    }
}
