## Projects, Solutions and Build Order
* Created a blank solution and added the following projects to the solution.<br>
&emsp; &emsp; - Project A - GreetingApp<br>
&emsp; &emsp; - Project B - MathApp<br>
&emsp; &emsp; - Project C - DisplayApp<br>
&emsp; &emsp; - Project D - UtilityApp<br>
* Added Project B - MathApp as a dependency to Project A - GreetingApp. 
* Added Project C - DisplayApp as a dependency to Project B - MathApp.
* Added Project D - UtilityApp as a dependency to Project C - DisplayApp.
* When the solution is built, the order of building the project starts from the project with no dependencies. Before building a project, all its dependencies are built. If Project A depends on Project B, Project B depends on Project C, and Project C depends on Project D, the project build starts from Project D, then proceed by building Project C, then Project B, and then finally Project A. 
Once the dependencies are added, the Build Order of the Solution is: UtilityApp --> DisplayApp --> MathApp --> GreetingApp
* Created a new project Project E in the Solution. After adding the new project,the build order of the Solution becomes: UtilityApp -->ProjectE --> DisplayApp --> MathApp --> GreetingApp.
* If we want to change the Project Build Order, we need to change the dependencies accordingly to ensure that the build order is as per our requirement. To ensure that Project E is built after Project C - DisplayApp, added Project C as a dependency to Project E. After modifying the dependencies, the Build Order becomes: UtilityApp --> DisplayApp --> ProjectE --> MathApp --> GreetingApp.
