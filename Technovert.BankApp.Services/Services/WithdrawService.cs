using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.Services
{
    public class WithdrawAmount
    {
        public string Withdraw(string BankName, string AccId, decimal amt)
        {
            Bank b = DataStore.Banks.Single(m => m.Name == BankName);
            Account a = b.AccLists.Single(m => m.UserId == AccId);
            StatusService status = new StatusService();
            status.Status(a);
            if (a.Status == AccountStatus.Closed)
            {
                return "Account Doesnot exist or closed";
            }
            if (amt > a.Balance)
            {
                return "Availabe Balance is " + amt;
            }
            a.Balance = a.Balance - amt;
            a.UpdatedOn = DateTime.Now;
            a.UpdatedBy = AccId;
            string transid = "TXN" + b.BankId + a.UserId + DateTime.Now;
            a.TransactionHistory.Add(new Transaction { BankId = BankName,TransId = transid,UserId = AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Withdraw, Balance = a.Balance }) ;
            return amt + " is Withdrawn";
        }
    }
}