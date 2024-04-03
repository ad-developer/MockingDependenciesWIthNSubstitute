namespace MockingDependenciesWIthNSubstitute.Application;

public class LegacySystemProxy : ILegacySystemProxy
{
    public Account CreateAccount(Customer customer){
        return new Account();
     }

     public Account GetAccount(int accountNumber){
        return new Account();
     }
}
