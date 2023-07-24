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
        public decimal? TransactionAmount { get; set; }
        public string? SenderAccount { get; set; }
        public string? ReceiverAccount { get; set; } 
        public string? TransactionDescription { get; set; }

        //Class Constructor
        public Transaction(string transactionType, decimal amount, string senderAccount, string receiverAccount, string transactionDescription)
        {
            TransactionId = AccountCheckMethods.GenerateTransactionId(transactionType);
            TransactionType = transactionType;
            TransactionAmount = amount;
            SenderAccount = senderAccount;
            ReceiverAccount = receiverAccount;
            TransactionDescription = transactionDescription;
        }

    }
}
