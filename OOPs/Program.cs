
using OOPs.Task1;
using OOPs.Task2;
using OOPs.Task3;

//Task1
Shape rect = new Rectangle(10, 5, "red");
rect.CalculateArea();
rect.PrintDetails();

Shape circle = new Circle(5, "green");
circle.CalculateArea();
circle.PrintDetails();

//Task2
Employee developer = new Developer("prasath", 1000);
developer.printDetails();

Employee manager = new Manager("Nikil", 5000);
manager.printDetails();

//Task3
BankAccount savingsAccount = new SavingsAccount("3746347", 1200);
savingsAccount.Deposit(100); //   Deposit success - balance=1300
savingsAccount.Withdraw(300);//Withdram Sucess - balance =1000
savingsAccount.Withdraw(1); //Withdram fails because of mininum balance

BankAccount checkingAccount = new CheckingAccount("3746233347", 2000);
checkingAccount.Deposit(100); //   Deposit success - balance=1300
checkingAccount.Withdraw(300);//Withdram Sucess - balance =1000
checkingAccount.Withdraw(1); //Withdram fails because of mininum balance