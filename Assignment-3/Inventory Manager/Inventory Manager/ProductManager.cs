using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Inventory_Management
{
    internal class ProductManager
    {
        List<Product> Products = new List<Product>();
        InputHandler inputHandler = new InputHandler();
        public void AddNewProduct()
        {
            Console.WriteLine("--------Adding New Product-------");
            Console.WriteLine("(Press -1 to exit)");
            Product product = inputHandler.GetProductDetails(Products);
            if (product==null)
            {
                Console.WriteLine("Cancelling...");
                return;
            }
            Products.Add(product);
            Products = Products.OrderBy(p => p.ProductID).ToList();
            Console.WriteLine("Product added to inventory successfully....");
        }

        /// <summary>
        /// Function to search a product in the inventory
        /// </summary>
        /// <returns>an objject of matched product</returns>
        public Product SearchProduct()
        {
            if (!Validator.isEmpty(Products))
            {
                Console.WriteLine("Enter the name or id of the product :(press -1 to exit)");
                string key = Console.ReadLine();
                if(key.Equals("-1"))
                {
                    Console.WriteLine("Cancelling...");
                    return null;
                }
                if (!int.TryParse(key, out int search))
                {
                    foreach (Product p in Products)
                    {
                        if (p.ProductName.Equals(key,StringComparison.OrdinalIgnoreCase))
                        {
                            ViewProduct(p);
                            return p;
                        }

                    }
                }
                else
                {
                    foreach (Product p in Products)
                    {
                        if (p.ProductID == search)
                        {
                            ViewProduct(p);
                            return p;
                        }
                    }
                }
                Console.WriteLine("No matching results....");
            }
            return null;
        }
        /// <summary>
        /// Function to edit details of a product in the inventory
        /// </summary>
        public void EditProduct()
        {
            if (!Validator.isEmpty(Products))
            {
                Product toEdit = SearchProduct();
                string exit = "y";
                if (toEdit != null)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("--------Editing Product-------");
                        ViewProduct(toEdit);
                        Console.WriteLine("Choose the field to edit: ");
                        Console.WriteLine("1.ID\n2.Name\n3.Price\n4.Quantity in stock\n5.Exit");
                        int choice = Validator.GetValidNumber("your choice :");
                        switch (choice)
                        {
                            case 1:
                                toEdit.ProductID  = Validator.IsIdAvailable(Validator.GetValidNumber("new productid :"), Products);
                                break;
                            case 2:
                                toEdit.ProductName = Validator.IsNameAvailable(Validator.GetValidName("new product name :"), Products);
                                break;
                            case 3:
                                toEdit.Price = Validator.GetValidPrice();
                                break;
                            case 4:
                                toEdit.QuantityInStock = Validator.GetValidNumber("the new stock quantity :");
                                break;
                            case 5:
                                exit = "n";
                                break;
                            default: Console.WriteLine("Please enter a valid choice"); break;
                        }
                        if (exit.Equals("y"))
                        {
                            Console.WriteLine("Product details edited successfully..");
                            Console.WriteLine("Do you wish to continue editing?");
                            exit = Validator.GetValidName("[y/n]");
                        }
                        Products = Products.OrderBy(p => p.ProductID).ToList();
                    } while (exit != "n");

                }
            }

        }
        public void ViewProducts()
        {
            var productTable = new ConsoleTable("ProductId", "Product Name", "Price", "Quantity");
            foreach (Product product in Products)
            {
                productTable.AddRow(product.ProductID, product.ProductName, product.Price, product.QuantityInStock);
            }
            productTable.Write(Format.Alternative);
        }

        /// <summary>
        /// function to view the product details
        /// </summary>
        /// <param name="toView"></param>
        public void ViewProduct(Product toView)
        {
            Console.WriteLine("--------Product Details---------");
            Console.WriteLine($"Product Id : {toView.ProductID}");
            Console.WriteLine($"Product Name : {toView.ProductName}");
            Console.WriteLine($"Price : {toView.Price}");
            Console.WriteLine($"Quantity in stock : {toView.QuantityInStock}");
        }

        /// <summary>
        /// Function to delete a product from inventory
        /// </summary>
        public void DeleteProduct()
        {
            Console.WriteLine("--------Deleting Product-------");
            if (!Validator.isEmpty(Products))
            {
                Product toDelete = SearchProduct();
                if (toDelete != null)
                {
                    string choice;

                    do
                    {
                        Console.WriteLine("Do you wish to delete this product from inventory ?");
                        choice = Validator.GetValidName("[y/n]");
                        if (choice.Equals("y") || choice.Equals("Y"))
                        {
                            Console.WriteLine("Product deleted from inventory successfully");
                            Products.Remove(toDelete);
                        }
                        else if (choice.Equals("n") || choice.Equals("N"))
                        {
                            Console.WriteLine("Cancelling delete....");
                        }
                    } while (!choice.Equals("y") && !choice.Equals("Y")&& !choice.Equals("N")&&!choice.Equals("n"));
                }
            }
        }
    }
}
