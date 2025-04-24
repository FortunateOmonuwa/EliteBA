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

    public List<Account> Accounts { get; set; } = [];

    public class AccountDetails {

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public AccountType AccountType { get; set; }

    }

    public AccountDetails GetAccountDetails(string accountNumber) 
    {
     AccountDetails accountDetails = new AccountDetails();

        Account account;

        if(string.IsNullOrEmpty(accountNumber))
        {
            Console.WriteLine("Please enter account Number");
        }

        else 
        {
            account = Accounts.SingleOrDefault(acct => acct.AccountNumber == accountNumber);

            if (!string.IsNullOrEmpty(account?.AccountNumber))
            {
                accountDetails.AccountId = account.AccountId;
                accountDetails.AccountNumber = account.AccountNumber;
                accountDetails.AccountName = account.AccountName;
                accountDetails.AccountStatus = account.AccountStatus;
                accountDetails.AccountType = account.AccountType;
                accountDetails.Balance = account.Balance;
            }
           
        }

            return accountDetails;
    }
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