using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAPP.Implementation
{
    public class TransactionRecords
    {
        public string Description { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime GetDateTime { get; set; }


        //private static List<Account> ReadAccountFromFile(string filename)
        //{
        //    List<Account> accounts = new List<Account>();
        //    using (StreamReader reader = new StreamReader(filename))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            string[] parts = line.Split('|').Select(part => part.Trim()).ToArray();
        //            if (parts.Length == 5)
        //            {
        //                Account account = new Account
        //                {
        //                    Customerid = parts[0],
        //                    Fullname = parts[1],
        //                    AccountNumber = parts[2],
        //                    AccountType = parts[3],
        //                    Balance = decimal.Parse(parts[4]),
        //                    Transactions = new List<Transaction>()
        //                };
        //                accounts.Add(account);
        //            }
        //        }
        //    }
        //    return accounts;
        //}

        //public static List<Account> ReadAccountFromFile(string filePath)
        //{
        //    List<Account> accounts = new();

        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        string? line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            if (!string.IsNullOrWhiteSpace(line))
        //            {
        //                string[] fields = line.Split('|');

        //                if (fields.Length >= 5)
        //                {
        //                    string id = fields[1].Trim();
        //                    string name = fields[2].Trim();
        //                    string AccNo = fields[3].Trim();
        //                    string AccType = fields[4].Trim();
        //                    decimal Bal = decimal.Parse(fields[5].Trim());

        //                    Account account = new(id, name, AccNo, AccType, Bal);
        //                    accounts.Add(account);
        //                }
        //            }
        //        }
        //    }

        //    return accounts;
        //}

    }
}
