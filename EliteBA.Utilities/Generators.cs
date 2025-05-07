namespace EliteBA.Utilities;

public class Generators
{
    private static int _accountIdCounter;
    private static int _customerIdCounter;
    private static int _transactionIdCounter;

    /**
     * This method handles the generation of account Ids.
     * This would be our unique identifier for each account created.
     * The method increments the Account.AccountId by 1 for each account created.
     * It returns the generated id (int).
     */
    public static int GenerateAccountId() => _accountIdCounter++;

    /**
     * This method handles the generation of customer Ids.
     * This would be our unique identifier for each customer created.
     * The method increments the Customer.CustomerId by 1 for each customer created.
     * Returns the generated id (int)
     */
    public static int GenerateCustomerId() => _customerIdCounter++;

    /**
     * This method handles the generation of transaction Ids.
     * This would be our unique identifier for each transaction created.
     * The method increments the Transaction.TransactionId by 1 for each transaction created.
     * Returns the generated id (int)
     */
    public static int GenerateTransactionId() => _transactionIdCounter++;
}