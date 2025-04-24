using EliteBA.Models;
using EliteBA.Utilities;
using EliteBA.Models;

namespace EliteBA.Operations;

public class CustomerOperations
{

    private AccountOperations accountOperations = new AccountOperations();
    

    public Customer CreateCustomerAccount (string firstname, string lastname, string PhoneNo, string Email, string Address, string accountType = "Savings")
    {
        var customerid = Generators.GenerateCustomerId();

        var customer = new Customer
        {

            FirstName = firstname,
            LastName = lastname,
            PhoneNumber = PhoneNo,
            Email = Email,
            Address = Address,


        };



        return customer;
   
    
    
    
    }


}