using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace QueryBuilder
{
    internal class QueryTask4
    {
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
