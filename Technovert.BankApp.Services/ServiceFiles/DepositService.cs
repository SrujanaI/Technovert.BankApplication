using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.Services.ServiceFiles
{
    public class DepositService
    {
        public bool deposit(string BankId, Account a, decimal amt)
        {
           
            StatusService status = new StatusService();
            AccountStatus s=status.Status(a);
            if(s==AccountStatus.Closed)
            {
                throw new AccountClosedException("Your");
            }
            
            a.Balance = a.Balance + amt;
            a.UpdatedOn = DateTime.Now;
            a.UpdatedBy = a.AccId;
            
            string transid = "TXN" + BankId + a.AccId + DateTime.Now;
            a.TransactionHistory.Add(new Transaction {BankId = BankId, TransId = transid , UserId = a.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = a.Balance });
            
            return true;
        }
    }
}
