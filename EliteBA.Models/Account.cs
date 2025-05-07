namespace EliteBA.Models;

public class Account
{
    public int AccountId { get; set; }
    public string AccountNumber { get; set; }
    public string AccountName { get; set; }
    public AccountType AccountType { get; set; }
    public double Balance { get; set; } = 0.00;
    public DateTime DateOpened { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public List<Transaction> Transactions { get; set; } = [];
}

public enum AccountType
{
    Savings,
    Current
}

public enum AccountStatus
{
    Active,
    Dormant,
    Frozen,
    Closed
}