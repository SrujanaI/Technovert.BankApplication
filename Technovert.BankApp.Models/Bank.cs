using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models
{
    public class Bank
    {
        public string Id { get; set; }
        public string BankName { get; set; }
        public List<Account> AccLists { get; set; } = new List<Account>();
        public DateTime CreatedOn { get; set; }
        public double IMPSSameBank { get; set; } = 0.05;
        public double RTGS { get; set; } = 0.02;
        public double IMPSOtherBank { get; set; } = 0.06;
        public List<BankStaff> bankStaff { get; set; } = new List<BankStaff>();

    }
}