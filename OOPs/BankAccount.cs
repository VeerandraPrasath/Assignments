
public abstract class BankAccount
    {
        protected string AccountNumber { get; set; }
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


