# Expense Tracker
## Project Description
The *Expense Tracker* is a console application that allows users to create account with username and login to their accounts to track their day to day expenses. Users can add, view, search, edit, and delete their expense records and also able to view the entire summary. The application provides a user-friendly login,menu for manage their records and logout the application.All the information are stored in file which helps to load information on next execution.
## Implementation
**User:**<br>
     &nbsp; User can create account and store the expense record details as both income and expense records with amount and category.
 
**File Storage:**<br>
    &nbsp;The application maintains a json file in which all the user information are stored as list of user.This file helps to load and save the user information without any loss on next execution.<br>
     &nbsp;Here to serialize and deserialize the user list  *NewtonsoftJson*  package is used for clear  identification of types during  serializing and deserializing.
    
**Financial Summary:**<br>
     &nbsp;Users can view the financial summary of their expense records such as Net balance , Total income and Total expense entirely or specifically on certain dates
 
**User Interface:**
  - The application provides a console-based user interface.
  - Users interact with the Expense manager through a menu system, choosing options to perform different actions.
## Features
1. **Create User account**<br>
      &nbsp;Allows user to create new account for the tracker with unique username
2. **View Records**<br> 
  &nbsp; Display all expense records of the User.
3. **Add Records:**<br>
      &nbsp; User can add record as well as income record or expense record based on the user requirement.
 
4. **Search Record**<br>
      &nbsp;Search record based on date when the record was created.
5. **Edit Record**<br> 
   &nbsp;Edit the record information of  available records with it's date
6. **Delete Record**<br>
   &nbsp;Delete an existing record based on date  when the record was created.
---
## Installation and Running the Project
### 1. Install Visual Studio
Before you start, ensure that you have Visual Studio installed on your computer.  
If not, you can download and install it from the [Visual Studio downloads page](https://visualstudio.microsoft.com/).
### 2. Clone the Project
After installing Visual Studio:  
- Clone the project by copying the project repository link.  
- Use Git to clone the project to your local machine.  
https://github.com/VeerandraPrasath/Assignments.git
### 3. Import the Project into Visual Studio
- Open Visual Studio.  
- Import the project by selecting the project's folder.  
### 4. Install required packages
- install NewtonSoftJson package using NuGet Manager
- import using the namespace *Newtonsoft.Json*
### 4. Run the Project
- Set the project as the *Startup Project*.  
- Run the project to start the Inventory  Manager application.