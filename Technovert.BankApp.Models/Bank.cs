using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models
{
    public class Bank
    {
        public string BankId { get; set; }
        public string Name { get; set; }
        public List<Account> AccLists { get; set; } = new List<Account>();
        public DateTime CreatedOn { get; set; }
       
    }
}
