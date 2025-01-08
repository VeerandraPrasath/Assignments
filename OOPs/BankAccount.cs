
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        protected decimal Balance { get; set; } = 0;
    protected BankAccount(string accountNumber,decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
    public  void Deposit(decimal amount)
    {
        Balance = Balance + amount;
    }
    public abstract void Withdraw(decimal amount);
    }
public class SavingsAccount : BankAccount
{
    private const int MIN_BALANCE = 1000;
    public SavingsAccount(string accountNumber, decimal balance) : base(accountNumber, balance)
    {
        
    }
   

    public override void Withdraw(decimal amount)
    {
        if((Balance-amount)<MIN_BALANCE)
        {
            Console.WriteLine("Unable to dispense amount due to Minimum balance!! ");
            return;
        }
        Balance -= amount;
        Console.WriteLine("Amount dispensed successfully !!! ");

    }
}
public class CheckingAccount : BankAccount
{
    
    public CheckingAccount(string accountNumber,decimal balance):base(accountNumber,balance) 
    {
       
    }
   

    public override void Withdraw(decimal amount)
    {
        if ((Balance - amount) < 0)
        {
            Console.WriteLine("Insufficient Balance !! ");
            return;
        }
        Balance -= amount;
        Console.WriteLine("Amount dispensed successfully !!! ");

    }
}


