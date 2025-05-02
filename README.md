# Assignments_Csharp Assignment-4
   A simple Finance Tracker application that allows you to add, edit, view and delete financial transactions. 
Built as a console application using c#.

Features: (New User)
 - Add new transaction with details like  date ,source/category name, amount. 


 File Structure
  Finance Tracker/
     Transaction.cs             #a template for transaction with required fields and properties.
     FinanceTransactions.cs     #class that handles all mentioned functionalities.(New User)
     FinanceTracker.csproj      #project file defining build settings,dependencies etc..
     TrackerUI.cs               #class that interects with user and calls functionalitites accordingly.
     Validation.cs              #class with validation functions to avoid duplicate entries, validate user inputs and ensure integrity.
     UserInteract.cs            #class with helper functions to handle user entered inputs.
     NewUser.cs                 #class with display and function calls for new users.