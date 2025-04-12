namespace EliteBA.Models;

public class Transaction
{
    public int TransactionId { get; set; }
    public int AccountId { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public double Amount { get; set; }
    public string? Narration { get; set; }
    public DateTime DateCreated { get; set; }

    public int
        RecipientAccountId
    {
        get;
        set;
    } // For transfers (not applicable to deposit and withdrawal) - @EJ, please read up the tutor's review on this. Consult him for proper usage.

    public decimal
        BalanceAfter
    { get; set; } // helper property - e.g. BalanceAfter = Account.Balance + transaction.Amount
}

public enum TransactionTypeEnum
{
    Deposit,
    Withdrawal,
    Transfer
}