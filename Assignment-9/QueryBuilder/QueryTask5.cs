using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class QueryTask5
    {
        public static void ProductsGreaterThan50000SortByPrice(List<Product>products,List<Supplier>suppliers)
        {
            var resultBuilder = new QueryBuilder<Product>(products)
                        .Filter(p => p.Price > 50000)
                        .SortBy(p => p.Price)
                        .Filter(p => p.Category.Equals("Electronics"))
                        .Join(
                              suppliers,
                              p => p.ProductID,
                              s => s.ProductID,
                              (p, s) => new { p.ProductName, p.Price, p.Category, s.SupplierName }

                        );
                        var result=resultBuilder.Execute();
            Console.WriteLine("Executing task 5 ");
            foreach(var product in result)
            {
                Console.WriteLine($"{product.ProductName}  -   {product.Price} - {product.Category} - {product.SupplierName}");
            }
        }
    }
}
