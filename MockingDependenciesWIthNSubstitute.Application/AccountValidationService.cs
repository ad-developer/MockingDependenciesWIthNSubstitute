namespace MockingDependenciesWIthNSubstitute.Application;

public class AccountValidationService : IAccountValidationService
{
    public bool ValidateAccount(int accountNumber){
        return true;
    }
}
