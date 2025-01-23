namespace OOPs.Task3
{
    /// <summary>
    /// Storing account details
    /// </summary>
    public class BankAccount
    {
        protected string accountNumber { get; set; }
        protected decimal balance { get; set; } = 0;

        /// <summary>
        /// Initialize account information
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="balance">Balance</param>
        protected BankAccount(string accountNumber, decimal balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        /// <summary>
        /// Update deposit amount
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            balance = balance + amount;
        }

        /// <summary>
        /// Update withdrawal amount
        /// </summary>
        /// <param name="amount">Amount</param>
        public virtual void Withdraw(decimal amount)
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