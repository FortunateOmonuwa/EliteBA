using EliteBA.Models;

namespace EliteBA.Operations;

public class BankOperations
{
    public double GetAccountBalance(string accountNumberToCheck)
    {
        AccountOperations accountOps = new AccountOperations();
        double balance = accountOps.ViewAccountBalance(accountNumberToCheck);
        return balance;
    }
}