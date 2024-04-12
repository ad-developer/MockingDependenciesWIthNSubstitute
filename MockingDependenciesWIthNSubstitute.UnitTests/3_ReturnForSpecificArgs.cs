using MockingDependenciesWIthNSubstitute.Application;
using MockingDependenciesWIthNSubstitute.Application.Interfaces;
using NSubstitute;

public class ReturnForSpecificArgs
{
    [Fact]
    public void ReturnForSpecificArgsOne()
    {
        // Arrange
        var  legacySystemProxy = Substitute.For<ILegacySystemProxy>();
        legacySystemProxy.DefaultProduct.Returns(new AccountProduct{
            Code = 1,
            Title = "Test Product",
            Description = "Test Product"
        });
        var customerValidationService = Substitute.For<ICustomerValidationService>();
          var customer = new Customer{
            FirstName = "John",
            LastName = "Smith",
            Address = "Some street",
            Email = "John.Smith@email.com",
            PhoneNumber = "(333) 333 - 4444"
        };
        
        customerValidationService.ValidateCustomer(customer).Returns(true);

        var accountValidationService = Substitute.For<IAccountValidationService>();
        
        legacySystemProxy.CreateAccount(Arg.Any<Customer>(), Arg.Is<AccountType>(x => x == AccountType.Individual) ).Returns(new Account());

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
      
        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.Null(ex);
    }

     [Fact]
    public void ReturnForSpecificArgsTwo()
    {
        // Arrange
        var  legacySystemProxy = Substitute.For<ILegacySystemProxy>();
        legacySystemProxy.DefaultProduct.Returns(new AccountProduct{
            Code = 1,
            Title = "Test Product",
            Description = "Test Product"
        });
        var customerValidationService = Substitute.For<ICustomerValidationService>();
          var customer = new Customer{
            FirstName = "John",
            LastName = "Smith",
            Address = "Some street",
            Email = "John.Smith@email.com",
            PhoneNumber = "(333) 333 - 4444"
        };
        
        customerValidationService.ValidateCustomer(customer).Returns(true);

        var accountValidationService = Substitute.For<IAccountValidationService>();
        
        legacySystemProxy
            .CreateAccount(customer, Arg.Is<AccountType>(x => x == AccountType.Individual || x == AccountType.Business) )
            .Returns(new Account());

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
      
        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.Null(ex);
    }
}
