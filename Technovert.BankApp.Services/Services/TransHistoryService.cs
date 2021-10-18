using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.Services
{
    public class TransHistoryService
    {
        public List<Transaction> TransHistory(string BankName, string AccId)
        {
            Bank b = DataStore.Banks.Single(m => m.Name == BankName);
            Account a = b.AccLists.Single(m => m.UserId == AccId);
            return a.TransactionHistory;
            
        }
    }
}