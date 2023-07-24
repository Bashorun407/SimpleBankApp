using BankApp.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        //Debit or Credit or Transfer
        public string? TransactionType { get; set; }
        public string? AccountNumber { get; set; }
        public decimal? TransactionAmount { get; set; }

        public string? TransactionDescription { get; set; }

        //Class Constructor
        public Transaction(string transactionType, decimal amount, string accountNumber, string transactionDescription)
        {
            TransactionId = AccountCheckMethods.GenerateTransactionId(transactionType);
            TransactionType = transactionType;
            AccountNumber = accountNumber;
            TransactionAmount = amount;
            TransactionDescription = transactionDescription;
        }

    }
}
