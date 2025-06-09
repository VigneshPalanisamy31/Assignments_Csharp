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
                products.Add(new Product(1, "Laptop", 70000, "Electronics"));
                products.Add(new Product(2, "AC", 20000, "Electronics"));
                products.Add(new Product(3, "BookA", 2000, "books"));
                products.Add(new Product(4, "BookB", 3000, "books"));
                products.Add(new Product(5, "T-Shirt", 1000, "Clothing"));
                products.Add(new Product(6, "Jeans", 2000, "Clothing"));
                products.Add(new Product(7, "Sofa", 25000, "Furniture"));
                products.Add(new Product(8, "Dining Table", 18000, "Furniture"));
                products.Add(new Product(9, "Rice", 800, "Groceries"));
                products.Add(new Product(10, "Cooking Oil", 1200, "Groceries"));

                List<Supplier> suppliers = new List<Supplier>();
                suppliers.Add(new Supplier(1, "Supplier_1", 1));
                suppliers.Add(new Supplier(2, "Supplier_2", 2));
                suppliers.Add(new Supplier(3, "Supplier_3", 3));
                suppliers.Add(new Supplier(4, "Supplier_4", 4));
                suppliers.Add(new Supplier(5, "Supplier_5", 5));
                suppliers.Add(new Supplier(6, "Supplier_6", 6));
                suppliers.Add(new Supplier(7, "Supplier_7", 7));
                suppliers.Add(new Supplier(8, "Supplier_8", 8));
                suppliers.Add(new Supplier(9, "Supplier_9", 9));
                suppliers.Add(new Supplier(10, "Supplier_10", 10));
                bool isExit = false;
                while (!isExit)
                {
                    Helper.WriteInYellow("===========Inventory Querying Console Application==========" + "\n1.Product Manager\n2.QueryHandler\n3.Exit");
                    int choice = Validator.GetValidNumber(" choice:");
                    switch (choice)
                    {
                        case 1:
                            ProductManagerMenu.DisplayProductManagerMenu(products, suppliers);
                            break;

                        case 2:
                            QueryMenu.QueryTasks(products, suppliers);
                            break;

                        case 3:
                            Helper.WriteInRed("Exiting......");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            isExit = true;
                            break;

                        default:
                            Helper.WriteInRed("\nPlease enter a valid choice from given choices");
                            break;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Execution interrupted!!!\nException:{e.Message}");
            }
        }
    }
}
