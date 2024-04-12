using System;
using LegacyApp.Core.Validators;

namespace LegacyApp.Factory;

public class VeryImportantUserFactory : IUserFactory
{
    
    public User CreateUser(Client client, DateTime dateOfBirth, string email, string firstName, string lastName)
    {
        return new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName,
            HasCreditLimit = false
        };
    }
}