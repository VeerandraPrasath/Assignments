
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


