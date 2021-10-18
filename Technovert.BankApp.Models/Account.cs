using System;
using System.Collections.Generic;

namespace Technovert.BankApp.Models
{
    public class Account
    {
        //public string BankId { get; set;}
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string Gender { get; set; } 
        public string Mobile { get; set; }
        public  AccountStatus Status { get; set; }
       
        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
