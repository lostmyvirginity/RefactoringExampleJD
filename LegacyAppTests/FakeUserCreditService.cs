using LegacyApp.Core.Validators;

namespace LegacyAppTests;

public class FakeUserCreditService : ICreditLimitService
{
    private readonly Dictionary<string, int> _db = new()
    {
        {"Marnypopis", 600},
        {"Asterix", 500},
        {"Obelix", 300}
    };
        
    public int GetCreditLimit(string lastName, DateTime birthDate)
    {
        return _db.GetValueOrDefault(lastName, 0);
    }
}