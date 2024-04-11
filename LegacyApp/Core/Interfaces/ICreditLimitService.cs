using System;

namespace LegacyApp.Core.Validators;

internal interface ICreditLimitService
{
    int GetCreditLimit(string lastName, DateTime birthDate);
}