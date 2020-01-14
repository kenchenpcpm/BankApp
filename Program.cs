using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account();
            //myAccount.AccountNumber = 12456;
            myAccount.AccountName = "Yueer's account";
            //myAccount.Balance = 1000000000000;
            myAccount.Deposit(1001);
            Console.WriteLine($"Account Number: {myAccount.AccountNumber}, Balance: {myAccount.Balance}, Created Date: {myAccount.CreatedDate}");


            var myAccount2 = new Account();
            Console.WriteLine($"Account Number: {myAccount2.AccountNumber}, Balance: {myAccount2.Balance}, Created Date: {myAccount2.CreatedDate}");
        }
    }
}
