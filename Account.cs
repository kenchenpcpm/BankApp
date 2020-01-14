using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    /// <summary>
    /// This represent a bank account
    /// where you can withdraw or deposit
    /// money into the account
    /// </summary>
    class Account
    {
        private int lastAccountNumber = 0;

        #region Constructor
        public Account()
        {
            //lastAccountNumber += 1;
            AccountNumber = ++lastAccountNumber;
        }   
        #endregion
        #region Properties
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; private set; }
       
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
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
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}
