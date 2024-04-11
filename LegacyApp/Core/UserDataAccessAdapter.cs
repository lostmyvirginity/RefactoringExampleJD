namespace LegacyApp.Core;

public class UserDataAccessAdapter
{
    public UserDataAccessAdapter()
    {
        
    }
    public void AddUser(User user)
    {
        //some future logic
        UserDataAccess.AddUser(user);
    }
}