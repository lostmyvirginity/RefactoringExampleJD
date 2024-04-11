using System;

namespace LegacyApp.Factory;

public class NormalUserFactory : IUserFactory
{
    public User CreateUser(string client, DateTime dateOfBirth, string email, string firstName, string lastName)
    {
        return new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
    }
}