# Assignments_Csharp Assignment-3
A simple Inventory Manager application that allows you to add, edit, view, search and delete products. 
Built as a console application using c#.

Features:
 - Add new products with details like productId, product name, price and any quantity in stock. 
 - Edit details of existing products.
 - View all products in the inventory.
 - Search products with name or id.
 - Delete a product from inventory.

 File Structure
  Inventory Manager/
     Product.cs                 #a template for product with required fields and properties.
     ProductManager.cs          #class that handles all mentioned functionalities.
     InventoryManager.csproj    #project file defining build settings,dependencies etc..
     UI.cs                      #class that interects with user and calls functionalitites accordingly.
     Validator.cs               #class with validation functions to avoid duplicate entries and ensure integrity.
     InputHandler.cs            #class with helper functions to handle user entered inputs.
       
