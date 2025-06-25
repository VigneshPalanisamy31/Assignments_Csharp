using LINQ.Controller.ProductHandler;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.View
{
    internal class ProductManagerMenu
    {
        /// <summary>
        /// Displays Product Manager Menu
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public static void DisplayProductManagerMenu(List<Product> products,List<Supplier> suppliers)
        {
            bool isExit = false;
            while(!isExit)
            {
                ProductManager inventory = new ProductManager(products,suppliers);
                Helper.WriteInYellow("1.Add Product");
                Helper.WriteInYellow("2.Edit Product");
                Helper.WriteInYellow("3.Search Product");
                Helper.WriteInYellow("4.Delete Product");
                Helper.WriteInYellow("5.View Inventory");
                Helper.WriteInYellow("6.Exit");
                int choice = Validator.GetValidNumber("your choice :");
                switch (choice)
                {
                    case 1:
                        inventory.AddNewProduct();
                        break;

                    case 2:
                        inventory.EditProduct();
                        break;

                    case 3:
                        inventory.SearchProduct();
                        break;

                    case 4:
                        inventory.DeleteProduct();
                        break;

                    case 5:
                        inventory.ViewProducts(true);
                        break;

                    case 6:
                        isExit = true;
                        break;

                    default:
                        Helper.WriteInRed("Please enter a valid input");
                        break;
                }
                Console.WriteLine("\n\nPress any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
