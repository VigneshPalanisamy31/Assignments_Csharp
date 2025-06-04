using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;

namespace LINQ.Controller.QueryHandler
{
    internal class QueryTask5
    {
        /// <summary>
        /// Function to handle all querying tasks (filter,sort,join)
        /// </summary>
        /// <param name="products"></param>
        /// <param name="suppliers"></param>
        public static void QueryBuilderFunctions(List<Product> products,List<Supplier>suppliers)
        {
            var resultBuilder = new QueryBuilder<Product>(products);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Building queries....");
            Console.ResetColor();
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1.Filter Conditions\n2.Sort Conditions\n3.Join Suppliers\n4.Execute");
                Console.ResetColor();
                int outerChoice = Validator.GetValidNumber("choice :");
                switch (outerChoice)
                {
                    case 1:
                        bool exitFilter = false;
                        while (!exitFilter)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n1.Starts With(Product Name)\n2.Ends With(Product Name)\n3.Greater Than or Equal To(price)\n4.Less Than Or Equal To(price)\n5.Exit\n");
                            Console.ResetColor();
                            int filterChoice = Validator.GetValidNumber("choice for filtering:");
                            switch (filterChoice)
                            {
                                case 1:
                                    string startsWith = Validator.GetValidName("start string for filtering products :");
                                    resultBuilder.Filter(p => p.ProductName.StartsWith(startsWith,StringComparison.OrdinalIgnoreCase));
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Filter Added Successfully");
                                    Console.ResetColor();
                                    break;

                                case 2:
                                    string endsWith = Validator.GetValidName("end string for filtering products :");
                                    resultBuilder.Filter(p => p.ProductName.EndsWith(endsWith,StringComparison.OrdinalIgnoreCase));
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Filter Added Successfully");
                                    Console.ResetColor();
                                    break;
                                case 3:
                                    double greaterThanAmt = Validator.GetValidPrice();
                                    resultBuilder.Filter(p => p.Price >= greaterThanAmt);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Filter Added Successfully");
                                    Console.ResetColor();
                                    break;
                                case 4:
                                    double lessThanAmt = Validator.GetValidPrice();
                                    resultBuilder.Filter(p => p.Price <= lessThanAmt);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Filter Added Successfully");
                                    Console.ResetColor();
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Exiting Filters....");
                                    Console.ResetColor();
                                    exitFilter = true;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please enter a valid choice");
                                    Console.ResetColor();
                                    break;

                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        break;

                    case 2:
                        Console.WriteLine("\n1.Sort By Price\n2.Sort By Product Name");
                        int sortChoice = Validator.GetValidNumber("choice for sorting :");
                        if (sortChoice == 1||sortChoice==2)
                        {
                           
                            if (sortChoice == 2)
                                resultBuilder.SortBy(p => p.ProductName);
                            resultBuilder.SortBy(p => p.Price);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Filter Added Successfully");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry Invalid Choice");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                       
                        var result=resultBuilder.Execute();
                        var joinedResult=result.Join(
                              suppliers,
                              p => p.ProductID,
                              s => s.ProductID,
                              (p, s) => new { p.ProductName, p.Price, p.Category, s.SupplierName }

                        );
                        var joinedtable = new ConsoleTable("Product Name", "Price", "Category","Supplier Name");
                        if (joinedResult.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nJoined Suppliers Successfully");
                            Console.ResetColor();
                            foreach (var product in joinedResult)
                            {
                                joinedtable.AddRow(product.ProductName, product.Price, product.Category, product.SupplierName);
                            }
                            joinedtable.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNo matching products...");
                            Console.ResetColor();
                        }
                        exit = true;

                        break;

                    case 4:
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("Executing all added queries..... ");
                        Console.ResetColor();
                        result=resultBuilder.Execute();
                        var table = new ConsoleTable("Product Name", "Price", "Category");
                        if (result.Any())
                        {
                            foreach (var product in result)
                            {
                                table.AddRow(product.ProductName, product.Price, product.Category);
                            }
                            table.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No matching products...");
                            Console.ResetColor();
                        }
                            exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid choice");
                        Console.ResetColor();
                        break;
                }

            }

        }
    }
}
