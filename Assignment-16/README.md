# Assignment-16 Events, Delegates, Lambda, Anonymous Methods  
Involves the understanding of working with Events, Delegates, Lambda, Anonymous Methods in C#.
### Task 1: Understanding and Implementing Events and Delegates in C#
 Implement a program that uses events and delegates to notify the user when an action is performed.  
 1. Define a delegate
 2. Define an event
 3. Subscribe to the event with a method that prints message to the console.
 4. Trigger the event.

### Task 2: Understanding the Use of Dynamic and Var Keywords and Their Differences 
  Implemented a program to demonstrate the differences between var and dynamic.
  1. Use var to declare a variable and assign it a value
  2. Use dynamic to declare a variable and assign it a value
  3. Attempt to change the variables type post declarartion and observe changes 
### Task 3: Implementing Anonymous Methods
  Implemented a program that that uses an anonymous method to sort an array of integers in ascending order. 
  1. Declare an array of integers.
  2. Use the Array.Sort the method and provide an anonymous method for comparison. 
  3. Print sorted array to the console.

### Task 4: Understanding and Using Lambda Expressions and Statements
  Implemented a program that uses lambda expressions and statements to filter and modify a collection of data. .
  1. Declare a list of integers. 
  2. Use a lambda expression with the Where LINQ method to filter out even numbers. 
  3. Use a lambda statement with the Select LINQ method to square the filtered numbers. 
  4. Print the resulting collection to the console. 

 ### Task 5: Advanced Use of Delegates for Sorting
   Implemented a program that demonstrates the use of delegates for complex sorting operations.
  1. Create a Product and declare a list of product objects.
  2. Create a delegate SortDelegate 
  3. Implement three methods SortByName, SortByCategory, and SortByPrice that take two Product objects and return an integer
  4. Create instances of SortDelegate for each of the sorting methods
  5. Implement a method SortAndDisplay that takes a SortDelegate and a list of Product objects. 

 ### Task 6: Implementing and Manipulating Records in C# 
    Implemented a program that demonstrates the use and benefits of records. 
  1. Define a record Book with properties Title, Author, and ISBN.
  2. Declare a few Book records and display their details in the console.
  3. Create two Book records with the same property values. Compare them using the == operator and print the result. 
  4. Create a new record based on an existing one ,change one or more properties, observe changes(immutability).
  5. Implement a method DisplayBook that takes a Book record and uses deconstruction to print its properties.

 ### Task 7: Implementing and Manipulating Records in C# 
    Implemented a program that demonstrates the use and benefits of records. 
  1. Define a base class Shape with properties common to all shapes. 
  2. Define subclasses Circle, Rectangle, and Triangle, each with properties specific to that shape. 
  3. Implement a method CalculateArea in each subclass to calculate and return the area of the shape.  
  4. Implement a method DisplayShapeDetails that takes a Shape object and uses type patterns in a switch statement to match the shape's type.
