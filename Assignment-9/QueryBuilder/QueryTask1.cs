using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace QueryBuilder
{
    internal class QueryTask1
    {
        public static void Execute(List<Product> products)
        {
            
            IEnumerable<Product> result = products.Where(product => product.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase)&&product.Price>500)
                .OrderByDescending(product=>product.Price);
            double avgPrice=result.Average(product=>product.Price);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Electronics with price greater than 500$\n\n");
            Console.ResetColor();
            var tableObj = new ConsoleTable("Product Name","Price");
            foreach (Product product in result)
            {
                tableObj.AddRow(product.ProductName,product.Price);
            }
            tableObj.Write(Format.Alternative);
            Console.WriteLine("\n\nAverage Price = "+avgPrice);
        }
    }
}
