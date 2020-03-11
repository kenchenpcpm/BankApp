using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum TypeOfAccounts
    {
        Checking,
        Savings,
        CD,
        Loan,
    }
    /// <summary>
    /// This represent a bank account
    /// where you can withdraw or deposit
    /// money into the account
    /// </summary>
    class Account
    {        
        #region Properties
        /// <summary>
        /// Unique account number
        /// </summary>
        #endregion
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get; private set; }
       
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        #region Constructor
        public Account()
        {
            CreatedDate = DateTime.UtcNow;
        }
        #endregion



        #region Methods
        /// <summary>
        /// Deposit money into account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount; 
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new ArgumentOutOfRangeException("amount", "InSufficient funds!");
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}
