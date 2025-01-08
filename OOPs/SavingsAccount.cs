
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


