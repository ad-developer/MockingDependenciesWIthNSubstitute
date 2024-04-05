using System.Diagnostics;
using MockingDependenciesWIthNSubstitute.Application.Interfaces;

namespace MockingDependenciesWIthNSubstitute.Application;

public class LegacySystemProxy : ILegacySystemProxy
{
   public AccountProduct DefaultProduct { get; set; } = new  AccountProduct{
      Code = 5,
      Description = "CD",
      Title = "CD"
   };
    public Account CreateAccount(Customer customer, AccountType accountType){
         var accountProduct =  new AccountProduct{
            Code = 5,
            Description = "CD",
            Title = "CD"
         };

         var accountProductList = new List<AccountProduct>();
         accountProductList.Add(accountProduct);

        return new Account{
         AccountType = accountType,
         Customer = customer,
         Id = 223432,
         Products = accountProductList
        };
     }

     public Account GetAccount(int accountNumber){
        return new Account();
     }
}
