//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BankAPP.Implementation.Account_IM
//{
//    public class AcctStatement : Helper
//    {
//        private string AccountToGenerateStatement { get; set; }

//        public void GenerateAccountStatements(Customer loggedInCustomer)
//        {
//            Console.Clear();
//            List<Account> allAccounts = ReadAccountFromFile("Accounts.txt");


//            List<Account> loggedInUserAccounts = allAccounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();

//            Console.Write("Enter the account number to generate the statement: ");
//            AccountToGenerateStatement = Console.ReadLine();

//            Account selectedAccount = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToGenerateStatement);

//            if (selectedAccount != null)
//            {
//                Console.WriteLine($"\nAccount Statement for Account Number: {selectedAccount.AccountNumber}");
//                Console.WriteLine($"Customer Name: {selectedAccount.Fullname}");
//                Console.WriteLine("-----------------------------------------------------");
//                Console.WriteLine("Date\t\tDescription\t\tAmount");
//                Console.WriteLine("-----------------------------------------------------");

//                foreach (var transaction in selectedAccount.Transactions)
//                {
//                    Console.WriteLine($"{transaction.Date}\t{transaction.Description}\t\t{transaction.Amount}");
//                }

//                Console.WriteLine("-----------------------------------------------------");
//            }
//            else
//            {
//                Console.WriteLine("\nInvalid account number. Please try again.");
//            }
//        }

//    }
//}
