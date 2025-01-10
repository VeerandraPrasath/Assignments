# Contact Manager
 
## Project Description
The **Contact Manager** is a console application that allows users to manage their contacts. Users can add, view, search, edit, and delete contacts. The application provides a user-friendly menu for interacting with the contact list.
 
---
 
## Features
1. **Add Contact**  
   Add new contacts with details such as name, phone number, email, and additional notes.
 
2. **View Contacts**  
   Display all contacts in the contact list, sorted by name.
 
3. **Search Contacts**  
   Search for contacts using any information.
 
4. **Edit Contact**  
   Edit the details of existing contacts.
 
5. **Delete Contact**  
   Delete an existing contact from the contact list.
 
---
 
## Namespaces
 
### `IRepositoryInteraction`
- **Description:** Contains the `RepositoryInteraction` class which implements the `IRepositoryInteraction` interface. This namespace handles interactions with the contact list.
 
### `IUserInteraction`
- **Description:** Contains the `UserInteraction` class which implements the `IUserInteraction` interface. This namespace is responsible for displaying menu options to the console.
 
---
 
## Classes
 
### `ContactInformation`
- Represents a contact with properties for:
  - Name
  - Phone Number
  - Email
  - Additional Notes
 
### `ContactManager`
- Manages contact operations such as:
  - Adding
  - Viewing
  - Searching
  - Editing
  - Deleting
 
### `RepositoryInteraction`
- Provides methods for interacting with the contact list.
 
### `UserInteraction`
- Provides methods for user menu interactions.
 
---
 
## Installation and Running the Project
 
### 1. Install Visual Studio
Before you start, ensure that you have Visual Studio installed on your computer.  
If not, you can download and install it from the [Visual Studio downloads page](https://visualstudio.microsoft.com/).
 
### 2. Clone the Project
After installing Visual Studio:  
- Clone the project by copying the project repository link.  
- Use Git to clone the project to your local machine.  
  ```bash
### 3. Import the Project into Visual Studio
- Open Visual Studio.  
- Import the project by selecting the project's folder.  
 
### 4. Run the Project
- Set the project as the **Startup Project**.  
- Run the project to start the Contact Manager application.