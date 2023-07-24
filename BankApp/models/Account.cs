using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.models
{
    public class Account
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountType { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
