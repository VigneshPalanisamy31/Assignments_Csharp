using ConsoleTables;
using LINQ.Model;
using LINQ.Utilities;
namespace LINQ.Controller.ProductHandler
{
    internal class ProductManager
    {
        private List<Product> _products;
        private List<Supplier> _suppliers;
        private ProductInputHandler inputHandler;
        public ProductManager(List<Product> products, List<Supplier> suppliers)
        {
            _products = products;
            _suppliers = suppliers;
            inputHandler = new ProductInputHandler();
        }

        /// <summary>
        /// Function to add new products
        /// </summary>
        public void AddNewProduct()
        {
            Console.WriteLine("--------Adding New Product-------");
            Product? product = inputHandler.GetProductDetails(_products);
            _products.Add(product);
            _suppliers.Add(new Supplier(_suppliers.Count + 1, $"Supplier_{product.ProductID}", product.ProductID));
            _products = _products.OrderBy(p => p.ProductID).ToList();
            Helper.WriteInColor("Product added to inventory successfully....", ConsoleColor.Green);
        }

        /// <summary>
        /// Function to search a product in the inventory
        /// </summary>
        /// <returns>an object of matched product</returns>
        public Product? SearchProduct()
        {
            if (!Validator.isEmpty(_products))
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
                    foreach (Product product in _products)
                    {
                        if (product.ProductName.Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            ViewProduct(product);
                            return product;
                        }
                    }
                }
                else
                {
                    foreach (Product product in _products)
                    {
                        if (product.ProductID == search)
                        {
                            ViewProduct(product);
                            return product;
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
            if (!Validator.isEmpty(_products))
            {
                ViewProducts();
                Product productToEdit = SearchProduct();
                string canExit = "y";
                if (productToEdit != null)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("--------Editing Product-------");
                        ViewProduct(productToEdit);
                        Console.WriteLine("Choose the field to edit: ");
                        Helper.WriteInColor("1.ID\n2.Name\n3.Price\n4.Category\n5.Exit", ConsoleColor.Yellow);
                        int choice = Helper.GetValidNumber("your choice :");
                        switch (choice)
                        {
                            case 1:
                                Supplier? supplierToEdit = FindSupplier(productToEdit);
                                productToEdit.ProductID = Validator.GetUniqueProductID(Helper.GetValidNumber("new product_id :"), _products);
                                supplierToEdit.SupplierID = productToEdit.ProductID;
                                supplierToEdit.SupplierName = $"Supplier_{productToEdit.ProductID}";
                                supplierToEdit.ProductID = productToEdit.ProductID;

                                break;
                            case 2:
                                productToEdit.ProductName = Validator.GetUniqueProductName(Helper.GetValidName("new product name :"), _products);
                                break;
                            case 3:
                                productToEdit.Price = Helper.GetValidPrice();
                                break;
                            case 4:
                                productToEdit.Category = Helper.GetValidName("the new category :");
                                break;
                            case 5:
                                canExit = "n";
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                break;
                        }
                        if (canExit.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Product details edited successfully..");
                            Console.WriteLine("Do you wish to continue editing?");
                            canExit = Helper.GetValidName("[y/n]");
                        }
                        _products = _products.OrderBy(p => p.ProductID).ToList();
                    } while (!canExit.Equals("n", StringComparison.OrdinalIgnoreCase));
                }
            }
        }

        /// <summary>
        /// Function to view all products in inventory
        /// </summary>
        public void ViewProducts()
        {
            ConsoleTable productTable = new("ProductId", "Product Name", "Price", "Category");
            foreach (Product product in _products)
            {
                productTable.AddRow(product.ProductID, product.ProductName, product.Price, product.Category);
            }
            productTable.Write(Format.Alternative);
        }

        /// <summary>
        /// Displays products along with their suppliers.
        /// </summary>
        public void DisplayProductWithSuppliers()
        {
            var productWithSuppliers = from product in _products
                                       join supplier in _suppliers
                                       on product.ProductID equals supplier.ProductID
                                       select new
                                       {
                                           product.ProductID,
                                           product.ProductName,
                                           product.Price,
                                           product.Category,
                                           supplier.SupplierID,
                                           supplier.SupplierName
                                       };
            ConsoleTable inventoryTable = new("ProductId", "Product Name", "Product Price", "Product Category", "SupplierId", "Supplier Name");
            foreach (var productEntry in productWithSuppliers)
            {
                inventoryTable.AddRow(productEntry.ProductID, productEntry.ProductName, productEntry.Price, productEntry.Category, productEntry.SupplierID, productEntry.SupplierName);
            }
            inventoryTable.Write(Format.Alternative);
        }

        /// <summary>
        /// Function to view the product details
        /// </summary>
        /// <param name="productToView">Product to be viewed</param>
        public void ViewProduct(Product productToView)
        {
            Console.WriteLine("--------Product Details---------");
            Console.WriteLine($"Product Id : {productToView.ProductID}");
            Console.WriteLine($"Product Name : {productToView.ProductName}");
            Console.WriteLine($"Price : {productToView.Price}");
            Console.WriteLine($"Category : {productToView.Category}");
        }

        /// <summary>
        /// Function to delete a product from inventory
        /// </summary>
        public void DeleteProduct()
        {
            Console.WriteLine("--------Deleting Product-------");
            if (!Validator.isEmpty(_products))
            {
                ViewProducts();
                Product? productToDelete = SearchProduct();
                if (productToDelete != null)
                {
                    string choice;
                    do
                    {
                        Console.WriteLine("Do you wish to delete this product from inventory ?");
                        choice = Helper.GetValidName("[y/n]");
                        if (choice.Equals("y") || choice.Equals("Y"))
                        {
                            Console.WriteLine("Product deleted from inventory successfully");
                            _products.Remove(productToDelete);
                            _suppliers.Remove(FindSupplier(productToDelete));
                        }
                        else if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Canceling delete....");
                        }
                    } while (!choice.Equals("y", StringComparison.OrdinalIgnoreCase) && !choice.Equals("N", StringComparison.OrdinalIgnoreCase));
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
            foreach (Supplier supplier in _suppliers)
            {
                if (supplier.ProductID == product.ProductID)
                {
                    return supplier;
                }
            }
            return null;
        }
    }
}
