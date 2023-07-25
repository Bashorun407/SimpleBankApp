using BankApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApp.Methods
{
    public class AccountTransactionMethods
    {
        //1) Method to Register User
        public static void RegisterCustomer(List<Customer> customerList,List<Account> accountList)
        {
            //Introducing Customer variable
            bool checker = true;
            string fname = string.Empty;
            string lname = string.Empty;
            string oname = string.Empty;
            string email = string.Empty;
            string phoneNumber = string.Empty;
            string accountType = string.Empty;
            string password = string.Empty;

            //Accept firstname
            while (checker)
            {
                Console.WriteLine("Enter first name");
                fname = Console.ReadLine();
                //if name is valid, accept name
                if (AccountCheckMethods.isValidName(fname))
                {
                    Console.WriteLine($"{fname} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{fname} is invalid");
                }

            }

            checker = true; //reassigning true to checker
            //Accept last name
            while (checker)
            {
                Console.WriteLine("Enter last name: ");
                lname = Console.ReadLine();
                //if name is valid, accept name
                if (AccountCheckMethods.isValidName(lname))
                {
                    Console.WriteLine($"{lname} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{lname} is invalid");
                }
            }

            checker = true; //reassigning true to checker
            //Accept other name
            while (checker)
            {
                Console.WriteLine("Enter other name: ");
                oname = Console.ReadLine();
                //if name is valid, accept name
                if (AccountCheckMethods.isValidName(oname))
                {
                    Console.WriteLine($"{oname} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{oname} is invalid");
                }
            }

            checker = true; //reassigning true to checker
            //Accept email
            while (checker)
            {
                Console.WriteLine("Enter email: ");
                email = Console.ReadLine();

                //if name is valid, accept name
                if (AccountCheckMethods.isValidEmail(email))
                {
                    Console.WriteLine($"{email} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{email} is invalid");
                }
            }

            checker = true; //reassigning true to checker
            //Accept phone number
            while (checker)
            {
                Console.WriteLine("Enter phone number: ");

                phoneNumber = Console.ReadLine();
                //if name is valid, accept name
                if (AccountCheckMethods.isValidMobileNumber(phoneNumber))
                {
                    Console.WriteLine($"{phoneNumber} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{phoneNumber} is invalid");
                }
            }

            //Accepting Account type
            Console.WriteLine("Enter account type. 'Savings' or 'Current': ");
            accountType = AccountCheckMethods.AccountTypeChecker(Console.ReadLine());

            //Accepting Account type
            Console.WriteLine("Enter account password: ");
            password = Console.ReadLine();

            //use details to create a new account object
            Account account = new Account(fname, lname, oname, password, accountType);

            //To check if account already exists. If it doesn't, it will be added to the accountList
            AccountCheckMethods.CheckIfAccountExist(account, accountList);

            //Use details to create a new customer
            Customer customer = new Customer(fname, lname, oname, email, phoneNumber);
            //Add new customer to Customer List
            customerList.Add(customer);

            //Display account details to user
            Console.WriteLine($"Account Details: \n Account Name: {account.LastName}, {account.FirstName} {account.OtherName}" +
                $"\n Account Number: {account.AccountNumber}\n Account Type: {account.AccountType}\n Account Balance: {account.AccountBalance}");

        }


        //2) Method to Deposit
        public static void Deposit(string accountNumber, decimal depositAmount, string description, List<Account> accounts, List<Transaction> transactions)
        {
            bool checker = false;
            //Search for user's account detail in the List
            foreach (Account accountDetail in accounts)
            {
                //To check if account number exists in the in-memory database
                if (accountDetail.AccountNumber == accountNumber)
                {

                    accountDetail.AccountBalance += depositAmount;
                    Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                        $"is: N{accountDetail.AccountBalance}");

                    //Then save the Transaction in the transaction database
                    Transaction transaction = new Transaction("Debit", depositAmount, accountNumber, description);
                    transactions.Add(transaction);

                    checker = true;
                    //break the loop
                    break;

                }
                if (checker == true)
                {
                    return;
                }
                else
                {
                    //If account does not exist in the in-memory database, send an error message
                    //Console.WriteLine($"Account detail with Account number: {accountNumber} does not exist");
                }
            }

        }


        //3) Method to Withdraw
        public static void Withdraw(string accountNumber, decimal withdrawAmount, string description, List<Account> accounts, List<Transaction> transactions)
        {
            bool checker = false;
            //Search for user's account detail in the List
            foreach (Account accountDetail in accounts)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {
                    if(accountDetail.AccountType == "Current" && accountDetail.AccountBalance - withdrawAmount > 0)
                    {
                        //Requests for user's password
                        Console.WriteLine("Enter Password");
                        string? password = Console.ReadLine();

                        //if password tallies, continue transaction
                        if (password.Equals(accountDetail.Password))
                        {
                            accountDetail.AccountBalance -= withdrawAmount;
                            Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                                    $"is: N{accountDetail.AccountBalance}");

                            //Then save the Transaction in the transaction database
                            Transaction transaction = new Transaction("Withdraw", withdrawAmount, accountNumber, description);
                            transactions.Add(transaction);

                            checker = true;
                            //then break
                            break;
                        }

                        //if password does not exist, print warning to console
                        else
                        {
                            Console.WriteLine($"This password: {password} is not recognized.");
                            break;
                        }

                    }

                    //Check if Accountbalance is greater than withdrawAccount and balace left will be at least 500
                    else if (accountDetail.AccountType == "Savings" && accountDetail.AccountBalance - withdrawAmount > 1000)
                    {
                        //Requests for user's password
                        Console.WriteLine("Enter Password");
                        string? password = Console.ReadLine();

                        //if password tallies, continue transaction
                        if (password.Equals(accountDetail.Password))
                        {
                            accountDetail.AccountBalance -= withdrawAmount;
                            Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                                    $"is: N{accountDetail.AccountBalance}");

                            //Then save the Transaction in the transaction database
                            Transaction transaction = new Transaction("Withdraw", withdrawAmount, accountNumber, description);
                            transactions.Add(transaction);

                            checker = true;
                            //then break
                            break;
                        }

                        //if password does not exist, print warning to console
                        else
                        {
                            Console.WriteLine($"This password: {password} is not recognized.");
                            break;
                        }

                    }

                    else
                    {
                        Console.WriteLine("Insufficient Balance. \nLeast balance must be 500. \nReduce withdraw amount");
                    }

                }

                if(checker == true)
                {
                    return;
                }
                else
                {
                    //if account does not exist in the in-memory
                    //Console.WriteLine($"Account with Account-Number: {accountNumber} does not exist.");
                }
            }
        }


        //4) Method to transfer
        public static void Transfer(string fromAccount, string toAccount, decimal amount, string description, List<Account> accounts, List<Transaction> transactions)
        {

            //Withdraw amount from Sender's account
            Withdraw(fromAccount, amount, description, accounts, transactions);

            //Send amount to Receiver's account
            Deposit(toAccount, amount, description, accounts, transactions);

            Console.WriteLine(description);
        }


        //5) Method to check balance
        public static void CurrentBalance(string accountNumber, List<Account> accountList)
        {
            bool checker = false;
            //Search for user's account detail in the List
            foreach (Account accountDetail in accountList)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {
                    //Requests for user's password
                    Console.WriteLine("Enter Password");
                    string? password = Console.ReadLine();

                    //if password tallies, continue transaction
                    if (password.Equals(accountDetail.Password))
                    {
                        Console.WriteLine($"Account Details: \n Name: {accountDetail.LastName}, {accountDetail.FirstName}" +
                            $"\n Account Number: {accountDetail.AccountNumber} \n Account Balance: {accountDetail.AccountBalance}");

                        checker = true;
                        //break out of the loop
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"Password is not recognized: {password}");
                    }
                }
                if (checker == true)
                    return;
                else
                {
                    Console.WriteLine($"Account Number: {accountNumber} does not exist. ");
                }
            }

        }

        //6)Method to list all accounts in the Database
        public static void DisplayAllAccount(List<Account> accounts)
        {
            Console.WriteLine("First Name\t\t| Last Name\t\t|Other Name\t\t|Account Type\t\t|Account Number\t\t|Account Balance \t\t|");
            foreach (Account account in accounts)
            {

                Console.WriteLine($"{account.FirstName}\t\t|{account.LastName}\t\t|{account.OtherName}\t\t|{account.AccountType}\t\t|{account.AccountNumber}\t\t|{account.AccountBalance}\t\t|");
            }
        }
    }
}
