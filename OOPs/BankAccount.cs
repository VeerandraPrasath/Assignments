/// <summary>
/// abstract class with common properites to implement
/// </summary>
public abstract class BankAccount
    {
        protected string accountNumber { get; set; }
        protected decimal balance { get; set; } = 0;

    /// <summary>
    /// initialize the account number and the balance
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="balance"></param>
    protected BankAccount(string accountNumber,decimal balance)
    {
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    /// <summary>
    /// update the deposit to the balance
    /// </summary>
    /// <param name="amount"></param>
    public  void Deposit(decimal amount)
    {
        balance = balance + amount;
    }

    /// <summary>
    /// abstract method to update the withdrawal
    /// </summary>
    /// <param name="amount"></param>
    public abstract void Withdraw(decimal amount);
    }


