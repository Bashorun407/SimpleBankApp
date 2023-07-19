using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp
{

    public class AccountDetail
    {

        //Class properties/attributes
        private string? FirstName { get; set; }
        private string? LastName { get; set; }
        private string? Email { get; set; }
        private string? PhoneNumber { get; set; }
        private string? AccountNumber { get; set; }
        private string? AccountType { get; set;}
        private decimal AccountBalance { get; set; }

        //Class constructor
        public AccountDetail(string firstname, string lastName, string email, string phoneNumber, string accountType)
        {

            FirstName = firstname;

            LastName = lastName;

            //to validate email format
            if (isValidEmail(email) == true)
            {
                Email = email;
            }

            //to validate phone number format
            if (isValidMobileNumber(phoneNumber) == true)
            {
                PhoneNumber = phoneNumber;
            }

            //AccountNumber should be internally generated
            AccountNumber = GenerateAccountNumber();

            AccountType = accountType;

            //accountBalance should be a default value
            AccountBalance = 0.0m;
        }


        //account generator
        public string GenerateAccountNumber()
        {
            string acctNum = string.Empty;
            Random rand = new Random();

            for(int i = 0; i < 9; i++)
            {
                acctNum += rand.NextInt64();
            }

            return acctNum;
        }

        //Check the account type
        public string AccountTypeChecker(string accountType)
        {
            if (accountType.Equals("Current",StringComparison.InvariantCultureIgnoreCase))
            {
                return "Current";
            }
            else
                return "Savings";
        }

        //Method to Deposit
        public void Deposit(string accountNumber, decimal balance, List<AccountDetail> accounts)
        {
            //Search for user's account detail in the List
            foreach (AccountDetail accountDetail in accounts)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {
                    accountDetail.AccountBalance += balance;
                    Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                        $"is: {accountDetail.AccountBalance}");

                }

                //If account does not exist in the in-memory database, send an error message
                else
                {
                    Console.WriteLine("Account detail does not exist");
                }
            }
        }

        //Method to Withdraw
        public void Withdraw(string accountNumber, decimal balance, List<AccountDetail> accounts)
        {
            //Search for user's account detail in the List
            foreach (AccountDetail accountDetail in accounts)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {

                    //Check if Account
                    accountDetail.AccountBalance = balance;
                    Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                        $"is: {accountDetail.AccountBalance}");

                }
            }
        }

        //Method to transfer
        public void Transfer(string fromAccount, string toAccount, decimal balance)
        {

        }

        //generate random

        //phone number format checker
        // method containing the regex
        public static bool isValidMobileNumber(string inputMobileNumber)
        {
            // Class Regex Represents an
            // immutable regular expression.
            //   Format                Pattern
            // xxxxxxxxxx           ^[0 - 9]{ 10}$
            // +xx xx xxxxxxxx     ^\+[0 - 9]{ 2}\s +[0 - 9]{ 2}\s +[0 - 9]{ 8}$
            // xxx - xxxx - xxxx   ^[0 - 9]{ 3} -[0 - 9]{ 4}-[0 - 9]{ 4}$
            //string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)"

            //This format ensures that phone number begins with 234 which is Nigerian code
            string strRegex = @"(^+[2-4]{3}-[1-9]{2} -[0-9]{4}-[0-9]{4}$)";

            Regex re = new Regex(strRegex);

            // The IsMatch method is used to validate
            // a string or to ensure that a string
            // conforms to a particular pattern.
            if (re.IsMatch(inputMobileNumber))
                return (true);
            else
                return (false);
        }

        //email format checker
        public bool isValidEmail(string inPutEmail)
        {
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (re.IsMatch(inPutEmail))
                return (true);
            else
                return (true);
        }
    }
}
