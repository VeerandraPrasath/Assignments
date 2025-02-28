# Memory Management
## Description
  &nbsp;&nbsp;   This project has three sub projects which are all done for understanding the concepts of memory management in operating system such as how the memory allocation is done for reference and value typea ,how the garbage collector works and how and where the dispose methods are used.
## Implementation
   There are three sub projects .They are<br>
   &nbsp;&nbsp;  1.ValueAndReferenceTypes<br>
     &nbsp;&nbsp;  2.GarbageCollector<br>
   &nbsp;&nbsp;    3.DisposeMethods
### ValueAndReferenceTypes
 &nbsp;&nbsp;    This project is build to understand the memory allocation for value and reference types and how they can be modified as separate tasks.

### GarbageCollector
  &nbsp;&nbsp;   This project is build to understand working of the garbage collector on unreferenced objects and the impacts in the memory usage.
### DisposeMethods
  &nbsp;&nbsp;   This project is build to understand the usage of dispose methods and how they can be used to release the memory of the objects by creating a streamwriter object and writing some data to a file and then releasing the memory of the object using dispose method.
## Reflection
In this projects ,understand the importance of reference and value types and how they are monitored by the Garbage collector .The Garbage collector removes the unused reference types and how the Garbage collector works for different type.Also comes to know about the Dispose methods and why it is needed and how it optimize the memory usage.Understand the role of "using" keyword.
## Memory Observations
### ReferenceType
On working with reference types , the Garbage collector collects the unused referenced objects at some times.Because GC only checks the heap memory which only contains the reference type objects for unused references .It checks and remove those objects which was shown in the below figure.<br>
### ValueTYpe
On working with value types ,the Garbage collector does not collects the unused values types because GC only acts on the heap but these value types are stored in the stack of the memory.Therefore ,the memory will not clear and increase gradually for large use of value types.<br>
### Garbage Collector 
The Garbage collector can be manually invoke using the GC.Collect method which will checks and clear the unused references in the heap memory.
#### Without GC Collect
Without the use of GC collect,the GC can also invoke on some times automatically and clear the objects .<br>

#### With GC Collect
With the use of GC collect,it manually invoke the GC when the execution control reaches the line.But it will not reflect a lot if no more objects are cleared because viewing those result in the Visual Studio cost some memory.
