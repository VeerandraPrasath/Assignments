namespace ExpenseTracker.Manager
{

    /// <summary>
    /// <see cref="IManageTracker"/> manages the Login functionalities
    /// </summary>
    public interface IManageTracker
    {
        /// <summary>
        /// <see cref="Login"/> used to checkin the account
        /// </summary>
        public void Login();

        /// <summary>
        /// <see cref="CheckExisitingUser"/> checks wheather the user is valid or not
        /// </summary>
        public void CheckExisitingUser();
    }
}