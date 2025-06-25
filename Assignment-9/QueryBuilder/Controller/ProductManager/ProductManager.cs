using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.Controller.ProductHandler
{
    internal class ProductManager
    {
        List<Product> Products;
        List<Supplier> Suppliers;
        public ProductManager(List<Product>products, List<Supplier> suppliers)
        {
            Products = products;
            Suppliers = suppliers;
        }
        FetchUserData inputHandler = new FetchUserData();
        /// <summary>
        /// Function to add new products
        /// </summary>
        public void AddNewProduct()
        {
            Console.WriteLine("--------Adding New Product-------");
            Console.WriteLine("(Press -1 to exit)");
            Product? product = inputHandler.GetProductDetails(Products);
            if (product == null)
            {
                Console.WriteLine("Canceling...");
                return;
            }
            Products.Add(product);
            Suppliers.Add(new Supplier(Suppliers.Count+1, $"Supplier_{product.ProductID}",product.ProductID));
            Products = Products.OrderBy(p => p.ProductID).ToList();
            Helper.WriteInGreen("Product added to inventory successfully....");
        }

        /// <summary>
        /// Function to search a product in the inventory
        /// </summary>
        /// <returns>an object of matched product</returns>
        public Product? SearchProduct()
        {
            if (!Validator.isEmpty(Products))
            {
                Console.WriteLine("Enter the name or id of the product :(press -1 to exit)");
                string? key = Console.ReadLine();
                if (key.Equals("-1"))
                {
                    Console.WriteLine("Canceling...");
                    return null;
                }
                if (!int.TryParse(key, out int search))
                {
                    foreach (Product p in Products)
                    {
                        if (p.ProductName.Equals(key, StringComparison.OrdinalIgnoreCase))
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
                ViewProducts();
                Product toEdit = SearchProduct();
                string isExit = "y";
                if (toEdit != null)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("--------Editing Product-------");
                        ViewProduct(toEdit);
                        Console.WriteLine("Choose the field to edit: ");
                        Helper.WriteInYellow("1.ID\n2.Name\n3.Price\n4.Category\n5.Exit");
                        int choice = Validator.GetValidNumber("your choice :");
                        switch (choice)
                        {
                            case 1:
                                Supplier? supplierToEdit = FindSupplier(toEdit);
                                toEdit.ProductID = Validator.IsProductIdAvailable(Validator.GetValidNumber("new productid :"), Products);
                                supplierToEdit.SupplierID=toEdit.ProductID;
                                supplierToEdit.SupplierName = $"Supplier_{toEdit.ProductID}";
                                supplierToEdit.ProductID=toEdit.ProductID ;
                                
                                break;
                            case 2:
                                toEdit.ProductName = Validator.IsProductNameAvailable(Validator.GetValidName("new product name :"), Products);
                                break;
                            case 3:
                                toEdit.Price = Validator.GetValidPrice();
                                break;
                            case 4:
                                toEdit.Category = Validator.GetValidName("the new category :");
                                break;
                            case 5:
                                isExit = "n";
                                break;
                            default: Console.WriteLine("Please enter a valid choice"); break;
                        }
                        if (isExit.Equals("y",StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Product details edited successfully..");
                            Console.WriteLine("Do you wish to continue editing?");
                            isExit = Validator.GetValidName("[y/n]");
                        }
                        Products = Products.OrderBy(p => p.ProductID).ToList();
                    } while (!isExit.Equals("n",StringComparison.OrdinalIgnoreCase));
                }
            }
        }
        /// <summary>
        /// Function to view all products in inventory
        /// </summary>
        public void ViewProducts(bool isSupplierRequired=false)
        {
            ConsoleTable productTable = new("ProductId", "Product Name", "Price", "Category");
            foreach (Product product in Products)
            {
                productTable.AddRow(product.ProductID, product.ProductName, product.Price, product.Category);
            }
            productTable.Write(Format.Alternative);
            if (isSupplierRequired == true)
            {
                ConsoleTable supplierTable = new("ProductId", "SupplierId", "Supplier Name");
                foreach (Supplier supplier in Suppliers)
                {
                    supplierTable.AddRow(supplier.ProductID, supplier.SupplierID, supplier.SupplierName);
                }
                supplierTable.Write(Format.Alternative);
            }
        }

        /// <summary>
        /// Function to view the product details
        /// </summary>
        /// <param name="toView"></param>
        public void ViewProduct(Product toView)
        {
            Console.WriteLine("--------Product Details---------");
            Console.WriteLine($"Product Id : {toView.ProductID}");
            Console.WriteLine($"Product Name : {toView.ProductName}");
            Console.WriteLine($"Price : {toView.Price}");
            Console.WriteLine($"Category : {toView.Category}");
        }

        /// <summary>
        /// Function to delete a product from inventory
        /// </summary>
        public void DeleteProduct()
        {
            Console.WriteLine("--------Deleting Product-------");
            if (!Validator.isEmpty(Products))
                ViewProducts();
            {
                Product? toDelete = SearchProduct();
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
                            Suppliers.Remove(FindSupplier(toDelete));
                        }
                        else if (choice.Equals("n") || choice.Equals("N"))
                        {
                            Console.WriteLine("Canceling delete....");
                        }
                    } while (!choice.Equals("y") && !choice.Equals("Y") && !choice.Equals("N") && !choice.Equals("n"));
                }
            }
        }
        /// <summary>
        /// Finds the supplier of the given product
        /// </summary>
        /// <param name="product">Product object whose supplier is to be found</param>
        /// <returns>Supplier of the given product</returns>
        public Supplier? FindSupplier(Product product)
        {
            foreach(Supplier sp in Suppliers)
            {
                if (sp.ProductID == product.ProductID)
                    return sp;
            }
            return null;
        }
    }
}
