# Reflection in C#
 
## Task-1 (Inspect Assembly Metadata)  
Implemented a program that inspects the metadata of an assembly using Reflection.Used Assembly.LoadFile to load assemblies dynamically.Extracted types, methods, properties, fields, and events using `GetTypes`, `GetMethods`, `GetProperties`, `GetFields`, and `GetEvents`. Displayed metadata information for analysis.  <br><br>
![17_TASK1_1](https://github.com/user-attachments/assets/bf49a031-03bc-4425-a572-91772544ec0f)
![17_TASK1_2](https://github.com/user-attachments/assets/bb3ff4e9-a984-4e23-bf87-e7567f67ef0a)

 
## Task-2 (Dynamic Object Inspector)  
Developed a dynamic object inspector tool to view and modify object properties at runtime.Retrieved object metadata using `GetType`.Displayed all properties and their values using `GetProperties`. Allowed modification of property values dynamically using `SetValue`.  <br><br>
![17_task2](https://github.com/user-attachments/assets/d3368a88-992b-4554-905a-36875eb5521c)

 
## Task-3 (Dynamic Method Invoker)  
Implemented a method invoker that dynamically calls methods on an object based on a provided method name.Extracted method metadata using `GetMethod`. Invoked the method using `Invoke`, passing necessary parameters dynamically.  <br><br>
![17_Task3](https://github.com/user-attachments/assets/ecfae45e-42d3-4746-84cc-1392311cdb08)


 
## Task-4 (Dynamic Type Builder)  
Built a dynamic type at runtime with user-defined properties and methods.Created an assembly and module using `AssemblyBuilder` and `ModuleBuilder`.Defined a new class using `TypeBuilder`.Added properties and methods dynamically using `DefineProperty` and `DefineMethod`.Instantiated the dynamically generated type and used it in runtime operations.  <br><br>
![17_Task4](https://github.com/user-attachments/assets/10107106-a25c-4f6f-ba98-8e55d59aac18)

 
## Task-5 (Plugin System)  
Developed a plugin system for loading and executing methods from external assemblies at runtime.Defined a common interface for plugins.Created plugin assemblies that implement the interface.Loaded plugin assemblies dynamically using `Assembly.LoadFile`.Retrieved and instantiated plugin types dynamically.Called methods on plugins through Reflection.  <br><br>
![17_TASK5](https://github.com/user-attachments/assets/93c0b0e1-b098-454b-9231-945bd317aa80)

 
## Task-6 (Mocking Framework)  
Implemented a dynamic mocking framework using Reflection.Emit.Identified an interface to mock.Generated a dynamic type implementing the interface using `TypeBuilder`.Defined methods dynamically using `MethodBuilder`, returning default values.Created an instance of the mock type and used it in unit testing scenarios.  <br><br>
![17_task6](https://github.com/user-attachments/assets/e49704b5-6b72-4c42-84db-397cb1088bdf)

 
## Task-7 (Serialization API)  
Developed a simple serialization API using Reflection and optimized it using Reflection.Emit.Implemented serialization of objects to a custom format using Reflection.Identified performance and correctness limitations.Rewrote serialization logic using `DynamicMethod` and `ILGenerator` to optimize performance.Compared execution time and correctness between Reflection-based and Reflection.Emit-based serialization.  <br><br>
 ![17_Task7](https://github.com/user-attachments/assets/586babb0-58db-4912-bda5-02520041e5db)
