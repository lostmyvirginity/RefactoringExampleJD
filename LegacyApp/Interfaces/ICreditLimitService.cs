using System;

namespace LegacyApp.Core.Validators;

public interface ICreditLimitService
{
    int GetCreditLimit(string lastName, DateTime birthDate);
}