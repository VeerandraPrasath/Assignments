# Shape Class Implementation
 
## TASK-1: Shape Class
 
### Abstract Class: Shape
- **Description:** `Shape` is an abstract class that serves as the base for other shape classes.
- **Properties:**
  - `Color`: A protected property that can only be initialized during instantiation.
- **Methods:**
  - `CalculateArea()`: Abstract method that must be implemented by derived classes.
  - `PrintDetails()`: Virtual method with a default implementation to print the area, color, and type of the shape.
 
---
 
### Rectangle Class
- **Inheritance:** Inherits from `Shape`.
- **Properties:**
  - `Length`: Initialized during instantiation.
  - `Width`: Initialized during instantiation.
- **Constructor:** Initializes `Color`, `Length`, and `Width` properties.
- **Methods:**
  - `CalculateArea()`: Calculates the area of the rectangle.
  - `PrintDetails()`: Overrides the base class method to print rectangle details.
 
---
 
### Circle Class
- **Inheritance:** Inherits from `Shape`.
- **Properties:**
  - `Radius`: Initialized during instantiation.
- **Constructor:** Initializes `Color` and `Radius` properties.
- **Methods:**
  - `CalculateArea()`: Calculates the area of the circle.
  - `PrintDetails()`: Overrides the base class method to print circle details.
 
---
 
# Employee Class Implementation
 
## TASK-2: Employee Class
 
### Abstract Class: Employee
- **Description:** `Employee` is an abstract class that serves as the base for different employee types.
- **Properties:**
  - `Name`: Protected property initialized during instantiation.
  - `Salary`: Protected property initialized during instantiation.
- **Methods:**
  - `CalculateBonus()`: Abstract method to be implemented by derived classes.
  - `PrintDetails()`: Virtual method with a default implementation to print name, salary, position, and bonus amount.
 
---
 
### Manager Class
- **Inheritance:** Inherits from `Employee`.
- **Constant:**
  - `bonusPercentage`: Set to 40%.
- **Constructor:** Initializes `Name` and `Salary` by calling the base class constructor.
- **Methods:**
  - `CalculateBonus()`: Calculates the bonus for a manager based on `bonusPercentage`.
  - `PrintDetails()`: Overrides the base class method to print manager details.
 
---
 
### Developer Class
- **Inheritance:** Inherits from `Employee`.
- **Readonly Field:**
  - `bonusPercentage`: Set to 50%.
- **Constructor:** Initializes `Name` and `Salary` by calling the base class constructor.
- **Methods:**
  - `CalculateBonus()`: Calculates the bonus for a developer based on `bonusPercentage`.
  - `PrintDetails()`: Overrides the base class method to print developer details.
 
---
 
# Banking System Implementation
 
## TASK-3: BankingAccounts Class
 
### Abstract Class: BankingSystem
- **Description:** Represents a banking system with basic functionality.
- **Properties:**
  - `AccountNumber`: Protected, read-only property initialized via the constructor.
  - `Balance`: Public property with a protected setter, initialized to a default value.
- **Methods:**
  - `Withdraw(decimal amount)`: Abstract method to be implemented by derived classes.
  - `Deposit(decimal amount)`: Virtual method that increases the balance and prints the new balance.
  - `GetBalance()`: Prints the current balance.
 
---
 
### SavingsAccount Class
- **Inheritance:** Inherits from `BankingSystem`.
- **Constructor:** Initializes `AccountNumber` and sets the initial balance to a minimum of 2000.
- **Methods:**
  - `Withdraw(decimal amount)`: Allows withdrawals only if the resulting balance remains above the minimum balance. Prints a restriction message if insufficient balance.
 
---
 
### CheckingAccount Class
- **Inheritance:** Inherits from `BankingSystem`.
- **Constructor:** Initializes `AccountNumber` and sets the initial balance to zero.
- **Methods:**
  - `Withdraw(decimal amount)`: Allows withdrawals only if the resulting balance remains above zero. Prints a restriction message if insufficient balance.
 
---
 
# Usage
- The `Shape` and `Employee` classes demonstrate inheritance, abstraction, and polymorphism.
- The `BankingSystem` classes showcase encapsulation and inheritance in a practical context.
