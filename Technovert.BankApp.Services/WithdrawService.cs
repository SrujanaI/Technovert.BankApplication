using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using System.IO;
using Newtonsoft.Json;

namespace Technovert.BankApp.Services
{
    public class WithdrawAmount
    {
        public bool Withdraw(Bank bank, Account acc, decimal amt)
        {
            StatusService status = new StatusService();
            AccountStatus s = status.Status(acc);
            if (s == AccountStatus.Closed)
            {
                throw new AccountClosedException("Your Account Is Closed");
                /*return "Account Doesnot exist or closed"*/
            }
            if (amt > acc.Balance)
            {
                throw new InsufficientAmountException("Available balance is less than required");
                //return "Availabe Balance is " + amt;
            }
            acc.Balance = acc.Balance - amt;
            acc.UpdatedOn = DateTime.Now;
            acc.UpdatedBy = acc.AccId;
            string transid = "TXN" + bank.Id + acc.AccId + DateTime.Now;
            acc.TransactionHistory.Add(new Transaction { BankId = bank.Id, TransId = transid, UserId = acc.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Withdraw, Balance = acc.Balance });
            string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\bank.json", json);
            return true;
        }
    }
}