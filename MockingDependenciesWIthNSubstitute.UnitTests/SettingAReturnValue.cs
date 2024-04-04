using MockingDependenciesWIthNSubstitute.Application;
using MockingDependenciesWIthNSubstitute.Application.Interfaces;
using NSubstitute;


public class SettingAReturnValue
{
    [Fact]
    public void SettingReturnValueForMethods(){
        
        // Arrange
        var  legacySystemProxy = Substitute.For<ILegacySystemProxy>();
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

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
      

        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.Null(ex); 
    }

    [Fact]
    public void SettingReturnValueForPropertiesOne(){
        
        // Arrange
        var  legacySystemProxy = Substitute.For<ILegacySystemProxy>();
        legacySystemProxy.DefaultProduct = new AccountProduct{
            Code = 1,
            Title = "Test Product",
            Description = "Test Product"
        };
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

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
      
        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.Null(ex);
    }

    [Fact]
    public void SettingReturnValueForPropertiesTwo(){
        
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

        var sut = new AccountService(legacySystemProxy, customerValidationService, accountValidationService);
      
        // Act 
        var ex = Record.Exception(() => {
            sut.CreateAccount(customer, AccountType.Individual);
        });

        // Accert
        Assert.Null(ex);
    }
}
