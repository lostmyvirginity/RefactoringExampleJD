using LegacyApp;
using LegacyApp.Core;
using LegacyApp.Core.Validators.Users;

namespace LegacyAppTests;

public class ServiceTest
{
    [Fact]
    public void Add_User_Should_Return_False_When_Mail_Is_Incorrect()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var creditService = new FakeUserCreditService();
        var userAdapter = new FakeUserDataAccessAdapter();
        var userValidator = new UserValidator();
        var factoryValidator = new UserFactoryValidator();
        var userService = new UserService(inputValidator, clientRepository, creditService, userAdapter, factoryValidator, userValidator);
        string firstName = "Numernabis";
        string lastName = "x";
        string email = "xapl";
        DateTime dateOfBirth = new DateTime(2000, 01, 01);
        int clientID = 1;


        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientID);
        
        Assert.False(result);
    } 
    
    [Fact]
    public void Add_User_Should_Return_False_When_User_Is_Not_in_DB()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var creditService = new FakeUserCreditService();
        var userAdapter = new FakeUserDataAccessAdapter();
        var userValidator = new UserValidator();
        var factoryValidator = new UserFactoryValidator();
        var userService = new UserService(inputValidator, clientRepository, creditService, userAdapter, factoryValidator, userValidator);
        string firstName = "Kazimierz";
        string lastName = "x";
        string email = "xapl";
        DateTime dateOfBirth = new DateTime(2000, 01, 01);
        int clientID = 1;


        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientID);
        
        Assert.False(result);
    }

    [Fact]
    public void Add_User_Adapter_Test_When_Evrything_Is_Fine()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var creditService = new FakeUserCreditService();
        var userAdapter = new FakeUserDataAccessAdapter();
        var userValidator = new UserValidator();
        var factoryValidator = new UserFactoryValidator();
        var userService = new UserService(inputValidator, clientRepository, creditService, userAdapter, factoryValidator, userValidator);
        string firstName = "Marnypopis";
        string lastName = "Marnypopis";
        string email = "x@d.pl";
        DateTime dateOfBirth = new DateTime(2000, 01, 01);
        int clientID = 2;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientID);
        Assert.True(result);
    }
}