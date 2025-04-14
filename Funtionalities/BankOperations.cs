using System;
using System.Collections.Generic;
using system.Linq;
using EliteBA.Models;

namespace EliteBA.Functionalities
{
	public static class BankOperations
	{
        /* This method find the account with the given account number, and
         * Returns the balance of the found account.
         */
        public static double ViewAccountBalance(List<Account> accounts, string accountNumber)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
           
            return account.Balance;
        }
    }
}

