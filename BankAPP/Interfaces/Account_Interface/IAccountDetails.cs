﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPP.Interfaces.Account_Interface
{
    public interface IAccountDetails
    {
        void Details(Customer loggedInCustomer);
    }
}
