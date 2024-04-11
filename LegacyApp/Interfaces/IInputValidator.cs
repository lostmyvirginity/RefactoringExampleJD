using System;

namespace LegacyApp.Core.Validators;

public interface IInputValidator
{
    public bool ValidateEmail(string email);
    public bool ValidateAge(DateTime dateOfBirth);
    public bool ValidateName(String firstName, string lastName);
}