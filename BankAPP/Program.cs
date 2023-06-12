
using BankAPP;
using Microsoft.Extensions.DependencyInjection;
using BankAPP.Implementation;
using BankAPP.Interfaces;
using BankAPP.Implementation.Customer_IM;
using BankAPP.Interfaces.Account_Interface;
using BankAPP.Interfaces.Customer_Interface;
using BankAPP.Implementation.Account_IM;

var services = new ServiceCollection();
services.AddScoped<IRegisterCustomer, RegisterCustomer>();
services.AddScoped<ICreateAccount, CreateAccount>();
services.AddScoped<IMySelection, MySelection>();
services.AddScoped<ILogin, Login>();
services.AddScoped<IDeposit, Deposit>();
services.AddScoped<IAccountDetails, AccountDetails>();
services.AddScoped<IWithdraw, Withdraw>();
services.AddScoped<ITransfer, Transfer>();
services.AddScoped<IBalanceChecker, BalanceChecker>();


services.AddSingleton<HomePage>(); 

var serviceProvider = services.BuildServiceProvider();

var home = serviceProvider.GetRequiredService<HomePage>();

home.MyHomePage();
