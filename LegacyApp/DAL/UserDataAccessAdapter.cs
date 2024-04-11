using LegacyApp.Core.Validators;

namespace LegacyApp.Core;

public class UserDataAccessAdapter : IUserDataAccessAdapter
{
    public void AddUser(User user)
    {
        UserDataAccess.AddUser(user);
    }
}