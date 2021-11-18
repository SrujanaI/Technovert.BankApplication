using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Newtonsoft.Json;
using System.IO;

namespace Technovert.BankApp.Services
{
    public class DepositService
    {
        public bool Deposit(string BankId, Account account, decimal amt)
        {

            StatusService status = new StatusService();
            AccountStatus stat = status.Status(account);
            if (stat == AccountStatus.Closed)
            {
                throw new AccountClosedException("Your Account Is Closed");
            }

            account.Balance = account.Balance + amt;
            account.UpdatedOn = DateTime.Now;
            account.UpdatedBy = account.AccId;

            string transid = "TXN" + BankId + account.AccId + DateTime.Now;
            account.TransactionHistory.Add(new Transaction { BankId = BankId, TransId = transid, UserId = account.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = account.Balance });
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            var path = Path.Combine(directory, "../Bank.json");
            string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(path, json);
            return true;
        }
    }
}