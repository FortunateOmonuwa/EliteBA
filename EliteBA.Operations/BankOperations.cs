using EliteBA.Models;

namespace EliteBA.Operations;

public class BankOperations
{
    private AccountOperations accountOps = new AccountOperations();
    public double GetAccountBalance(string accountNumberToCheck)
    {
        double balance = accountOps.ViewAccountBalance(accountNumberToCheck);
        return balance;
    }
}