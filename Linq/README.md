## Assignment 9 - LINQ
 
### Task 1 - Basic LINQ Queries
1. To select the product name and product price of the category electronics which price greater than 500.
<br>**GetProductByCategoryAndPriceGreaterThan500** :<br>&nbsp; Filter the product based on the category "electronics" with price greater than 500.  
### Task 2 - Complex LINQ Queries
1. To group products by category, count the products and display the most expensive product of each category.<br>
**GroupByCategory** :<br>&nbsp;Group the products based on Category.
2. To perform inner join to match products with their suppliers<br>
**JoinWithProductId** :<br>&nbsp; Perform inner join between product list and supplier list based on the product id.
### Task 3 - LINQ to Objects
1. To find the second largest number in an array<br>
**SecondHighestNumber** :<br>&nbsp; Sort the array in descending order and select the second element from the sorted array.
2. To find the unique pairs of numbers in the array that add up to a specified target.
<br>**UniqueTargetPair** :<br>&nbsp;Iterate the array with x and y combination and  get the pair of numbers which sum is equal to the target.
### Task 4 - Performance Considerations with LINQ
1. To select all the products under the category "Books" and sort them by price.
<br>**GetProductByCategoryAndOrderByDescendingBasedOnPrice** :<br>&nbsp; Filter the products based on the category "Books" and sort them by price in descending order.
2. To optimize the above query
<br> &emsp; Filtered the products having category as "Books" and ordered them by the price and stored the result in a list. As filtering is done before selection, the number of records is reduced which can optimize the query.
 
### Task 5 - Querybuilder

Created a query builder utility that allows users to construct complex LINQ queries using a fluent API pattern. This supports filtering, sorting, and joining data
<br>**Filter** :<br>&nbsp; Filter the list of data based on the condition and return the current class object.
<br>**Sort** :<br>&nbsp; Sort the list of data based on the condition and return the current class object.
<br>**Join** :<br>&nbsp; Join the list of data with another list based on the condition and return the current class object.
<br>**Select** : <br>&nbsp;Select the list of data based on the condition and return the current class object.