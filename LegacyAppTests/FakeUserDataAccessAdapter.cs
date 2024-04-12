using LegacyApp;
using LegacyApp.Core.Validators;

namespace LegacyAppTests;

public class FakeUserDataAccessAdapter : IUserDataAccessAdapter
{
    public void AddUser(User user)
    {
        Console.WriteLine("Fake adapter add the user successfully");
    }
}