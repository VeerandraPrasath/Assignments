namespace OOPs.Task3
{
    /// <summary>
    /// Inherits BankAccount class
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initalize the values
        /// </summary>
        /// <param name="accountNumber">Account Number</param>
        /// <param name="balance">Balance</param>
        public CheckingAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }

        /// <summary>
        /// Update withdrawal amount
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        public override void Withdraw(decimal amount)
        {
            if (balance - amount < 0)
            {
                Console.WriteLine("Insufficient balance !! ");

                return;
            }
            balance -= amount;
            Console.WriteLine("Amount dispensed successfully !!! ");
        }
    }
}