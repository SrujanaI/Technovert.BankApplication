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
    public class TransferService
    {
        public bool Transfer(Bank sourceBank, Account sourceAccount, decimal amount, Bank destBank, Account destAccount)
        {
            decimal charges;
            decimal d = 1;
            StatusService status = new StatusService();
            AccountStatus sourceStatus=status.Status(sourceAccount);
            AccountStatus destStatus=status.Status(destAccount);
            if (sourceStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Source");
            }
            if (destStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Receiver");
            }
            if (sourceBank.BankName == destBank.BankName)
            {
                charges = Decimal.Multiply(d, amount);
            }
            else
            {
                charges = (((2) / 100) * amount) + (((6) / 100) * amount);
            }
            if ((amount+charges) > sourceAccount.Balance)
            {
                throw new Exception("Available amount is " + amount);
            }
            Console.WriteLine(charges);
            sourceAccount.Balance = sourceAccount.Balance - (amount+charges);
            destAccount.Balance = destAccount.Balance + amount;
            sourceAccount.UpdatedOn = DateTime.Now;
            sourceAccount.UpdatedBy = sourceAccount.AccId;

            string transid = "TXN" + sourceBank.BankId + sourceAccount.AccId + DateTime.Now;
            sourceAccount.TransactionHistory.Add(new Transaction { BankId =  sourceBank.BankId,DestinationBankId = destBank.BankName, TransId = transid, UserId = sourceAccount.AccId,DestinationId = destAccount.AccId, Amount = amount, On = DateTime.Now, Type = TransactionType.Debit, Balance = sourceAccount.Balance });
            transid = "TXN" + destBank.BankId + destAccount.AccId + DateTime.Now;
            destAccount.TransactionHistory.Add(new Transaction { BankId = destBank.BankId , DestinationBankId = sourceBank.BankName, TransId = transid, UserId = destAccount.AccId, DestinationId = sourceAccount.AccId, Amount = amount, On = DateTime.Now, Type = TransactionType.Credit ,Balance = destAccount.Balance});
            return true;
        }
    }
}