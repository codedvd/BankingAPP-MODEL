using BankAPP.Implementation.Account_IM;
using BankAPP.Interfaces;
using BankAPP.Interfaces.Account_Interface;
using BankAPP.Interfaces.Customer_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPP
{
    public class MySelection : IMySelection
    {
        private readonly IAccountDetails _accountDetails;
        private readonly ICreateAccount _createAcc;
        private readonly IDeposit _deposit;
        private readonly IWithdraw _withdraw;
        private readonly ITransfer _transfer;
        private readonly IBalanceChecker _balanceChecker;
        public MySelection( ICreateAccount createAcc, IDeposit deposit, IAccountDetails accountDetails, IWithdraw withdraw, ITransfer transfer, IBalanceChecker balanceChecker)
        {
            _createAcc = createAcc;
            _deposit = deposit;
            _accountDetails = accountDetails;
            _withdraw = withdraw;
            _transfer = transfer;
            _balanceChecker = balanceChecker;
        }
        Validation _validation = new();
        public void MyDashBoard(Customer loggedInCustomer)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {loggedInCustomer.Fullname} ");
            string choice = "";
            do
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter the corresponding value for your operation\n");
                Console.ResetColor();
                Console.Write(">>C: Create Account number\n>>3: Deposit\n>>4: Withdrawal\n>>5: Transfer\n>>6: Check Balance\n>>7: " +
                    "Display Account Details\n>>8: Get Account Statement\n>>9: Log Out\n>>Q: To Quit\n\nEnter Your Choice: ");
                choice = Console.ReadLine().ToUpper();
            } while (!_validation.Prompt(choice.ToUpper()));
 
            switch (choice)
            {
                case "3":
                    Console.Clear();
                     _deposit.DepositMoney(loggedInCustomer);
                     MyDashBoard(loggedInCustomer);
                     break;
                case "4":
                    Console.Clear();
                    _withdraw.WithdrawMoney(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                    break;
                case "5":
                    Console.Clear();
                    _transfer.TransferMoney(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                    break;
                case "6":
                    Console.Clear();
                    _balanceChecker.CheckAccountBalance(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                    break;
                case "7":
                    Console.Clear();
                    _accountDetails.Details(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                    break;
                case "8":
                    Console.Clear();
                    // _accountServices.GetStatment();
                     MyDashBoard(loggedInCustomer);
                    break;
                case "9":
                    Console.Clear();
                   // LogOut
                    break;
                case "C":
                    Console.Clear();
                    _createAcc.CreateMyAccount(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Incorrect Input, Try again!!");
                    MyDashBoard(loggedInCustomer);
                break;
            }
        }

    }
}
