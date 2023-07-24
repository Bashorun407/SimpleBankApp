using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.models
{
    public class Transaction
    {
        public int Id { get; set; }
        //Debit or Credit or Transfer
        public string? TransactionType { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string? SenderAccount { get; set; }
        public string? ReceiverAccount { get; set; } 
        public string? TransactionDescription { get; set; }

    }
}
