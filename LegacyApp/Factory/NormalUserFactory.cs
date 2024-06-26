using System;
using LegacyApp.Core.Validators;

namespace LegacyApp.Factory;

public class NormalUserFactory : IUserFactory
{
    private ICreditLimitService _creditLimitService;
    public NormalUserFactory(ICreditLimitService creditLimitService)
    {
        _creditLimitService = creditLimitService;
    }
    public User CreateUser(Client client, DateTime dateOfBirth, string email, string firstName, string lastName)
    {
        int creditLimit = _creditLimitService.GetCreditLimit(lastName, dateOfBirth);
        return new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName,
            HasCreditLimit = true,
            CreditLimit = creditLimit
        };
    }
}