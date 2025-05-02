# Assignments_Csharp Assignment-5
   A simple Finance Tracker application that allows you to add, edit, view and delete financial transactions. 
Built as a console application using c#.

Features: 
 - Add new income/expense transaction with details like  date ,source/category name, amount. 
 - Edit income/expense transaction as per user needs.
 - Delete income/expense transaction as per user needs.
 - View income/expense transactions as per user needs.
 - View financial summary of all transactions made by a particular user. 


 File Structure
  Finance Tracker/
     ExistingUser.cs            #class with display and function calls for existing users.
     Expence.cs                 #class that interacts with user and calls expense tracking functionalities.
     FinanceTransactions.cs     #class that handles all mentioned functionalities.(New User)
     FinanceTracker.csproj      #project file defining build settings,dependencies etc..
     Income.cs                  #class that interacts with user and calls income tracking functionalities.
     NewUser.cs                 #class with display and function calls for new users.
     Transaction.cs             #a template for transaction with required fields and properties.
     TrackerUI.cs               #class that interacts with user and calls functionalitites accordingly.
     UserInteract.cs            #class with helper functions to handle user entered inputs.
     Validation.cs              #class with validation functions to avoid duplicate entries, validate user inputs and ensure integrity.