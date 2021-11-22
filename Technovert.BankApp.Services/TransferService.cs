using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.Services
{
    public class TransferService
    {
        public bool Transfer(Bank sourceBank, Account sourceAccount, decimal amount, Bank destBank, Account destAccount)
        {
            decimal charges;
            StatusService status = new StatusService();
            AccountStatus sourceStatus = status.Status(sourceAccount);
            AccountStatus destStatus = status.Status(destAccount);
            if (sourceStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Source Account Is Closed");
            }
            if (destStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Deposit Account Is Closed");
            }
            if (sourceBank.BankName == destBank.BankName)
            {
                charges = Convert.ToDecimal(sourceBank.IMPSSameBank) * amount;
            }
            else
            {
                charges = Convert.ToDecimal(sourceBank.IMPSOtherBank) * amount + Convert.ToDecimal(sourceBank.RTGS) * amount;
            }
            if ((amount + charges) > sourceAccount.Balance)
            {
                throw new Exception("Available amount is " + sourceAccount.Balance);
            }
            using (StreamReader reader = new StreamReader(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                string transid;
                sourceAccount.Balance = sourceAccount.Balance - (amount + charges);
                destAccount.Balance = destAccount.Balance + amount;
                sourceAccount.UpdatedOn = DateTime.Now;
                sourceAccount.UpdatedBy = sourceAccount.AccId;
                foreach (Bank b in list)
                {
                    if (b.Id == sourceBank.Id)
                    {
                        Account ac = b.AccLists.Single(m => m.AccName == sourceAccount.AccName);
                        ac.Balance = sourceAccount.Balance;
                        ac.UpdatedBy = sourceAccount.AccId;
                        ac.UpdatedOn = DateTime.Now;
                        transid = "TXN" + sourceBank.Id + sourceAccount.AccId + DateTime.Now;
                        ac.TransactionHistory.Add(new Transaction { BankId = sourceBank.Id, DestinationBankId = destBank.Id, TransId = transid, UserId = sourceAccount.AccId, DestinationId = destAccount.AccId, Amount = amount, On = DateTime.Now, Type = TransactionType.Debit, Balance = sourceAccount.Balance });
                    }
                    if (b.Id == destBank.Id)
                    {
                        Account ac = b.AccLists.Single(m => m.AccName == destAccount.AccName);
                        ac.Balance = destAccount.Balance;
                        ac.UpdatedBy = destAccount.AccId;
                        ac.UpdatedOn = DateTime.Now;
                        transid = "TXN" + destBank.Id + destAccount.AccId + DateTime.Now;
                        ac.TransactionHistory.Add(new Transaction { BankId = destBank.Id, DestinationBankId = sourceBank.Id, TransId = transid, UserId = destAccount.AccId, DestinationId = sourceAccount.AccId, Amount = amount, On = DateTime.Now, Type = TransactionType.Credit, Balance = destAccount.Balance });
                    }
                }
                
                json = JsonConvert.SerializeObject(list);
                File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json", json);
            }

            return true;
        }
    }
}