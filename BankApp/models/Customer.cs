using BankApp.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        //Class properties/attributes
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        //Class Constructor
        public Customer(string firstName, string lastName, string otherName, string email, string phoneNumber)
        {
            CustomerId = AccountCheckMethods.GenerateUniqueId();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            OtherName = otherName.Trim();
            Email = email.Trim();
            PhoneNumber = phoneNumber.Trim();
        }

    }
}
