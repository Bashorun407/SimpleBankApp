using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp.Methods
{

    public class AccountDetail
    {

        //Class properties/attributes
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountType { get; set; }
        public decimal AccountBalance { get; set; }

        //Class constructor
        public AccountDetail(string firstname, string lastName, string email, string phoneNumber, string accountType)
        {

            FirstName = firstname;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

            //AccountNumber should be internally generated
            AccountNumber = AccountCheckMethods.GenerateAccountNumber();

            AccountType = accountType;

            //accountBalance should be a default value
            AccountBalance = 0.0m;
        }


    }
}
