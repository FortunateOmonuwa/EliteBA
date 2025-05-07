using EliteBA.Models;
using EliteBA.Utilities;
using EliteBA.DB;
using EliteBA.DTO;

namespace EliteBA.Operations;
public class CustomerOperations
{
    /// <summary>
    /// This Method registers a new Customer and automatically creates a bank account for them.
    /// </summary>
    /// <param name="CreateCustomerdto"></param>
    /// <returns></returns>
    public Customer CreateCustomerAccount (CreateCustomerAccountDto CreateCustomerdto)
    {
        var customerid = Generators.GenerateCustomerId();

        var customer = new Customer
        {
            FirstName = CreateCustomerdto.firstname,
            LastName = CreateCustomerdto.lastname,
            PhoneNumber = CreateCustomerdto.PhoneNo,
            Email = CreateCustomerdto.email,
            Address = CreateCustomerdto.address,
        };
        //Creating an account for our cutomer we just created
        var dto = new CreateAccountDto(customer.FirstName, customer.LastName, CreateCustomerdto.accountType);
        var account = AccountOperations.CreateAccount(dto);
        //Now having created a Customer and an account for Him/her, we now link the customer and account together
        customer.Account = account;
        //Adding this customer (object) to our database (List)
        Tables.customers.Add(customer);
        return customer;
    }
}