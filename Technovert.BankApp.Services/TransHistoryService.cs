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
        public List<Transaction> TransHistory(Account account)
        {
            return account.TransactionHistory;
        }
    }
}