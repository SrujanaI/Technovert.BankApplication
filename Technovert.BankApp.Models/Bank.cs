using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models
{
    public class Bank
    {
        public string BankId { get; set; }
        public string BankName { get; set; }
        public List<Account> AccLists { get; set; } = new List<Account>();
        public DateTime CreatedOn { get; set; }
        public int IMPSSameBank { get; set; } = 5;
        public int RTGS { get; set; } = 2;
        public int IMPSOtherBank { get; set; } = 6;
        public List<BankStaff> bankStaff { get; set; } = new List<BankStaff>();

    }
}
