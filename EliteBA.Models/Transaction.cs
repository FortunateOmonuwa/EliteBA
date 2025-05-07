namespace EliteBA.Models;

public class Transaction
{
    public int TransactionId { get; set; }
    public int AccountId { get; set; }
    public TransactionType TransactionType { get; set; }
    public double Amount { get; set; }
    public string? Narration { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsTransfer;

    private int _recipientAccountId;
    public int RecipientAccountId // for transfers only
    {
        get => _recipientAccountId;
        set
        {
            do
            {
                Console.WriteLine("Recipient account ID cannot be zero for transfers");
            } while (IsTransfer && value <= 0);
            _recipientAccountId = value;
        }
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Transfer
}
