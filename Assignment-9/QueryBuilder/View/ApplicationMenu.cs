using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.View
{
    internal class ApplicationMenu
    {
        public static void Main(string[] args)
        {
            try
            {
                List<Product> products = new List<Product>();
                products.Add(new Product(1000, "Laptop", 70000, "Electronics"));
                products.Add(new Product(2000, "AC", 20000, "Electronics"));
                products.Add(new Product(3000, "BookA", 2000, "books"));
                products.Add(new Product(4000, "BookB", 3000, "books"));
                products.Add(new Product(5000, "T-Shirt", 1000, "Clothing"));
                products.Add(new Product(6000, "Jeans", 2000, "Clothing"));
                products.Add(new Product(7000, "Sofa", 25000, "Furniture"));
                products.Add(new Product(8000, "Dining Table", 18000, "Furniture"));
                products.Add(new Product(9000, "Rice", 800, "Groceries"));
                products.Add(new Product(10000, "Cooking Oil", 1200, "Groceries"));

                List<Supplier> suppliers = new List<Supplier>();
                suppliers.Add(new Supplier(1, "Supplier_1", 1000));
                suppliers.Add(new Supplier(2, "Supplier_2", 2000));
                suppliers.Add(new Supplier(3, "Supplier_3", 3000));
                suppliers.Add(new Supplier(4, "Supplier_4", 4000));
                suppliers.Add(new Supplier(5, "Supplier_5", 5000));
                suppliers.Add(new Supplier(6, "Supplier_6", 6000));
                suppliers.Add(new Supplier(7, "Supplier_7", 7000));
                suppliers.Add(new Supplier(8, "Supplier_8", 8000));
                suppliers.Add(new Supplier(9, "Supplier_9", 9000));
                suppliers.Add(new Supplier(10, "Supplier_10", 10000));
                bool canExit = false;
                while (!canExit)
                {
                    Helper.WriteInColor("===========Inventory Querying Console Application==========" + "\n1.Product Manager\n2.QueryHandler\n3.Exit",ConsoleColor.Yellow);
                    int choice = Helper.GetValidNumber(" choice:");
                    switch (choice)
                    {
                        case 1:
                            ProductManagerMenu productMenu = new ProductManagerMenu();
                                productMenu.DisplayProductManagerMenu(products, suppliers);
                            break;

                        case 2:
                            QueryMenu.QueryTasks(products, suppliers);
                            break;

                        case 3:
                            Helper.WriteInColor("Exiting......", ConsoleColor.Red);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            canExit = true;
                            break;

                        default:
                            Helper.WriteInColor("\nPlease enter a valid choice from given choices", ConsoleColor.Red);
                            break;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Execution interrupted!!!\nException:{e.Message}");
                Console.ReadKey();
            }
        }
    }
}
