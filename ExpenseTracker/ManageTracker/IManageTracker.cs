/// <summary>
/// <see cref="IManageTracker"/> manages the login functionalities
/// </summary>
public interface IManageTracker
{
    /// <summary>
    /// <see cref="login"/> used to checkin the account
    /// </summary>
    public void login();

    /// <summary>
    /// <see cref="CheckExisitingUser"/> checks wheather the user is valid or not
    /// </summary>
    public void CheckExisitingUser();
}

