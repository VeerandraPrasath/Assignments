namespace OOPs.Task3
{
    /// <summary>
    /// Class inherit the features of the BankAccount class
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        private const int MIN_BALANCE = 1000;

        /// <summary>
        /// Initialize account information
        /// </summary>
        /// <param name="accountNumber">Account Number</param>
        /// <param name="balance">Balance</param>
        public SavingsAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }
       
        /// <summary>
        /// Update  withdrawal amount 
        /// </summary>
        /// <param name="amount"></param>
        public override void Withdraw(decimal amount)
        {
            if (balance - amount < MIN_BALANCE)
            {
                Console.WriteLine("Unable to dispense amount due to Minimum balance!! ");

                return;
            }
            balance -= amount;
            Console.WriteLine("Amount dispensed successfully !!! ");
        }
    }
}