using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Services.Services
{
    public class TransferService
    {
        public string Transfer(Bank sourceBank, Account sourceAccount, decimal amount, Bank destBank, Account destAccount)
        {
            
            StatusService status = new StatusService();
            AccountStatus sourceStatus=status.Status(sourceAccount);
            AccountStatus destStatus=status.Status(destAccount);
            if (sourceStatus == AccountStatus.Closed)
            {
                return "Source Account Doesnot exist or closed";
            }
            if (destStatus == AccountStatus.Closed)
            {
                return "Destination Account Doesnot exist or closed";
            }

            if (amount > sourceAccount.Balance)
            {
                throw new Exception("Available amount is " + amount);
            }
            sourceAccount.Balance = sourceAccount.Balance - amount;
            destAccount.Balance = destAccount.Balance + amount;
            sourceAccount.UpdatedOn = DateTime.Now;
            sourceAccount.UpdatedBy = sourceAccount.AccId;

            string transid = "TXN" + sourceBank.BankId + sourceAccount.AccId + DateTime.Now;
            sourceAccount.TransactionHistory.Add(new Transaction { BankId =  sourceBank.BankId,DestinationBankId = destBank.BankName, TransId = transid, UserId = sourceAccount.AccId,DestinationId = destAccount.AccId, Amount = amount, On = DateTime.Now, Type = TransactionType.Debit, Balance = sourceAccount.Balance });
            transid = "TXN" + destBank.BankId + destAccount.AccId + DateTime.Now;
            destAccount.TransactionHistory.Add(new Transaction { BankId = destBank.BankId , DestinationBankId = sourceBank.BankName, TransId = transid, UserId = destAccount.AccId, DestinationId = sourceAccount.AccId, Amount = amount, On = DateTime.Now, Type = TransactionType.Credit ,Balance = destAccount.Balance});
            return "Transferred " + amount;
        }
    }
}