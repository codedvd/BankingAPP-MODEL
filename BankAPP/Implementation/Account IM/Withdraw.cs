﻿using BankAPP.Interfaces.Account_Interface;

namespace BankAPP.Implementation.Account_IM
{
    internal class Withdraw : AcctHelper, IWithdraw
    {
        private string? AmountToWithdraw { get; set; }
        private string? AccountToWithdrawFrom { get; set; }
        private decimal CleanAmountToWithdraw { get; set; }

        public void WithdrawMoney(Customer LoggedInCustomer)
        {
            Console.Clear();
            List<Account> allAccounts = ReadAccountFromFile("Accounts.txt");

            Console.Write("Enter the account number you want to WithDraw from>> ");
            AccountToWithdrawFrom = Console.ReadLine();

            Console.Write("Enter the amount you want to Withdraw>> ");
            AmountToWithdraw = Console.ReadLine();
            CleanAmountToWithdraw = decimal.Parse(AmountToWithdraw);

            List<Account> loggedInUserAccounts = allAccounts.Where(account => account.Customerid == LoggedInCustomer.CustomerId).ToList();

            Account? accountToUpdate = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToWithdrawFrom);

            if (accountToUpdate is null)
            {
                Console.Clear();
                Console.WriteLine("\n\nThe account entered does not exist!\nPlease enter a valid account number\n");
            }
            else if (accountToUpdate.AccountType == "savings" && accountToUpdate.Balance < 1001)
            {
                Console.Clear();
                Console.WriteLine("\n\nUnable to withdraw. There should be a minimum of 1000 naira in your savings account \n");

            }
            else if (accountToUpdate.Balance < CleanAmountToWithdraw)
            {
                Console.Clear();
                Console.WriteLine("\n\nInsufficient Funds!, Kindly try a lesser amount.\n");

            }
            else if (accountToUpdate.Balance < 1)
            {
                Console.Clear();
                Console.WriteLine("\n\nInsufficient Funds!.\n");

            }
            else
            {
           
                accountToUpdate.Balance -= CleanAmountToWithdraw;
                Console.WriteLine($"\nYou have successfully withdrawn {CleanAmountToWithdraw} from your account with account number {AccountToWithdrawFrom}");
                Console.ReadKey();
            }

            // Update the Account.txt file with the new balance
            using (StreamWriter writer = new StreamWriter("Accounts.txt"))
            {
                foreach (Account account in allAccounts)
                {
                    writer.WriteLine($"| {account.Customerid,-12} | {account.Fullname,-12} | {account.AccountNumber,-12} | {account.AccountType,-8} | {account.Balance} |");
                }
            }

        }
    }
}
