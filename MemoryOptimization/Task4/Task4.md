## Reflection on the Assignment
&nbsp;&nbsp;This assignment provides a good experience with memory management and also with using Diagnostic tool in Visual Studio.
## Code Analysis
&nbsp;&nbsp;In the given code,there is a class which contains a list of integer array and a method "Allocate" which allows to add a integer array to a list and pause the flow of execution for 0.1 second. Here the memory increase without any limit shown in the  diagnostic  tool and it will lead to the memory leak.
## Memory Profiling
&nbsp;&nbsp;Using Visual Studio's built-in Diagnostic Tools, diagnosed the problem in the code. The results showed an increase in heap memory usage due to the infinite loop.
## Optimized code implementation
&nbsp;&nbsp;Here,to make the code more optimized,we have changed the condition to the for loop so that it will terminate at some point of time and it will not keep on adding the integer array to the list and it will not consume the memory without any limit.
## After optimization
&nbsp;&nbsp;After optimization, the code will not consume the memory without any limit and it will not lead to the memory leak.Also the diagnostic tool will not show the memory increase without any limit.