using LegacyApp.Factory;

namespace LegacyApp.Core.Validators.Users;

public class UserFactoryValidator
{
    public IUserFactory GetUserFactoryByClientType(string clientType, ICreditLimitService creditLimitService)
    {
        return clientType switch
        {
            "VeryImportantClient" => new VeryImportantUserFactory(),
            "ImportantClient" => new ImportantUserFactory(creditLimitService),
            _ => new NormalUserFactory(creditLimitService)
        };
    }
}