using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.Controller.QueryHandler
{
    internal class ComplexLINQ
    {
        /// <summary>
        /// Function to display products grouped by category along with most expensive product of each category .
        /// </summary>
        /// <param name="products"></param>
        /// <param name="suppliers"></param>
        public static void GroupProductsByCategory(List<Product> products,List<Supplier>suppliers)
        {
            var productGroup = products.GroupBy(p => p.Category)
                .Select(grp => new
                { 
                    Category=grp.Key,
                    Count=grp.Count(),
                    MostExpensiveProduct=grp.OrderByDescending(p=>p.Price).FirstOrDefault()
                });          
            ConsoleTable table = new("Category", "Count", "MostExpensive Product", "Highest Price");
            foreach(var group in productGroup)
            {
                table.AddRow(group.Category, group.Count,group.MostExpensiveProduct.ProductName,group.MostExpensiveProduct.Price);
            }
            Helper.WriteInYellow("Products grouped based on categories along with the most expensive product");
            table.Write(Format.Alternative);
        }
        /// <summary>
        /// Function to join and display products with suppliers 
        /// </summary>
        /// <param name="products"></param>
        /// <param name="suppliers"></param>
        public static void JoinProductsWithSuppliers(List<Product> products, List<Supplier> suppliers)
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
                table.AddRow(product.ProductID, product.ProductName, product.SupplierName);;
            Helper.WriteInYellow("\nProducts along with their suppliers");
            table.Write(Format.Alternative);
        }
    }
}
