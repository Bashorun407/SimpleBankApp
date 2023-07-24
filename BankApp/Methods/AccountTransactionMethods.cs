﻿using BankApp.models;
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

            //Use details to create a new customer
            Customer customer = new Customer(fname, lname, oname, email, phoneNumber);
            //Add new customer to Customer List
            customerList.Add(customer);

            //use details to create a new account object
            Account account = new Account(fname, lname, oname, password, accountType);

            //To check if account already exists
            AccountCheckMethods.CheckIfAccountExist(account, accountList);
        }


        //2) Method to Deposit
        public static void Deposit(string accountNumber, decimal balance, List<Account> accounts, List<Transaction> transactions)
        {
            //Search for user's account detail in the List
            foreach (Account accountDetail in accounts)
            {
                //To check if account number exists in the in-memory database
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {

                    accountDetail.AccountBalance += balance;
                    Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                        $"is: N{accountDetail.AccountBalance}");

                    //Then save the Transaction in the transaction database

                    break;

                }

                //If account does not exist in the in-memory database, send an error message
                else
                {
                    Console.WriteLine("Account detail does not exist");
                }
            }
        }


        //3) Method to Withdraw
        public static void Withdraw(string accountNumber, decimal withdrawAmount, List<Account> accounts, List<Transaction> transactions)
        {
            //Search for user's account detail in the List
            foreach (Account accountDetail in accounts)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {

                    //Check if Accountbalance is greater than withdrawAccount and balace left will be at least 500
                    if (accountDetail.AccountBalance - withdrawAmount > 1000)
                    {
                        //Requests for user's password
                        Console.WriteLine("Enter Password");
                        string? password = Console.ReadLine();

                        //if password tallies, continue transaction
                        if (password.Equals(accountDetail.Password))
                        {
                            accountDetail.AccountBalance -= withdrawAmount;
                            Console.WriteLine($"New Account Balance for {accountDetail.LastName}, {accountDetail.FirstName} [{accountDetail.AccountNumber}] " +
                                    $"is: N{accountDetail.AccountBalance: 2F}");

                            //Then save the Transaction in the transaction database

                            //then break
                            break;
                        }

                        //if password does not exist, print warning to console
                        else
                        {
                            Console.WriteLine("This password is not recognized.");
                            break;
                        }

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


        //4) Method to transfer
        public static void Transfer(string fromAccount, string toAccount, decimal amount, string comment, List<Account> accounts, List<Transaction> transactions)
        {

            //Withdraw amount from Sender's account
            Withdraw(fromAccount, amount, accounts, transactions);

            //Send amount to Receiver's account
            Deposit(toAccount, amount, accounts, transactions);

            Console.WriteLine(comment);
        }
    }
}
