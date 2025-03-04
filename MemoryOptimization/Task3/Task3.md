# Task3
 &nbsp;&nbsp;In this task,we have to give reasons for the change in the code to make more optimizated and how it resolve the memory issue.
## Before optimizatoin
 &nbsp;&nbsp;Before optimization , the method "Allocate" has a while loop which allows to add a integer array to a list and pause the flow of execution for 0.1 second.Here the memory increase without any limit shown in the  diagnostic  tool and it will lead to the memory leak.
## Optimized code implementation
 &nbsp;&nbsp;Here,to make the code more optimized,we have changed the condition to the for loop so that it will terminate at some point of time and it will not keep on adding the integer array to the list and it will not consume the memory without any limit.
## After optimization
 &nbsp;&nbsp;After optimization, the code will not consume the memory without any limit and it will not lead to the memory leak.Also the diagnostic tool will not show the memory increase without any limit.