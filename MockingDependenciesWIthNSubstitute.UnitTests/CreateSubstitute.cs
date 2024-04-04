using MockingDependenciesWIthNSubstitute.Application;
using MockingDependenciesWIthNSubstitute.Application.Interfaces;
using NSubstitute;

namespace MockingDependenciesWIthNSubstitute.UnitTests;

public class CreateSubstitute
{
   [Fact] 
    public void SubstituteTest(){
        
        // Arrange

        var  legacySystemProxy = Substitute.For<ILegacySystemProxy>();
        var customerValidationService = Substitute.For<ICustomerValidationService>();
        var accountValidationService = Substitute.For<IAccountValidationService>();

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
        var customer = new Customer{
            FirstName = "John",
            LastName = "Smith",
            Address = "Some street",
            Email = "John.Smith@email.com",
            PhoneNumber = "(333) 333 - 4444"
        };

        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.NotNull(ex); 
    }

    [Fact]
     public void MultipleSubstituteTest(){
        
        // Arrange

        var  legacySystemProxy = Substitute.For<ILegacySystemProxy, IDisposable>();
        var customerValidationService = Substitute.For<ICustomerValidationService>();
        var accountValidationService = Substitute.For<IAccountValidationService>();

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
        var customer = new Customer{
            FirstName = "John",
            LastName = "Smith",
            Address = "Some street",
            Email = "John.Smith@email.com",
            PhoneNumber = "(333) 333 - 4444"
        };

        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.NotNull(ex); 
    }

     [Fact]
     public void SubstituteForDelegatesTest(){
        
        // Arrange
        var func = Substitute.For<Func<string>>();
        
        // Act
        func().Returns("hello");
        
        // Assert
        Assert.Equal("hello", func());
    }
}
