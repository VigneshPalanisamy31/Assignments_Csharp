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
        public void DisplayProductManagerMenu(List<Product> products,List<Supplier> suppliers)
        {
            bool canExit = false;
            while(!canExit)
            {
                ProductManager inventory = new ProductManager(products,suppliers);
                Helper.WriteInColor("1.Add Product",ConsoleColor.Yellow);
                Helper.WriteInColor("2.Edit Product",ConsoleColor.Yellow);
                Helper.WriteInColor("3.Search Product",ConsoleColor.Yellow);
                Helper.WriteInColor("4.Delete Product", ConsoleColor.Yellow);
                Helper.WriteInColor("5.View Inventory", ConsoleColor.Yellow);
                Helper.WriteInColor("6.Exit", ConsoleColor.Yellow);
                int choice = Helper.GetValidNumber("your choice :");
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
                        inventory.DisplayProductWithSuppliers();
                        break;

                    case 6:
                        canExit = true;
                        break;

                    default:
                        Helper.WriteInColor("Please enter a valid input", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\n\nPress any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
