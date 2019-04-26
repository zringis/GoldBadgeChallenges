using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet_Repository
{
    public enum CustomerType { Current = 1, Potential, Past}
    public class Greet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public string Email { get; set; }

        public Greet()
        {

        }
        public Greet(string firstName, string lastName, CustomerType customerType, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = customerType;
            Email = email;
        }
    }
}
