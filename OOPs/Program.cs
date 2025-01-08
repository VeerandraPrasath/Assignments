
using OOPs;
//Task1

//Shape rect = new Rectangle(10, 5, "red");
//rect.CalculateArea();
//rect.PrintDetails();

//Task2
//Employee employee = new Developer("prasath",1000);
//employee.printDetails();

//Task3
BankAccount account = new SavingsAccount("3746347",1200);
account.Deposit(100); //   Deposit success - balance=1300
account.Withdraw(300);//Withdram Sucess - balance =1000
account.Withdraw(1); //Withdram fails because of mininum balance