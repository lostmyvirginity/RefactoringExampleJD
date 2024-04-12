namespace LegacyApp.Core.Validators.Users;

public class UserValidator : IUserValidator
{
    public bool validateUserCredits(User user)
    {
        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            return false;
        }

        return true;
    }
}