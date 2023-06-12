using BankAPP.Interfaces.Account_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPP.Implementation.Account_IM
{
    internal class AccountDetails : AcctHelper, IAccountDetails
    {
        public void Details(Customer loggedInCustomer)
        {
            var allAccounts = ReadAccountFromFile("Accounts.txt");
            var LoggedInUserAccounts = allAccounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();
            
            string display = "";
            foreach (Account accounts in LoggedInUserAccounts)
            {
                display += $"|{accounts.Fullname.PadRight(18),21}  | {accounts.AccountNumber.PadRight(12),16} | {accounts.AccountType.PadRight(13),18} | {accounts.Balance.ToString().PadRight(10),17}|\n";
            }

            //FileStream myfile = new FileStream(, FileMode.Truncate);
            using (StreamWriter writer = new StreamWriter($"{loggedInCustomer.Email}.txt"))
            {
                writer.WriteLine(display);
            }

            Console.WriteLine("\u001b[32m|-------------------------------Your Account Details-------------------------------|\u001b[0m");
            Console.WriteLine("....................................................................................");
            Console.WriteLine("|        FULL NAME      |  ACCOUNT NUMBER  |    ACCOUNT TYPE    |   AMOUNT TYPE    |");
            Console.WriteLine("|                       |                  |                    |                  |");
            Console.WriteLine("....................................................................................");

            using (StreamReader reader = new StreamReader($"{loggedInCustomer.Email}.txt"))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            Console.ReadKey();
        }

    }
}
