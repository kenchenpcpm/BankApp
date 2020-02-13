using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********");
            Console.WriteLine("Welcome to my bank!");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View all accounts");
                Console.WriteLine("5. View all transcation");

                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Account name: ");
                        var accountName = Console.ReadLine();

                        Console.WriteLine("Email Address: ");
                        var emailAddress = Console.ReadLine();

                        Console.WriteLine("Select an account type: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        //var accountType = (TypeOfAccounts)Enum.Parse(typeof(TypeOfAccounts), Console.ReadLine());
                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());

                        Console.WriteLine("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(accountName, emailAddress,
                            accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}," +
                            $" AName: {account.AccountName}," +
                            $"Balance: {account.Balance:C}," +
                            $" CD: {account.CreatedDate}," +
                            $" EA: {account.EmailAddress} , AT:{account.AccountType}");

                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit completed!");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, amount);
                        Console.WriteLine("Withdrawl completed!");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactionByAccountNumber(accountNumber);
                        foreach(var transaction in transactions)
                        {
                            Console.WriteLine($"TD: {transaction.TransactionDate}," +
                                $"TA: {transaction.Amount}," +
                                $"TT: {transaction.TransactionType}");
                                
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try agian!");
                        break;

                }
            }

        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var email = Console.ReadLine();
            var accounts = Bank.GetAllAccountsByEmailAddress(email);
            foreach (var a in accounts)
            {
                Console.WriteLine($"AN: {a.AccountNumber}," +
               $" AName: {a.AccountName}," +
               $"Balance: {a.Balance:C}," +
               $" CD: {a.CreatedDate}," +
               $" EA: {a.EmailAddress} , AT:{a.AccountType}");
            }
        }
    }
}
