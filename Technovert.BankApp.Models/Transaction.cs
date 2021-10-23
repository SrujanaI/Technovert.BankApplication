using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Models
{
    public class Transaction
    {
        public string TransId { get; set; }
        public string BankId { get; set; }
        public string UserId { get; set; }
        public TransactionType Type { get; set; }

        public string DestinationId { get; set; }
        public string DestinationBankId { get; set; }

        public decimal Amount { get; set; }

        public DateTime On {get; set;}

        public decimal Balance { get; set; }
        
         
    }
}
