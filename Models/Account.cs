using EliteBA.Models;

namespace EliTEBA.Models;

public class Account
{
    List<Account> accounts = [];
    List<Customer> customers = [];
    public int AccountId { get; set; }
    public required string AccountNumber { get; set; }
    public required string AccountName { get; set; }
    public AccountType AccountType { get; set; }
    public double Balance { get; set; } = 0.00;
    public DateTime DateOpened { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public List<Transaction> Transactions { get; set; } = [];


    public class AccountCreationDTO
    {
        public required string AccountNumber { get; set; }
        public required string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
    public class AccountRetrievalDTO
    {

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }
        public string AccountStatus { get; set; }
    }


    public void CreateAccount(AccountCreationDTO newAcc)
    {
        var newAccount = new Account
        {
            AccountId = Generators.GenerateAccountId(),
            AccountName = newAcc.AccountName,
            AccountNumber = newAcc.AccountNumber,
            Balance = newAcc.Balance,
            AccountType = newAcc.AccountType,
            AccountStatus = newAcc.AccountStatus,
        };

        accounts.Add(newAccount);
    }

    public AccountRetrievalDTO GetSpecificAccount(string accountNumber = default, string email = default, string phoneNumber = default)
    {
        Account account;
        AccountRetrievalDTO accDto = new AccountRetrievalDTO();
        if (string.IsNullOrEmpty(accountNumber) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber))
        {
            Console.WriteLine("Wetin dey do you");
        }
        else if (!string.IsNullOrEmpty(accountNumber))
        {
            account = accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);

            accDto = MapAccount(account);
            return accDto;
        }
        else if (string.IsNullOrEmpty(accountNumber) && !string.IsNullOrEmpty(email))
        {
            var customerScc = customers.SingleOrDefault(x => x.Email == email);
            account = accounts.SingleOrDefault(x => x.AccountId == customerScc.AccountId);
            //account = customerScc.Account;

            accDto = MapAccount(account);
            return accDto;
        }
        return accDto ;

    }

    public List<AccountRetrievalDTO> GetAllAccounts()
    {
         var customerAccs = accounts.ToList();
        List<AccountRetrievalDTO> accs = [];
        foreach(var account in customerAccs)
        {
            var mappedAcc = MapAccount(account);
            accs.Add(mappedAcc);
        }

        return accs;
    }

    private AccountRetrievalDTO MapAccount(Account account)
    {
        

        var mappedAccount = new AccountRetrievalDTO
        {
            AccountName = account.AccountName,
            AccountNumber = account.AccountNumber,
            Balance = account.Balance,
            AccountId = account.AccountId,
            //AccountStatus = GetAccountStatus(account)
        };

        return mappedAccount;
    }
}

    //private string GetAccountStatus(Account account)
    //{
    //    if(account.AccountStatus == 0)
    //    {
    //        return "Active";   
    //    }
    //    else if(account.AccountStatus == 1)
    //    {
    //        return "Dormant";
    //    }
    //    else if (account.AccountStatus == 2)
    //    {
    //        return "Frozen";
    //    }
    //    else
    //    {
    //        return "Closed";
    //    }
    //}




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