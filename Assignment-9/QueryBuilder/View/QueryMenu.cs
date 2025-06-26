using LINQ.Controller.QueryHandler;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.View
{
    internal class QueryMenu
    {
        /// <summary>
        /// Displays the Query Tasks.
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public static void QueryTasks(List<Product> products, List<Supplier> suppliers)
        {
            bool canExit = false;
            while (!canExit)
            {
                Console.Clear();
                Helper.WriteInYellow("\nQuerying Tasks");
                Helper.WriteInYellow("1.Electronics greater than $500");
                Helper.WriteInYellow("2.Product groups along with most expensive product");
                Helper.WriteInYellow("3.Products along with suppliers");
                Helper.WriteInYellow("4.Second Highest element in an array and pairs summing up to target");
                Helper.WriteInYellow("5.All books sorted by price");
                Helper.WriteInYellow("6.QueryBuilder");
                Helper.WriteInYellow("7.Exit");
                int choice = Helper.GetValidNumber("your choice :");
                QueryManager queryManager = new QueryManager();
                switch (choice)
                {
                    case 1:
                        queryManager.FilterProductsWithGreaterPrice(products,"Electronics",500);
                        break;

                    case 2:
                        queryManager.GroupProductsByCategory(products, suppliers);
                        break;

                    case 3:
                        queryManager.JoinProductsWithSuppliers(products, suppliers);
                        break;

                    case 4:
                        queryManager.DisplayPairsSummingUptoTarget();
                        break;

                    case 5:
                        queryManager.SortProductsOfCategoryByKey(products,"Books",p=>p.Price);
                        break;

                    case 6:
                        QueryBuilderMenu.DisplayQueryMenu(products, suppliers);
                        break;

                    case 7:
                        Console.WriteLine("Exiting....");
                        canExit = true;
                        break;

                    default:
                        Helper.WriteInRed("Please enter a valid choice");
                        break;
                }
                Console.WriteLine("\nPress any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
