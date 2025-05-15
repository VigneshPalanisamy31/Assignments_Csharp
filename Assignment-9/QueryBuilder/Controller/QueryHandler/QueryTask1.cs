using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using LINQ.Model;

namespace LINQ.Controller.QueryHandler
{
    internal class QueryTask1
    {
        /// <summary>
        /// Function to display electronics with price greater than 500$ .
        /// </summary>
        /// <param name="products"></param>
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAverage Price = "+avgPrice);
            Console.ResetColor();
        }
    }
}
