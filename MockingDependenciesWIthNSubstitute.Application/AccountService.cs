using System.Runtime.InteropServices.Marshalling;
using MockingDependenciesWIthNSubstitute.Application.Interfaces;

namespace MockingDependenciesWIthNSubstitute.Application;

public class AccountService : IAccountService
{
   private ILegacySystemProxy _legacySystemProxy;
   private ICustomerValidationService _customerValidationService;
   private IAccountValidationService _accountValidationService;
    public AccountService(ILegacySystemProxy legacySystemProxy, ICustomerValidationService customerValidationService, IAccountValidationService accountValidationService)
    {
        _legacySystemProxy = legacySystemProxy;
        _customerValidationService = customerValidationService;
        _accountValidationService = accountValidationService;
    }

    public Account CreateAccount(Customer customer, AccountType accountType){

       Account account =   new Account();
       var isCustomerValid =  _customerValidationService.ValidateCustomer(customer);
       if(isCustomerValid)
       {
            account = _legacySystemProxy.CreateAccount(customer, accountType);
       }
       else 
       {
            ProcessInvalidCustomer(customer);
       }
       return account;
    }

    public Account GetAccount(int accountNumber){

        var isAccountValid = _accountValidationService.ValidateAccount(accountNumber);
        if(!isAccountValid){
            ProcessInvalidAccount(accountNumber);
        }

        return _legacySystemProxy.GetAccount(accountNumber);
    }

    public void ProcessInvalidCustomer(Customer customer){
        throw new Exception($"Customer {customer.FirstName}, {customer.LastName} is invalid");
    }

    public void ProcessInvalidAccount(int accountNumber)
    {
        throw new Exception($"Account number {accountNumber} is invalid.");
    }
}
