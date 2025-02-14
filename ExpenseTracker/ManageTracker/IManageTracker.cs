namespace ExpenseTracker.Manager
{
    /// <summary>
    /// Manages the Login functionalities
    /// </summary>
    public interface IManageTracker
    {
        /// <summary>
        /// Used to login the account
        /// </summary>
        public void Login();

        /// <summary>
        /// Checks wheather the User is valid
        /// </summary>
        public void CheckExisitingUser();
    }
}