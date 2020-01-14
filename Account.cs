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
        #region Properties
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }

        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion
    }
}
