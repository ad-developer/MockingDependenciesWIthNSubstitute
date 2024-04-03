namespace MockingDependenciesWIthNSubstitute.Application.Interfaces;

public interface ILegacySystemProxy
{
    Account CreateAccount(Customer customer);

    Account GetAccount(int accountNumber);
}
