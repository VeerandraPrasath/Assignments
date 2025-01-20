/// <summary>
/// class inherit from the bankAccount class
/// </summary>
public class CheckingAccount : BankAccount
{
    /// <summary>
    /// initalize the account number and balance in base class
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="balance"></param>
    public CheckingAccount(string accountNumber,decimal balance):base(accountNumber,balance) 
    {
       
    }
   
    /// <summary>
    /// update the withdraw amount to balance with certain constraints
    /// </summary>
    /// <param name="amount"></param>
    public override void Withdraw(decimal amount)
    {
        if ((balance - amount) < 0)
        {
            Console.WriteLine("Insufficient balance !! ");
            return;
        }
        balance -= amount;
        Console.WriteLine("Amount dispensed successfully !!! ");

    }
}


