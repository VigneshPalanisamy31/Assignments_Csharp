using ConsoleTables;
using LINQ.Controller.QueryHandler;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.View
{
    internal class QueryBuilderMenu
    {
        /// <summary>
        /// Function to handle all querying tasks (filter,sort,join)
        /// </summary>
        /// <param name="products">List of prodducts</param>
        /// <param name="suppliers">List of suppliers</param>
        public static void DisplayQueryMenu(List<Product> products,List<Supplier>suppliers)
        {
            QueryBuilder<Product> resultBuilder = new(products);
            Console.Clear();
            Helper.WriteInColor("Building queries....", ConsoleColor.Green);
            bool canExit = false;
            bool isJoinApplied = false;
            while (!canExit)
            {
                Helper.WriteInColor("\n1.Filter Conditions\n2.Sort Conditions\n3.Join Suppliers\n4.Execute", ConsoleColor.Yellow);
                int choice = Helper.GetValidNumber("choice :");
                switch (choice)
                {
                    case 1:
                        bool exitFilter = false;
                        while (!exitFilter)
                        {
                            Helper.WriteInColor("\n1.Starts With(Product Name)\n2.Ends With(Product Name)\n3.Greater Than or Equal To(price)\n4.Less Than Or Equal To(price)\n5.Exit\n", ConsoleColor.Yellow);
                            int filterChoice = Helper.GetValidNumber("choice for filtering:");
                            switch (filterChoice)
                            {
                                case 1:
                                    string startsWith = Helper.GetValidName("start string for filtering products :");
                                    resultBuilder.Filter(p => p.ProductName.StartsWith(startsWith,StringComparison.OrdinalIgnoreCase));
                                    Helper.WriteInColor("Filter Added Successfully", ConsoleColor.Green);
                                    break;

                                case 2:
                                    string endsWith = Helper.GetValidName("end string for filtering products :");
                                    resultBuilder.Filter(p => p.ProductName.EndsWith(endsWith,StringComparison.OrdinalIgnoreCase));
                                    Helper.WriteInColor("Filter Added Successfully", ConsoleColor.Green);
                                    break;

                                case 3:
                                    decimal minimumAmount = Helper.GetValidPrice();
                                    resultBuilder.Filter(p => p.Price >= minimumAmount);
                                    Helper.WriteInColor("Filter Added Successfully", ConsoleColor.Green);
                                    break;

                                case 4:
                                    decimal maximumAmount = Helper.GetValidPrice();
                                    resultBuilder.Filter(p => p.Price <= maximumAmount);
                                    Helper.WriteInColor("Filter Added Successfully", ConsoleColor.Green);
                                    break;

                                case 5:
                                    Helper.WriteInColor("Exiting Filters....", ConsoleColor.Red);
                                    exitFilter = true;
                                    break;

                                default:
                                    Helper.WriteInColor("Please enter a valid choice", ConsoleColor.Red);
                                    break;

                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n1.Sort By Price\n2.Sort By Product Name");
                        int sortChoice = Helper.GetValidNumber("choice for sorting :");
                        if (sortChoice == 1||sortChoice==2)
                        {
                           
                            if (sortChoice == 2)
                                resultBuilder.SortBy(p => p.ProductName);
                            resultBuilder.SortBy(p => p.Price);
                            Helper.WriteInColor("Filter Added Successfully", ConsoleColor.Green);
                        }
                        else
                            Helper.WriteInColor("Sorry Invalid Choice", ConsoleColor.Red);
                        break;

                    case 3:
                        Helper.WriteInColor("Join Added Successfully", ConsoleColor.Green);
                        isJoinApplied = true;
                        break;

                    case 4:
                        Helper.WriteInColor("Executing all added queries..... ", ConsoleColor.Green);
                        var result=resultBuilder.Execute();
                        if(!result.Any())
                        {
                            Helper.WriteInColor("No matching products...", ConsoleColor.Red);
                        }
                        else if (isJoinApplied == true)
                        {
                            var joinedResult = result.Join(
                                  suppliers,
                                  p => p.ProductID,
                                  s => s.ProductID,
                                  (p, s) => new { p.ProductName, p.Price, p.Category, s.SupplierName }

                            );
                            ConsoleTable joinedtable = new("Product Name", "Price", "Category", "Supplier Name");
                            if (joinedResult.Any())
                            {
                                foreach (var product in joinedResult)
                                {
                                    joinedtable.AddRow(product.ProductName, product.Price, product.Category, product.SupplierName);
                                }
                                joinedtable.Write(Format.Alternative);
                            }
                        }
                        else
                        {
                            ConsoleTable table = new("Product Name", "Price", "Category");
                            if (result.Any())
                            {
                                foreach (Product product in result)
                                {
                                    table.AddRow(product.ProductName, product.Price, product.Category);
                                }
                                table.Write(Format.Alternative);
                            }
                        }
                        canExit = true;
                        break;

                    default:
                        Helper.WriteInColor("Please enter a valid choice", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
