using EliteBA.DB;
using EliteBA.Models;

namespace EliteBA.Operations;

public class AccountOperations
{
    /**
   * This method handles the generation of account numbers.
   * The method generates a random 10 digits string and compares with existing accounts list to ensure it is unique.
   * Returns the generated 10 digits (string)
   */
    private string GenerateAccountNumber()
    {
        Random random = new Random();
        string accountNumber = "";

        do
        {
            for (int i = 0; i < 10; i++) accountNumber += random.Next(0, 9);
        } while (Tables.accounts.Any(account => account.AccountNumber == accountNumber));
        
        return accountNumber;
    }

    public double ViewAccountBalance(string accountNumber)
    {
        var account = Tables.accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

        if (account != null)
        {
            return account.Balance;
        }
        else
        {
            Console.WriteLine($"Account with number {accountNumber} not found.");
            return 0;
        }
    }
}