using System;
using LegacyApp.Core.Validators;

namespace LegacyApp.Factory;

public class ImportantUserFactory : IUserFactory
{
    private ICreditLimitService _creditLimitService;
    public ImportantUserFactory(ICreditLimitService creditLimitService)
    {
        _creditLimitService = creditLimitService;
    }
    public User CreateUser(Client client, DateTime dateOfBirth, string email, string firstName, string lastName) 
    {
        int creditLimit = _creditLimitService.GetCreditLimit(lastName, dateOfBirth);
        creditLimit = creditLimit * 2;
        return new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName,
            CreditLimit = creditLimit
        };
        
    }
}