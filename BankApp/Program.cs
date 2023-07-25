// See https://aka.ms/new-console-template for more information
using BankApp.Methods;
using BankApp.models;

Console.WriteLine("Welcome to Akinnova Bank App");

//In-house memory
List<Account> accountList = new List<Account> { };
List<Customer> customerList = new List<Customer> { };
List<Transaction> transactionList = new List<Transaction> { };
string? input = string.Empty;
bool whileChecker = true;

//Using Switch to give users options
while (whileChecker)
{
    //Print options to console
    Console.WriteLine("\n####********** Welcome Customer ***********####\n\n To Register press: 1 \n To Deposit press: 2 \n To Withdraw press: 3 \n To Transfer press: 4" +
        "\n To Check Balance press: 5 \n To Display all accounts press: 6 \n To Quit Press: 0");
    //Accept user input
    input = Console.ReadLine();

    bool check = byte.TryParse(input, out byte result);

    //To check input by user
    //To check if user inputs string

    if (check == false)
    {
        Console.WriteLine("Your input is invalid!!");
        //break;
    }


    //To check that the user inputs digit between 1 and 7
    else if (result < 0 || result > 6)
    {
        Console.WriteLine("Number input must be from 0 - 5!");
        //break;
    }

    else
    {
        switch(result)
        {
            //Operation quits if user enters 0
            case 0:
                Console.WriteLine("You have exited");
                break;


            //Registers Customer
            case 1:
                Console.WriteLine("Register Customer");
                AccountTransactionMethods.RegisterCustomer(customerList, accountList);
                break;


            //Deposit Transactiton
            case 2:
                Console.WriteLine("Deposit Transaction");
                Console.WriteLine("Enter your accountNumber: ");
                string acctNum = Console.ReadLine();

                Console.WriteLine("Enter amount to deposit: ");
                input = Console.ReadLine();
                bool inputChecker  = Decimal.TryParse(input, out decimal deciResult);
                if (inputChecker == true) 
                {
                    AccountTransactionMethods.Deposit(acctNum, deciResult, "A deposit transaction", accountList, transactionList);
                }
                else
                {
                    Console.WriteLine($"Amount entered is invalid.");
                }
                break;


            //Withdraw Transaction
            case 3:
                Console.WriteLine("Withdraw Transaction");
                Console.WriteLine("Enter your accountNumber: ");
                string acct1 = Console.ReadLine();

                Console.WriteLine("Enter amount to withdraw: ");
                input = Console.ReadLine();
                bool inputChecker2 = Decimal.TryParse(input, out decimal withResult);
                if (inputChecker2 == true)
                {
                    AccountTransactionMethods.Withdraw(acct1, withResult, "A withdraw transaction", accountList, transactionList);
                }
                else
                {
                    Console.WriteLine($"Amount entered is invalid.");
                }
                break;


            //Transfer Transaction
           case 4:
                Console.WriteLine("Transfer Transaction");
                //Prompting user for sender account
                Console.WriteLine("Enter sender account number: ");
                string senderAccount = Console.ReadLine();

                //Prompting user for receiver account
                Console.WriteLine("Enter receiver account number: ");
                string receiverAccount = Console.ReadLine();

                Console.WriteLine("Enter amount to deposit: ");
                input = Console.ReadLine();
                bool inputChecker3 = Decimal.TryParse(input, out decimal amountToSend);

                if (inputChecker3 == false)
                {
                    Console.WriteLine($"Amount entered is invalid.");
                    break;
                }

                AccountTransactionMethods.Transfer(senderAccount, receiverAccount, amountToSend, "A transfer transaction",accountList, transactionList);
                break;


            //To Check Account Balance
            case 5:
                Console.WriteLine("Balance Enquiry");
                //Prompting user for sender account
                Console.WriteLine("Enter your account number: ");
                string accountNumber = Console.ReadLine();
                AccountTransactionMethods.CurrentBalance(accountNumber, accountList);
                break;

            case 6:
                Console.WriteLine("All Accounts");
                AccountTransactionMethods.DisplayAllAccount(accountList);
                break;

        }
    }

    //Prompt the User if they want to continue
    Console.WriteLine("\nTo QUIT press 'NO' ");
    string stopOperation = Console.ReadLine();
    //check whileChecker
    if (stopOperation == "NO")
    {
        //change the condition of whileChecker
        whileChecker = false;
    }
}

/*
string newName = string.Empty;

//Get User input
Console.WriteLine("Enter a new name: ");

newName = Console.ReadLine()!.Trim();

if(string.IsNullOrEmpty(newName))
{
    throw new InvalidOperationException("User input cannot be empty.");
}

//Write the new name to the file
string filePath = @"C:\Users\oluwaseyi.akinbobola\Desktop\Projects\DotNet\BankApp\BankApp\TextDatabase";

using (StreamWriter sw = new StreamWriter(filePath, true))
{
    sw.WriteLine(newName);
}

Console.WriteLine($"{newName} has been added to the file");
*/

Console.ReadKey();
