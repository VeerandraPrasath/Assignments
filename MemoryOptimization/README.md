# Memory Optimization

## Task 1
&nbsp;&nbsp;In the task,there is a code snippet with that we have to analyze the code and find the memory issue with the help of the Visual studio's Diagnostic Tool and  find a optimization techniques that can be applied to the code so that the memory issue will be resolve.
   
## Task2

&nbsp;&nbsp;In this task,we have to modify the code to make it more optimized and also need to resolve the memory leak.

## Task3
&nbsp;&nbsp;In this task,we have to give reasons for the change in the code to make more optimizated and how it resolve the memory issue.

## Task4
&nbsp;&nbsp;In this task,we need to share the reflection on the assignment and also need to share the code analysis and memory profiling and optimized code implementation.

# Project Reflection
  A good experience with memory management and also with using Diagnostic tool in Visual Studio. Gets clear understanding of how the memory impact the performance of the application and how they are managed by the languages.Also comes to know hwo these reference types are stroed and used and the importance of Garbage collectors.

# Memory observation

In the given starter code ,The memory starts raising up in a huge size and there is not end points to stop this process .The size of the mempry is fixed so that there may be lot of unused memory.All those memory are not dispose by the Garbage collector because they all having references .The raising in memory can be view in the below figure.<br><br>
![before_optimization](https://github.com/VeerandraPrasath/Assignments/blob/assignment12/MemoryOptimization/Images/BeforeOptimization.png)

In the optimized code,To stop the raising up of memory,The process is limited to certain number of times and gets the size to allocate only the required memory size and dispose all the memory manually which can free up the unrefernced types.The huge impact in the memory after making all these changes are in the below figure<br><br>
![after_optimization](https://github.com/VeerandraPrasath/Assignments/blob/assignment12/MemoryOptimization/Images/AfterOptimization.png)
