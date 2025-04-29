using System.Transactions;
using EliteBA.DB;
using EliteBA.Models;

using ELITEBA.DTOs;
using Transaction = EliteBA.Models.Transaction;


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
        return null;

    }
   
 }
        
    