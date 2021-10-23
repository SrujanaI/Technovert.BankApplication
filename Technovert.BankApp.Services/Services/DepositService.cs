using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Services.Services
{
    public class DepositService
    {
        public string deposit(string BankId, Account a, decimal amt)
        {
           
            StatusService status = new StatusService();
            AccountStatus s=status.Status(a);
            if(s==AccountStatus.Closed)
            {
                return "Account Doesnot exist or closed";
            }
            Console.WriteLine(a.Status);
            
            a.Balance = a.Balance + amt;
            a.UpdatedOn = DateTime.Now;
            a.UpdatedBy = a.AccId;
            
            string transid = "TXN" + BankId + a.AccId + DateTime.Now;
            a.TransactionHistory.Add(new Transaction {BankId = BankId, TransId = transid , UserId = a.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = a.Balance });
            
            return "Deposited " + amt;
        }
    }
}
