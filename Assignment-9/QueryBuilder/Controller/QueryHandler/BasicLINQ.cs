using System;
using System.Collections.Generic;
using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;

namespace LINQ.Controller.QueryHandler
{
    internal class BasicLINQ
    {
        /// <summary>
        /// Function to display electronics with price greater than 500$ .
        /// </summary>
        /// <param name="products">List of products</param>
        public static void FilterProductsWithPriceGreaterThan500(List<Product> products)
        {           
            IEnumerable<Product> result = products.Where(product => product.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase)&&product.Price>500)
                                                  .OrderByDescending(product=>product.Price);
            decimal avgPrice=result.Average(product=>product.Price);
            Helper.WriteInYellow("Electronics with price greater than 500$\n\n");
            ConsoleTable table = new("Product Name","Price");
            foreach (Product product in result)
            {
                table.AddRow(product.ProductName,product.Price);
            }
            table.Write(Format.Alternative);
            Console.WriteLine("\nAverage Price = "+avgPrice);
        }
    }
}
