# C# Advanced Features - Events, Delegates, Anonymous Methods, Lambda Expressions, Record, Pattern Matching
 
### Task 1 - Understanding and Implementing Events and Delegates in C#
* Created a console application to print a message to the console using events and delegates.
* Defined a delegate named Notify that accepts a string parameter and returns void in the Notifier class.
* Defined an event OnAction in the Notifier class using the Notify delegate.
* In the Main method, created an instance of the Notifier clas, and subscribed to the OnAction event with the method DisplayMessage defined in the Program class.
* Triggered the OnAction event with a string message and observed the console output.
 
### Task 2 - Understanding the Use of 'var' and 'dynamic' Keywords
* Created a console application to demonstrate the difference between the use of 'var' and 'dynamic' keywords.
* Declared a variable with the var keyword and assigned a string value to it. When the value of the variable is changed to an integer, an error occurs, demonstrating that var keyword does not allow changing the type of the variable.
* Declared a variable with the dynamic keyword and assigned a string value to it. When the value of the varibale is changed to a double, no error occurs, demonstrating that dynamic keyword allows changing the type of the varibale.
 
### Task 3 - Implementing Anonymous Methods
* Created a console application to make use of anonymous methods for sorting an array of integers.
* Created an array of integers.
* Defined a delegate that accepts an integer array and returns nothing.
* Created an anonymous method using the defined delegate to sort the integer array.
* Called the anonymous method with an array of integers and printed the array elements after sorting to ensure the working of the anonymous method.
 
### Task 4 - Understanding and Using Lambda Expressions and Statements
* Created a console application to use lambda expressions and statements to filter and modify a collection of data.
* Created a list of integers.
* Used a lambda expression with Where LINQ method to filter out even numbers from the list.
* Used a lambda expression with Select LINQ method to square the odd numbers of the list.
* Displayed the result of the LINQ queries to the console.
 
### Task 5 - Advanced Use of Delegates For Sorting
* Created a console application to use delegates for sorting a list of products.
* Created a Product class with the properties Name, Category, and Price.
* Declared a list of Product objects.
* Created a delegate SortDelegate that takes two Product objects and returns an integer denoting the relative order of the products on sorting.
* Implemented three methods SortByName, SortByCategory, and SortByPrice for comparing the Product objects based on the relevant properties using the CompareTo method.
* In the Main method, created instances of SortDelegate for each of the sorting methods.
* Implemented a method SortAndDsiaply that takes a SortDelegate and the list of Product objects, sorts the list and prints the sortedlist to the console.
* Called the SortAndDisplay method thrice with each of the methods SortByName, SortByCategory and SortByPrice once to sort the products list based on different properties each time.
 
### Task 6 - Implementing and Manipulating Records
* Created a console application to perform manipulation on Record type. 
* Defined a recordBook with the properties Title, Author, and ISBN.
* Created a few instances of Book records and displayed their details inthe console.
* Compared two Book records with the same property values using the == operator.
* Tried to change a property of a Book record which throws an error as records are immutable.
* Created a new Book record using the with keyword and changing the properties of an existing record.
* Implemented a method DisplayBook that uses desconstruction to print the properties of the book.
 
### Task 7 - Implementing Advanced Pattern Matching
* Cretaed a console application to use advanced pattern matching using classes.
* Defined a base class Shape with properties common to all shapes.
* Defined subclasses Circle, Rectangle, and Triangle each with properties specific to the shapes.
* Implemented a method CalculateArea in each subclasses to calculate and return the area of the shape.
* Declared a list of Shape objects in the Main method.
* Implemented a method DisplayShapeDetails that takes a Shape object and uses a switch statement to match the shape type and print the details of the shape.
* Called the DisplayShapeDetails method on each of the shape in the list and printed the result to the console.
 