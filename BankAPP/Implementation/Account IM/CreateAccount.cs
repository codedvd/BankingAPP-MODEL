using System;
using BankAPP.Interfaces.Account_Interface;

namespace BankAPP
{
    public class CreateAccount : ICreateAccount
    {

        public void CreateMyAccount(Customer loggedInCustomer)
        {
            var AccTy = AccType();
            var bal = Bal(AccTy);
            var AccNo = AccountGenerator();

            Account myAccount = new Account(loggedInCustomer.CustomerId,loggedInCustomer.Fullname,AccNo,AccTy,bal);

            using (StreamWriter writer = new StreamWriter("Accounts.txt", true))
            {
                writer.WriteLine($"| {myAccount.Customerid}   |   {myAccount.Fullname}   |   {myAccount.AccountNumber}   |  {myAccount.AccountType}   |  {myAccount.Balance}  | \n\n");
            }
            Console.Clear();
            Console.WriteLine($" Congratulations {loggedInCustomer.Fullname}.\n Your newly created Account has been added to File.");
            Console.ReadKey();
        }



        public string AccType()
        {
            string Acctype = "";
            string readInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Please Select Account Type \n");
                Console.Write("Enter 1 for Savings Account or 2 for Current Account: ");
                readInput = Console.ReadLine()!;
                if (readInput == "1")
                {
                    Acctype = "savings";
                   
                }
                else if (readInput == "2")
                {
                    Acctype = "current";
                }
            }
            while (readInput != "1" && readInput != "2");
            return Acctype;
        }


        public decimal Bal(string accontType)
        {
            decimal amount = 0;
            if (accontType == "savings")
            {
                Console.WriteLine("deposit at least 1000 naira");
                decimal amt = decimal.Parse(Console.ReadLine());
                amount = amt;
            }
            else if(accontType =="current")
            {
                amount = 0;
            }
            return amount;
        }

        public string AccountGenerator()
        {
            Random account = new Random();
            string accountGenerator = account.Next(1000000000, 2000000000).ToString();
            return accountGenerator;
        }
    }
}
