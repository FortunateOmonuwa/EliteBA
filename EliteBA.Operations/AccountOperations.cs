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


    //This method will be for Account creation.

    public Account CreateAccount(string firstname, string lastname, string accountType)
    {
        var accountNumber = GenerateAccountNumber();

        //This converts the accountType string to enum
        AccountType parsedAccountType = (AccountType)Enum.Parse(typeof(AccountType), accountType, true);

        var account = new Account
        {
            AccountName = $"{lastname} {firstname}",
            AccountType = parsedAccountType,
            AccountNumber = accountNumber
        };


        //Now we add our object to the account List
        Tables.accounts.Add(account);

        return account;
    
    }

}