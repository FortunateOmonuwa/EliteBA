using EliteBA.DB;
using EliteBA.Models;
using EliteBA.DTO;


namespace EliteBA.Operations;

public class AccountOperations
{
    /**
   * This method handles the generation of account numbers.
   * The method generates a random 10 digits string and compares with existing accounts list to ensure it is unique.
   * Returns the generated 10 digits (string)
   */
    private static string GenerateAccountNumber()
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
            return 0.00;
        }
    } 
    
    /// <summary>
    /// This Method creates a new bank account using the details provided in the CreateAccountDto.
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    internal static Account CreateAccount(CreateAccountDto dto)
    {
        var accountNumber = GenerateAccountNumber();

        //This converts the accountType string to enum
        AccountType parsedAccountType = (AccountType)Enum.Parse(typeof(AccountType), dto.accountType, true);
        var account = new Account
        {
            AccountName = $"{dto.lastname} {dto.firstname}",
            AccountType = parsedAccountType,
            AccountNumber = accountNumber
        };
        //Now we add our object to the account List
        Tables.accounts.Add(account);
        return account;
    }
}