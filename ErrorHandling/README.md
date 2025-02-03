# Error Handling

## Task1
    
&nbsp;&nbsp;The exception is handled by using try and except block. The try block is used to check the code for errors. The catch block is used to handle the error. If the code in the try block is error free, then the catch block will be skipped.In this ,The DivideByZeroException is handled when user input equals to zero.

## Task2

&nbsp;&nbsp;In Task2 , Another exception which is IndexOutOFRangeException is handled when the user input is out of range.

## Task3
 
&nbsp;&nbsp;In Task3,An custom exception was created with class name "InvalidUserInputException" and it is used to handle  when the user input is not a number.

## Task4

&nbsp;&nbsp;In Task4,A method with unhandled exception is written and uses the AppDomain's UnhandledException event to catch the  unhandled exceptions globally. 

## Task5
&nbsp;&nbsp;In Task5,The stack trace of the exception thrown was printed to the console

&nbsp;&nbsp;The stack trace message is given below:
"System.DivideByZeroException: 'Attempted to divide by zero.
   at ErrorHandling.Task5.CalculateDailySalary(Int32 salary, Int32 days) in C:\Users\veerandra.prasath\source\repos\ContactManager\ErrorHandling\Task5.cs:line 69
   at ErrorHandling.Task5.Run() in C:\Users\veerandra.prasath\source\repos\ContactManager\ErrorHandling\Task5.cs:line 19"

&nbsp;&nbsp;This message shows that the initial call is from the Task5.Run() method and the exception that is thrown in the Task5.CalculateDailySalary() method was  DivideByZeroException in the line 69.
 
