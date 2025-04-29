using EliteBA.Models;

namespace EliteBA.Operations;

public class BankOperations
{
    /**
     * This method finds the account with the given account number, and
     * Returns the balance of the found account.
     * If the account is not found, it returns -1. (Or you might throw an exception)
     */
    public static double ViewAccountBalance(List<Account> accounts, string accountNumber)
    {
        var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

        if (account != null)
        {
            return account.Balance;
        }
        else
        {
            Console.WriteLine($"Account with number {accountNumber} not found.");
            return 0; // Or throw an exception
        }
    }
}