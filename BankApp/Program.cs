// See https://aka.ms/new-console-template for more information
using BankApp.Methods;

Console.WriteLine("Hello, World!");

//In-house memory
List<AccountDetail> accountList = new List<AccountDetail> { };

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
