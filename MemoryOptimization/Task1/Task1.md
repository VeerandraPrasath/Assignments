# Task1
&nbsp;&nbsp;In the task,there is a code snippet with that we have to analyze the code and find the memory issue with the help of the Visual studio's Diagnostic Tool and  find a optimization techniques that can be applied to the code so that the memory issue will be resolve.

   ## Code 
       public void Allocate()
        {
            while(true)
            {
                memalloc.Add(new int[1000]);
                Thread.Sleep(100);  
            }
        }
&nbsp;&nbsp;In the above code ,there is a issue with the memory and also the working of the method "Allocate".In that method,There is a while loop which allows to add a integer array to a list and  pause the flow of execution for 0.1 second. 
## Issue
&nbsp;&nbsp;The issue with the code is that the while loop will not terminate at any time so that it will keep on adding the integer array to the list and it will keep on consuming the memory and it will lead to the memory leak.
