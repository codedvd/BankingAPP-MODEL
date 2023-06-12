using BankAPP.Interfaces;
using BankAPP;

namespace BankAPP.Implementation
{
    public class Helper
    {

        Validation _validation = new();
 
        public string _FirstName { get; set; } = string.Empty;
        public string _LastName { get; set; } = string.Empty;
        public  string _Email { get; set; } = string.Empty;
        public  string _Password { get; set; } = string.Empty;


        public string FirstName()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nName must start with a Capital Letter!\n");
                Console.ResetColor();
                Console.Write("Enter First Name:\n");
                _FirstName = Console.ReadLine()!;
            }
            while (!_validation.NameValidation(_FirstName));
            return _FirstName;

        }

        public string LastName()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nName must start with a Capital Letter!\n");
                Console.ResetColor();
                Console.Write("Enter Last Name:\n");
                _LastName = Console.ReadLine()!;
            }
            while (!_validation.NameValidation(_LastName));
            return _LastName;
        }


        public string FullName()
        {
            var f = FirstName();
            var l = LastName();
            return $"{f} {l}";

        }


        public string CustomerId()
        {
            Random random = new Random();
            var cus_id = random.Next(1, 2099999999);
            var cusId = cus_id.ToString();
            return cusId;
        }


        public string Email()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEnter a Valid Email Format!\n");
                Console.ResetColor();
                _Email = Console.ReadLine()!;
            }
            while (!_validation.EmailValidation(_Email));
            return _Email;
        }


        public string Password()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPassword must be 6 character with at least 1 special charater and 1 digt!\n");
                Console.ResetColor();
                Console.Write("Create Your Password:\n");
                _Password = Console.ReadLine()!;
            }
            while (!_validation.PasswordValidation(_Password));
            return _Password;
        }


        public static List<Customer> ReadCustomersFromFile(string filePath)
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split('|');

                        if (fields.Length >= 4)
                        {
                            string id = fields[1].Trim();
                            string name = fields[2].Trim();
                            string email = fields[3].Trim();
                            string password = fields[4].Trim();

                            Customer customer = new Customer(id, name, email, password);
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }
    }
}
