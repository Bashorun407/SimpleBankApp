using BankApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp.Methods
{
    public class AccountCheckMethods
    {
        //1) Method to check that Duplicate accounts with the same account-type does not exist
        public static bool CheckIfAccountExist(Account newAccount, List<Account> accounts)
        {
            bool find = false;
            foreach (Account account in accounts)
            {
               //Reconstruct this if conditional statement
                //if account type exists, break
                if(newAccount.FirstName == account.FirstName && newAccount.LastName == account.LastName 
                    && newAccount.OtherName == account.OtherName && newAccount.AccountType == account.AccountType)
                {
                    find = true;
                    break;
                }
                /*
                if (account.FirstName.Equals(newAccount.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && account.LastName.Equals(newAccount.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && account.OtherName.Equals(newAccount.AccountNumber, StringComparison.InvariantCultureIgnoreCase)
                    && account.AccountType.Equals(newAccount.AccountType, StringComparison.InvariantCultureIgnoreCase))
                {
                    find = true;
                    break;
                }*/
            }

            if (find == true)
            {
                Console.WriteLine($"Account already exists. You can register another account different from {newAccount.AccountType}");
                return false;
            }

            accounts.Add(newAccount);
            return true;
        }


        //2) Method to generate account number
        public static string GenerateAccountNumber()
        {
            string acctNum = string.Empty;
            Random rand = new Random();

            for (int i = 0; i < 1; i++)
            {
                acctNum += rand.NextInt64();
            }

            return acctNum;
        }

        //2b) Method to generate account number
        public static string GenerateUniqueId()
        {
            string acctNum = string.Empty;
            Random rand = new Random();

            for (int i = 0; i < 1; i++)
            {
                acctNum += rand.NextInt64();
            }

            return acctNum;
        }

        //2) Method to generate account number
        public static string GenerateTransactionId(string name)
        {
            string acctNum = string.Empty;
            Random rand = new Random();

            for (int i = 0; i < 1; i++)
            {
                acctNum += rand.NextInt64();
            }
            acctNum = name + "-" + acctNum;
            return acctNum;
        }


        //3) Method to Check the account type
        public static string AccountTypeChecker(string accountType)
        {
            if (accountType.Equals("Current", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Current";
            }
            else
                return "Savings";
        }



        //4) Method-Phone number format checker using regex
        public static bool isValidMobileNumber(string inputMobileNumber)
        {
            //This format ensures that phone number begins with 234 which is Nigerian code
            string strRegex = @"(^+[2-4]{3}-[1-9]{2}-[0-9]{4}-[0-9]{4}$)";

            Regex re = new Regex(strRegex);

            // The IsMatch method is used to validate
            // a string or to ensure that a string
            // conforms to a particular pattern.
            if (re.IsMatch(inputMobileNumber))
                return true;
            else
                return false;
        }


        //5) Method-Email format checker using regex
        public static bool isValidEmail(string inputEmail)
        {
            //return Regex.IsMatch(inputEmail, @"^[a-z0-9\.-_]+@[a-z0-9\.a-z]$");
            
            return Regex.IsMatch(inputEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        }

        //6) Method-Name format checker using regex
        public static bool isValidName(string name)
        {
            //Will still check this regular expression
            string strRegex = @"^[A-Z]{1}[a-z]{1,}";

            return Regex.IsMatch(name, strRegex);
        }

        /*
         4) Method-Phone number format checker using regex
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

         
        //5) Method-Email format checker using regex
        public static bool isValidEmail(string inPutEmail)
        {
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (re.IsMatch(inPutEmail))
                return (true);
            else
                return (true);
        }
        */
    }
}
