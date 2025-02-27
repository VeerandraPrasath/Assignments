1.Explain what the .NET platform is and its primary purpose.<br>
&nbsp;&nbsp;The .NET platform is a free,open source platform developed by Microsoft that helps developers to build ,run , deploy application than can run on various devices including web ,mobile ,desktop ,gaming and IOT applications.<br><br>
Primary purpose of .NET :<br>
&nbsp;&nbsp;1.It provides libraries with pre-defined classes and functions to build applications.<br>
&nbsp;&nbsp;2.It also provides framework ASP.net to build web applications.<br>
&nbsp;&nbsp;3.It allows developers to build applications in multiple languages like C#,VB.NET,F#.<br>
&nbsp;&nbsp;4.It provides a runtime environment to run the applications.<br>

2.What are the key components of the .NET platform?<br>
&nbsp;&nbsp;There are two main components in .NET platform:<br>
&nbsp;1.CLR(Common Language Runtime)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLR is the runtime environment that runs the code and it provides various services such as Garbage collection,Just in time compilation and exception handling.<br>
&nbsp;2.FCL(Framework Class Library)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FCL contains predefined classes and functions that are used to build applications when it is required.It includes Collections,Linq etc<br>
&nbsp;3.Base Class Library<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It is a collection of reusable classes,interfaces and value types that provide functionality for commom programming tasks
&nbsp;4.ASP.NET
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Framework for building web applications and services.

3.Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET.<br>
&nbsp;&nbsp;CLR(Common Language Runtime) is the execution environment for .NET applications  to run the application and it provides memory management ,error handling and compilation services.The CLR allow code written in different languages to run in a common environment whereas CTS(Common Type System) defines the data types that can be used in .NET languages.It ensures that the types are consistent over different languages.Also allows for interoperability.<br>

4.What is the role of the Global Assembly Cache (GAC) in .NET?<br>
&nbsp;&nbsp; The Global Assembly Cache (GAC) in .NET is a repository for storing assemblies that are shared to multiple applications.The GAC allows execution of different versions of the same assembly.It also prevents conflicts between applications that depends on different versions of library.

5.Explain the difference between value types and reference types in C#. <br>
&nbsp;&nbsp;Value types are stored in stack memory which the changes are not reflected when it is passed and  modified by any other methods.When a value type is assigned to a new variable,a copy of the value is made and reference types are stored in heap memory which shares the address of it so that any changes that made anywhere will be reflected.When the reference type is assigned to a new variable,only the reference is copied,not the actual data.<br>

6.Describe the concept of garbage collection on .NET and its advantages. <br>
&nbsp;&nbsp;Garbage collection is an automatic memory memory management feature that  is used to handle the allocation and de-allocation of memory automatically.The GC periodically checks for objects that are no longer referenced and frees up the memory they occupy.It uses three generations to manage memory and it starts work at anytime which is not predictable .

Advantages:<br>
&nbsp;&nbsp;1.It removes the unused memory.<br>
&nbsp;&nbsp;2.Improves the performance.<br>
&nbsp;&nbsp;3.It runs automatically rather than invoking manually.<br>

7.What is the purpose of the Globalization and Localization features in .NET? <br>
&nbsp;&nbsp;Globalization refers to the process of designing applications that can be adapted to various languages.It involves using culture-specific formats for dates,number and currencies <br>&nbsp;&nbsp; Localization refers to the process of adapting a globalized application for the specific culture or region.This includes translating text,formatting dates and numbers.<br>

8.Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. <br>
&nbsp;&nbsp;Common Intermediate Language(CIL) is also known as MSIL(Microsoft Intermediate Language) is a low level programming language used in the .NET framework.It provides an intermediate code written in high-level languages before it is executed by the CLR.<br>
&nbsp;&nbsp;Just-In-Time(JIT) compilation is used by the Common language runtime (CLR) to convert the intermediate code into machine code which is platform independent.This process occurs when the method is called for the first time<br>