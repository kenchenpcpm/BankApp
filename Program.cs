using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*var myAccount = new Account();            
            myAccount.AccountName = "My account";
            myAccount.AccountType = TypeOfAccounts.Checking;            
            myAccount.Deposit(1001);*/
            var myAccount = Bank.CreateAccount(
                "My checking",
                "test@test.com",
                TypeOfAccounts.Savings, 100);
            Console.WriteLine($"Account Number: {myAccount.AccountNumber}, Balance: {myAccount.Balance}, Created Date: {myAccount.CreatedDate}, AT:{myAccount.AccountType}, Email Address:{myAccount.EmailAddress}");


            
        }
    }
}
