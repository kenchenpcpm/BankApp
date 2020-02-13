using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();

        /// <summary>
        /// Creates an account in the bank
        /// </summary>
        /// <param name="accountName">Name of your account</param>
        /// <param name="emailAddress">Email address associated with the account</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="initialDeposit">Initial deposit</param>
        /// <returns></returns>
        public static Account CreateAccount(
            string accountName, 
            string emailAddress,
            TypeOfAccounts accountType = TypeOfAccounts.Checking,
            decimal initialDeposit = 0)
        {
            //Object initialization
            var account = new Account()
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
                createTransaction(initialDeposit, account.AccountNumber,
                    TypeOfTransaction.Credit, "Initial Deposit");
            }
        

            accounts.Add(account);
            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber); 
            if (account == null)
            {
                //Exception handling here
                return;
            }

            account.Deposit(amount);
            createTransaction(amount, accountNumber, TypeOfTransaction.Credit, "Bank Deposit");
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //Exception handling here
                return;
            }

            account.Withdraw(amount);
            createTransaction(amount, accountNumber, TypeOfTransaction.Debit, "Bank Withdrawal");
        }

        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);

        }

        public static IEnumerable<Transaction> GetAllTransactionByAccountNumber (int accountNumber)
        {
            return transactions.Where(t => t.AccountNumber == accountNumber)
                .OrderByDescending(t => t.TransactionDate);
        }

        private static void createTransaction(decimal amount,
            int accountNumber,
            TypeOfTransaction transactionType,
            string description = "")
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                Description = description,
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = transactionType
            };
            transactions.Add(transaction);
        }

    }
}
