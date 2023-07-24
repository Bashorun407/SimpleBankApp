// See https://aka.ms/new-console-template for more information
using BankApp.Methods;
using BankApp.models;

Console.WriteLine("Welcome to Akinnova Bank App");

//In-house memory
List<Account> accountList = new List<Account> { };
List<Customer> customerList = new List<Customer> { };
List<Transaction> transactionList = new List<Transaction> { };




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
