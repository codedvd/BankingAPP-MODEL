using BankAPP.Interfaces.Account_Interface;

namespace BankAPP.Implementation.Account_IM
{
    internal class Transfer : AcctHelper, ITransfer
    {
        private string? AccountToTransferTo { get; set; }
        private string? AccountToTransferFrom { get; set; }
        private decimal CleanAmountToTransfer { get; set; }


        public void TransferMoney(Customer loggedInCustomer)
        {
            Console.Clear();
            List<Account> allAccounts = ReadAccountFromFile("Accounts.txt");

            List<Account> loggedInUserAccounts = allAccounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();

            Console.Write("\nEnter the account number you want to transfer from: ");
            AccountToTransferFrom = Console.ReadLine();

            Console.Write("Enter the account you want to transfer to:>> ");
            AccountToTransferTo = Console.ReadLine();

            Console.Write("Enter the amount you want to transfer:>> ");
            string? AmountToTransfer = Console.ReadLine();

            CleanAmountToTransfer = decimal.Parse(AmountToTransfer);

            Account? giver = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferFrom);
            Account? receiver = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferTo);

            // Logic
            if (giver != null && receiver != null && giver.AccountType == "savings" && giver.Balance > CleanAmountToTransfer + 1000)
            {
                giver.Balance -= CleanAmountToTransfer;
                receiver.Balance += CleanAmountToTransfer;
                Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
                Console.ReadKey();
            }
            else if (giver != null && receiver != null && giver.AccountType == "current" && giver.Balance > CleanAmountToTransfer)
            {
                giver.Balance -= CleanAmountToTransfer;
                receiver.Balance += CleanAmountToTransfer;
                Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n\nError in Transaction!\n\n");
            }
            // Update the Account.txt file with the new objects
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
