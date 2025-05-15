using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using LINQ.Model;
namespace LINQ.Controller.QueryHandler
{
    internal class QueryTask2
    {
        /// <summary>
        /// Function to display products grouped by category along with most expensive product of each category .
        /// </summary>
        /// <param name="products"></param>
        /// <param name="suppliers"></param>
        public static void Execute1(List<Product> products,List<Supplier>suppliers)
        {
            var productGroup = products.GroupBy(p => p.Category)
                .Select(grp => new
                { 
                    Category=grp.Key,
                    Count=grp.Count(),
                    MostExpensiveProduct=grp.OrderByDescending(p=>p.Price).FirstOrDefault()
                });
           
            var table = new ConsoleTable("Category", "Count", "MostExpensive Product", "Highest Price");
            foreach(var group in productGroup)
            {
                table.AddRow(group.Category, group.Count,group.MostExpensiveProduct.ProductName,group.MostExpensiveProduct.Price);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Products grouped based on categories along with the most expensive product");
            Console.ResetColor();
            table.Write(Format.Alternative);

        }
        public static void Execute2(List<Product> products, List<Supplier> suppliers)
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
            var table = new ConsoleTable("ProductId", "Product Name", "Supplier Name");
            foreach (var product in productSuppliers)
                table.AddRow(product.ProductID, product.ProductName, product.SupplierName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nProducts along with their suppliers");
            Console.ResetColor();
            table.Write(Format.Alternative);


        }
    }
}
