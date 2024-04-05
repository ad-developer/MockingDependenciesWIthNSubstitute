namespace MockingDependenciesWIthNSubstitute.Application;

public interface IAccountService
{
    Account CreateAccount(Customer customer, AccountType accountType);
    Account GetAccount(int accountNumber);
}
