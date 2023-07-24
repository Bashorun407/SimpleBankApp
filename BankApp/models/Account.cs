using BankApp.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.models
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string? AccountNumber { get; set; }
        public string? Password { get; set; }
        public string? AccountType { get; }
        public decimal AccountBalance { get; set; }

        //Class Constructor
        public Account(string firstName, string lastName, string otherName, string password, string accountType)
        {
            FirstName = firstName;
            LastName = lastName;
            OtherName = otherName;
            AccountNumber = AccountCheckMethods.GenerateAccountNumber();
            Password = password;
            AccountType = accountType;
            AccountBalance = 0.0m;
        }

    }
}
