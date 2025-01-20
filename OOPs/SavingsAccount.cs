/// <summary>
/// Class inherit the features of the BankAccount class
/// </summary>
public class SavingsAccount : BankAccount
{
    private const int MIN_BALANCE = 1000;

    /// <summary>
    /// Constructor initialize the accountNumber and Balance
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="balance"></param>
    public SavingsAccount(string accountNumber, decimal balance) : base(accountNumber, balance)
    {

    }

    /// <summary>
    /// Override Method to update the withdrawal amount with certain constraints
    /// </summary>
    /// <param name="amount"></param>
    public override void Withdraw(decimal amount)
    {
        if ((balance - amount) < MIN_BALANCE)
        {
            Console.WriteLine("Unable to dispense amount due to Minimum balance!! ");
            return;
        }
        balance -= amount;
        Console.WriteLine("Amount dispensed successfully !!! ");

    }
}


