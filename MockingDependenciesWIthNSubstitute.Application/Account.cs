namespace MockingDependenciesWIthNSubstitute.Application;

public record Account
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public AccountType AccountType { get; set; }
    public List<AccountProduct> Products { get; set; }
}
