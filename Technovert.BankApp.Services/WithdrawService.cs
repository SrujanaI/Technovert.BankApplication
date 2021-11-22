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
            using (StreamReader reader = new StreamReader(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                if (amt > acc.Balance)
                {
                    throw new InsufficientAmountException("Available balance is less than required");
                //return "Availabe Balance is " + amt;
                }
                string transid;
                acc.Balance = acc.Balance - amt;
                acc.UpdatedOn = DateTime.Now;
                acc.UpdatedBy = acc.AccId;
                foreach (Bank b in list)
                {
                    if (b.Id == bank.Id)
                    {
                        Account ac = b.AccLists.Single(m => m.AccName == acc.AccName);
                        ac.Balance = acc.Balance;
                        ac.UpdatedBy = acc.AccId;
                        ac.UpdatedOn = DateTime.Now;
                        transid = "TXN" + bank.Id + acc.AccId + DateTime.Now;
                        ac.TransactionHistory.Add(new Transaction { BankId = bank.Id, TransId = transid, UserId = acc.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = acc.Balance });
                    }
                }
                transid = "TXN" + bank.Id + acc.AccId + DateTime.Now;
                acc.TransactionHistory.Add(new Transaction { BankId = bank.Id, TransId = transid, UserId = acc.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Withdraw, Balance = acc.Balance });
            
                json = JsonConvert.SerializeObject(list);
                File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json", json);
            }
            return true;
        }
    }
}