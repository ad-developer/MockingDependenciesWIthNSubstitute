namespace MockingDependenciesWIthNSubstitute.Application;

public class CustomerValidationService : ICustomerValidationService
{
    public bool ValidateCustomer(Customer customer){
        return true;
    }
}
