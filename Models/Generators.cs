using EliTEBA.Models;

namespace EliteBA.Models;

public class Generators
{
    private static int _accountIdCounter;
    private static int _customerIdCounter;
    private static int _transactionIdCounter;
    private static readonly Random _random = new Random();

    /*
     * This method handles the generation of account Ids.
     * This would be our unique identifier for each account created.
     * The method increments the Account.AccountId by 1 for each account created.
     * It returns the generated id (int).
     */
    public static int GenerateAccountId() => _accountIdCounter++;

    /*
     * This method handles the generation of customer Ids.
     * This would be our unique identifier for each customer created.
     * The method increments the Customer.CustomerId by 1 for each customer created.
     * Returns the generated id (int)
     */
    public static int GenerateCustomerId() => _customerIdCounter++;

    /*
     * This method handles the generation of transaction Ids.
     * This would be our unique identifier for each transaction created.
     * The method increments the Transaction.TransactionId by 1 for each transaction created.
     * Returns the generated id (int)
     */
    public static int GenerateTransactionId() => _transactionIdCounter++;

    /*
     * This method handles the generation of account numbers.
     * The method generates a random 10 digits string and compares with existing accounts list to ensure it is unique.
     * Returns the generated 10 digits (string)
     */

    public static string GenerateAccountNumber(List<Account> existingAccounts)
    {
        string number;
        do
        {
            number = _random.Next(0, 999999999).ToString("10D");
        } while (existingAccounts.Any(account => account.AccountNumber == number));

        return number;
    }


    /* This method find the account with the given account number, and
     * Returns the balance of the found account.
     */
    pubblic static double ViewAccountBalance(List<Account> accounts, string accountNumber)
    {
        var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
        return account.Balance;
    }
}