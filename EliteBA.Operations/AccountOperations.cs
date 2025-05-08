using System.Transactions;
using EliteBA.DB;
using EliteBA.Models;
using EliteBA.DTO;
using Transaction = EliteBA.Models.Transaction;

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

    /// <summary>
    /// Handles transfering of funds from one account to another
    /// </summary>
    /// <param name="transferDetails"></param>
    /// <returns></returns>
    public static string Transfer(TransferDTO transferDetails) 
    {
        var senderAccInput = Tables.accounts.SingleOrDefault(x => x.AccountNumber == transferDetails.senderAcc);
        if (senderAccInput == null) 
        {
            return $"{transferDetails.senderAcc} does not exist";
        }
        var receiverAcc = Tables.accounts.SingleOrDefault(x => x.AccountNumber == transferDetails.receiverAcc);
        if (receiverAcc == null) 
        {
            return $"{transferDetails.receiverAcc} does not exist";
        }
        Transaction trans = new Transaction
        {
            AccountId = senderAccInput.AccountId,
            TransactionType = TransactionType.Transfer,
            Amount = transferDetails.amount,
            Narration = transferDetails.narration,
            DateCreated = DateTime.Now,
        };
        if (senderAccInput.Balance < transferDetails.amount) 
        {
            trans.IsTransfer = false;
            Tables.transactions.Add(trans);
            return $"Insufficient fund";
        }
        senderAccInput.Balance -= transferDetails.amount;
        receiverAcc.Balance +=transferDetails.amount;
        trans.IsTransfer = true;
        Tables.transactions.Add( trans );  
        return "Transfer was succesful";
    }

    /// <summary>
    /// This method handles the viewing of account balance.
    /// </summary>
    /// <param name="accountNumber">The account number of the customer</param>
    /// <returns></returns>
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
    /// <param name="accountDetails"></param>
    /// <returns></returns>
    internal static Account CreateAccount(CreateAccountDto accountDetails)
    {
        var accountNumber = GenerateAccountNumber();

        //This converts the accountType string to enum
        AccountType parsedAccountType = (AccountType)Enum.Parse(typeof(AccountType), accountDetails.accountType, true);
        var account = new Account
        {
            AccountName = $"{accountDetails.lastname} {accountDetails.firstname}",
            AccountType = parsedAccountType,
            AccountNumber = accountNumber
        };
        //Now we add our object to the account List
        Tables.accounts.Add(account);
        return account;
    }

}
