namespace MockingDependenciesWIthNSubstitute.Application.Interfaces;

public interface ILegacySystemProxy
{
    AccountProduct DefaultProduct { get; set; }
    Account CreateAccount(Customer customer, AccountType accountType);
    Account GetAccount(int accountNumber);
}
