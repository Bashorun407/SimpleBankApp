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

            AccountType = AccountTypeChecker(accountType);

            //accountBalance should be a default value
            AccountBalance = 0.0m;
        }


        //Using Checkers to check that Duplicate accounts with the same account-type does not exist
        public static void CheckIfAccountExist(AccountDetail newAccount, List<AccountDetail> accounts)
        {
            bool find = false;
            foreach (AccountDetail account in accounts)
            {
                //if account type exists, break
                if(account.FirstName.Equals(newAccount.FirstName, StringComparison.InvariantCultureIgnoreCase) 
                    && account.LastName.Equals(newAccount.LastName, StringComparison.InvariantCultureIgnoreCase) 
                    && account.AccountType.Equals(newAccount.AccountType, StringComparison.InvariantCultureIgnoreCase))
                {
                    find = true;
                    break;
                }
            }

            if (find == true)
            {
                Console.WriteLine($"Account already exists. You can register another account different from {newAccount.AccountType}");
            }

            else
            {
                accounts.Add(newAccount);
            }
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
                        $"is: N{accountDetail.AccountBalance}");

                }

                //If account does not exist in the in-memory database, send an error message
                else
                {
                    Console.WriteLine("Account detail does not exist");
                }
            }
        }

        //Method to Withdraw
        public void Withdraw(string accountNumber, decimal withdrawAmount, List<AccountDetail> accounts)
        {
            //Search for user's account detail in the List
            foreach (AccountDetail accountDetail in accounts)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {

                    //Check if Accountbalance is greater than withdrawAccount and balace left will be at least 500
                    if(AccountBalance - withdrawAmount > 1000)
                    {
                        accountDetail.AccountBalance -= withdrawAmount;
                        Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                                $"is: N{accountDetail.AccountBalance: 2F}");
                    }

                    else
                    {
                        Console.WriteLine("Insufficient Balance. \nLeast balance must be 500. \nReduce withdraw amount");
                    }

                }

                //if account does not exist in the in-memory
                else
                {
                    Console.WriteLine($"Account with Account-Number: {accountDetail.AccountNumber} does not exist.");
                }

            }
        }

        //Method to transfer
        public void Transfer(string fromAccount, string toAccount, decimal amount, string comment, List<AccountDetail> accounts)
        {

            //Withdraw amount from Sender's account
            Withdraw(fromAccount, amount, accounts);

            //Send amount to Receiver's account
            Deposit(toAccount, amount, accounts);

            Console.WriteLine(comment);
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
