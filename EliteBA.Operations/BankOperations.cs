using EliteBA.Models;

namespace EliteBA.Operations;

public class BankOperations
{
    private AccountOperations accountOps = new AccountOperations();
    private CustomerOperations cusOps = new CustomerOperations();
    public string BlockAccount(string accountNumber) 
    {
       string accClosed = cusOps.CloseCustomerAccount(accountNumber);
        return accClosed;
    }
    public double GetAccountBalance(string accountNumberToCheck)
    {
        double balance = accountOps.ViewAccountBalance(accountNumberToCheck);
        return balance;
    }
}