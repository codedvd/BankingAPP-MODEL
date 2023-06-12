using BankAPP.Interfaces.Account_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPP.Implementation.Account_IM
{
    internal class Deposit : AcctHelper, IDeposit
    {

        public void DepositMoney(Customer loggedInCustomer)
        {
            Validation _validation = new();
            var allAccounts =  ReadAccountFromFile("Accounts.txt");
            var LoggedInUserAccounts = allAccounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();
            
            //here:
            //Create a validation here
            Console.Write("Enter your account number>>");
            string? AccountToDepositTo = Console.ReadLine();

            Console.Write("Enter the amount to deposit>>");
            string? amount = Console.ReadLine();
            decimal CleanAmountToDeposit = decimal.Parse(amount);


            Account? accountToUpdate = LoggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToDepositTo);

            if (accountToUpdate is null)
            {
                Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");
               // goto here;
            }

            if (accountToUpdate != null)
            {
                accountToUpdate.Balance += CleanAmountToDeposit;
                Console.WriteLine($"You have successfully deposited {CleanAmountToDeposit} into your account with account number {AccountToDepositTo}");
                Console.ReadKey();

            }

            // Update the Account.txt file with the new balance
            using (StreamWriter writer = new StreamWriter("Accounts.txt"))
            {
                foreach (var account in allAccounts)
                {
                    writer.WriteLine($"| {account.Customerid,-12} | {account.Fullname,-12} | {account.AccountNumber,-12} | {account.AccountType,-8} | {account.Balance} |");
                }
            }
        }
    }
}
