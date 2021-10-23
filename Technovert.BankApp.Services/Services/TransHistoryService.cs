using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Services.Services
{
    public class TransHistoryService
    {
        public List<Transaction> TransHistory(Account acc)
        {
            return acc.TransactionHistory;
        }
    }
}