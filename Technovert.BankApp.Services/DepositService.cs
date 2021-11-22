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
            AccountStatus accStatus = status.Status(account);
            if (accStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Your Account Is Closed");
            }
            using (StreamReader reader = new StreamReader(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);

                account.Balance = account.Balance + amt;
                account.UpdatedOn = DateTime.Now;
                account.UpdatedBy = account.AccId;
                string transid;
                foreach(Bank b in list)
                {
                    if (b.Id == BankId)
                    {
                        Account ac = b.AccLists.Single(m => m.AccName == account.AccName);
                        ac.Balance = account.Balance;
                        ac.UpdatedBy = account.AccId;
                        ac.UpdatedOn = DateTime.Now;
                        transid = "TXN" + BankId + account.AccId + DateTime.Now;
                        ac.TransactionHistory.Add(new Transaction { BankId = BankId, TransId = transid, UserId = account.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = account.Balance });
                    }
                }
                transid = "TXN" + BankId + account.AccId + DateTime.Now;
                account.TransactionHistory.Add(new Transaction { BankId = BankId, TransId = transid, UserId = account.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = account.Balance });
            /*var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            var path = Path.Combine(directory, "../Bank.json");*/
            
                json = JsonConvert.SerializeObject(list);
                File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json", json);
            }
            /*string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json", json);*/
            return true;
        }
    }
}