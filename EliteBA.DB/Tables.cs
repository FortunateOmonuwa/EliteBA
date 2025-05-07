using EliteBA.Models;
using System.Transactions;
using Transaction = EliteBA.Models.Transaction;

namespace EliteBA.DB
{
    public class Tables
    {
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Customer> customers = new List<Customer>();
        public static List<Account> accounts = new List<Account>();
    }
}
