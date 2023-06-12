using System.Threading.Tasks;
using BankAPP.Interfaces.Customer_Interface;

namespace BankAPP.Implementation.Customer_IM
{
    internal class Login : Helper, ILogin
    {
        private readonly IMySelection _mySelection;
        public Login(IMySelection mySelection)
        {
            _mySelection = mySelection;
        }

        public void LoginMe()
        {
            var allcustomers = ReadCustomersFromFile("Customers.txt");
            var e = Email();
            var p = Password();
            var loggedInUser = allcustomers.FirstOrDefault(c => c.Email == e && c.Password == p);
            if (loggedInUser != null)
            {
                Console.WriteLine("congrats, you are logged in!");
                _mySelection.MyDashBoard(loggedInUser);
            }
            else
            {
                Console.WriteLine("Invalid credentials\n Try again");
            }

        }
    }
}
