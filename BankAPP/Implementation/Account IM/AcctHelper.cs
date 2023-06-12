using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPP.Implementation.Account_IM
{
    internal class AcctHelper
    {
        public static List<Account> ReadAccountFromFile(string filePath)
        {
            List<Account> accounts = new();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split('|');

                        if (fields.Length >= 5)
                        {
                            string id = fields[1].Trim();
                            string name = fields[2].Trim();
                            string AccNo = fields[3].Trim();
                            string AccType = fields[4].Trim();
                            decimal Bal = decimal.Parse(fields[5].Trim());

                            Account account = new(id, name,AccNo,AccType,Bal);
                            accounts.Add(account);
                        }
                    }
                }
            }

            return accounts;
        }
    }
}
