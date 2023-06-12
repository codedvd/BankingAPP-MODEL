using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAPP.Interfaces;

namespace BankAPP.Implementation.Customer_IM
{
    public class RegisterCustomer : Helper, IRegisterCustomer
    {
        public void RegisterACustomer()
        {
            var f_name = FullName();
            var e_mail = Email();
            var pass = Password();
            var id = CustomerId();

            Customer customer = new Customer(id, f_name, e_mail, pass);
            using (StreamWriter writer = new StreamWriter("Customers.txt", true))
            {
                writer.WriteLine($"|  {customer.CustomerId,-12}   |      {customer.Fullname,-16}    | {customer.Email,-18}   |  {customer.Password,-18}  | \n\n");
            }

            Console.WriteLine("Added to Database!");
        }
    }
}
