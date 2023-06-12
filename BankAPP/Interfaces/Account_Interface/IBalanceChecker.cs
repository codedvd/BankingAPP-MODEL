using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPP.Interfaces.Account_Interface
{
    public interface IBalanceChecker
    {
        void CheckAccountBalance(Customer loggedInCustomer);
    }
}
