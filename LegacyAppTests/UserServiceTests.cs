using LegacyApp;

namespace UnitTest;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Mail_At_Missing()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser(null, null, "testk.pl", new DateTime(1980, 1, 1), 1);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_No_Credit_Limit_Exsists_For_User()
    {
        //Arrange
        var service = new UserService();
        
        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.AddUser("John", "Andrzejewicz", "andrzejewicz@wp.pl", new DateTime(1980, 1, 1), 6);
        });
    }
    
    
}