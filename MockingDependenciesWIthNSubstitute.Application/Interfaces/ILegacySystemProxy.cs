namespace MockingDependenciesWIthNSubstitute.Application;

public interface ILegacySystemProxy
{
    Account CreateAccount(Customer customer);

    Account GetAccount(int accountNumber);
}
