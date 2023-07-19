using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class AccountTransactionMethods
    {
        //1) Method to Deposit
        public static void Deposit(string accountNumber, decimal balance, List<AccountDetail> accounts)
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


        //2) Method to Withdraw
        public static void Withdraw(string accountNumber, decimal withdrawAmount, List<AccountDetail> accounts)
        {
            //Search for user's account detail in the List
            foreach (AccountDetail accountDetail in accounts)
            {
                //if account exists in the in-memory database, add balance
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {

                    //Check if Accountbalance is greater than withdrawAccount and balace left will be at least 500
                    if (accountDetail.AccountBalance - withdrawAmount > 1000)
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


        //3) Method to transfer
        public static void Transfer(string fromAccount, string toAccount, decimal amount, string comment, List<AccountDetail> accounts)
        {

            //Withdraw amount from Sender's account
            Withdraw(fromAccount, amount, accounts);

            //Send amount to Receiver's account
            Deposit(toAccount, amount, accounts);

            Console.WriteLine(comment);
        }
    }
}
