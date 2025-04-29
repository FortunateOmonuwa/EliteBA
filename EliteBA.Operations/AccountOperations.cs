using EliteBA.DB;
using EliteBA.Models;
using EliteBA.Utilities;

namespace EliteBA.Operations;

public class AccountOperations
{
    public record TransferDTO(string senderAcc, string receiver, double amount);
    public string Transfer(TransferDTO transferDetails)
    {
        var senderAcc = Tables.accounts.SingleOrDefault(x => x.AccountNumber == transferDetails.senderAcc);
        var receiverAcc = Tables.accounts.SingleOrDefault(x => x.AccountNumber == transferDetails.receiver);

        if(senderAcc == null)
        {
            return $"{transferDetails.senderAcc} does not exist";
        }
        if (receiverAcc == null)
        {
            return $"{transferDetails.receiver} does not exist";
        }
        if(senderAcc.Balance <= 100)
        {
            return $"You account balance is too low for this transaction";
        }

        senderAcc.Balance -= transferDetails.amount;
        receiverAcc.Balance += transferDetails.amount;

        var transcation = new Transaction
        {
            AccountId = senderAcc.AccountId,
            Amount = transferDetails.amount,
            RecipientAccountId = receiverAcc.AccountId,
            DateCreated = DateTime.Now,
            Narration = $"Transfer from {senderAcc.AccountName} to {receiverAcc.AccountName}",
            TransactionId = Generators.GenerateTransactionId(),
            IsTransfer = true,
            TransactionType = TransactionType.Transfer,
        };
        Tables.transactions.Add(transcation );

        return "Transaction successful";  
    }
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
}