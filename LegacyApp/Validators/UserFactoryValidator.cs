using LegacyApp.Factory;

namespace LegacyApp.Core.Validators.Users;

public class UserFactoryValidator
{
    public IUserFactory GetUserFactoryByClientType(string clientType, ICreditLimitService creditLimitService)
    {
        switch (clientType)
        {
            case "VeryImportantClient":
                return new VeryImportantUserFactory();
            case "ImportantClient":
                return new ImportantUserFactory(creditLimitService);
            default:
                return new NormalUserFactory(creditLimitService);
        }
        
    }
}