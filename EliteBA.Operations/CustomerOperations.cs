using EliteBA.Models;
using EliteBA.Utilities;
using EliteBA.Models;
using EliteBA.DB;

namespace EliteBA.Operations;

public class CustomerOperations
{

    private AccountOperations accountOperations = new AccountOperations();

    
    public Customer CreateCustomerAccount (string firstname, string lastname, string PhoneNo, string email, string address, string accountType = "Savings")
    {
        var customerid = Generators.GenerateCustomerId();

        var customer = new Customer
        {
            FirstName = firstname,
            LastName = lastname,
            PhoneNumber = PhoneNo,
            Email = email,
            Address = address,
        };
        //Creating an account for our cutomer we just created
        var dto = new AccountOperations.CreateAccountDto(customer.FirstName, customer.LastName, accountType);
        var account = accountOperations.CreateAccount(dto);
        //Now having created a Customer and an account for Him/her, we now link the customer and account together
        customer.Account = account;
        //Adding this customer (object) to our database (List)
        Tables.customers.Add(customer);
        return customer;
    }


}