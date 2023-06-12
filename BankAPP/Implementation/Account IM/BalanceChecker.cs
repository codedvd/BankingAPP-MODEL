using BankAPP.Interfaces.Account_Interface;


namespace BankAPP.Implementation.Account_IM
{
    internal class BalanceChecker : AcctHelper, IBalanceChecker
    {
        private string? AccountToCheckBalance { get; set; }

        public void CheckAccountBalance(Customer loggedInCustomer)
        {
            Console.Clear();
            List<Account> allAccounts = ReadAccountFromFile("Accounts.txt");

            List<Account> loggedInUserAccounts = allAccounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();

            Console.Write("Enter the account number to check the balance: ");
            AccountToCheckBalance = Console.ReadLine();

            Account selectedAccount = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToCheckBalance)!;

            if (selectedAccount != null)
            {
                Console.Clear();
                Console.WriteLine($"\nAccount Number: {selectedAccount.AccountNumber}");
                Console.WriteLine($"Customer Name: {selectedAccount.Fullname}");
                Console.WriteLine($"Balance: {selectedAccount.Balance}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nInvalid account number. Please try again.");
                Console.ReadKey();
            }
        }
    }
}
