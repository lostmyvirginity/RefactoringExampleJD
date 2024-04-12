using System;
using System.Runtime.InteropServices.JavaScript;

namespace LegacyApp.Factory;

public interface IUserFactory
{
    public User CreateUser(Client client, DateTime dateOfBirth, string email, string firstName, string lastName);
}