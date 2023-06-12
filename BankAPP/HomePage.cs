using BankAPP.Interfaces;
using BankAPP.Implementation;
using BankAPP.Interfaces.Customer_Interface;

namespace BankAPP
{
    internal class HomePage 
    {
        private readonly IRegisterCustomer _reg;
        private readonly ILogin _log;
        public HomePage(IRegisterCustomer reg, ILogin log)
        {
            _reg = reg;
            _log = log;
        }

        Validation _validation = new();
        public void MyHomePage()
        {
            string collectInput;
            do
            {
               
                Console.WriteLine("\nWelcome to W@P ENterprise\n");
                Console.Write("Press 1 to Register a Customer, 2 to login or Q to Exit: "); 
                collectInput = Console.ReadLine()!;
                if (collectInput.ToUpper() == "1")
                {
                    _reg.RegisterACustomer();
                    MyHomePage();
                }
                else if (collectInput == "2")
                {
                    _log.LoginMe();
                }
                else if (collectInput.ToLower() == "q")
                {
                    Console.Clear();
                    Console.WriteLine("Bye now!!");
                    Environment.Exit(0);    
                }else
                {
                    Console.WriteLine("You've not entered a correct input.");
                    Console.ReadKey();
                }

            }
            while(!_validation.InitialPromptValidation(collectInput.ToUpper()));
           
        }

        // Logout ------------------------------
        public void LogOut()
        {
            //AfterAccountCreationPrompt();
        }

    }
}
