using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.Services
{
    public class TransferService
    {
        public string Transfer(string SourceBankName, string SourceAccNum, decimal amount, string DestBankName, string DestAccNum)
        {
            Bank srcBank = DataStore.Banks.Single(m => m.Name == SourceBankName);
            Account srcAccount = srcBank.AccLists.Single(m => m.UserId == SourceAccNum);
            Bank destBank = DataStore.Banks.Single(m => m.Name == DestBankName);
            Account destAccount = destBank.AccLists.Single(m => m.UserId == DestAccNum);
            StatusService status = new StatusService();
            status.Status(srcAccount);
            status.Status(destAccount);
            if (srcAccount.Status == AccountStatus.Closed)
            {
                return "Source Account Doesnot exist or closed";
            }
            if (destAccount.Status == AccountStatus.Closed)
            {
                return "Destination Account Doesnot exist or closed";
            }

            if (amount > srcAccount.Balance)
            {
                throw new Exception("Available amount is " + amount);
            }
            srcAccount.Balance = srcAccount.Balance - amount;
            destAccount.Balance = destAccount.Balance + amount;
            srcAccount.UpdatedOn = DateTime.Now;
            srcAccount.UpdatedBy = SourceAccNum;

            string transid = "TXN" + srcBank.BankId + srcAccount.UserId + DateTime.Now;
            srcAccount.TransactionHistory.Add(new Transaction { BankId =  SourceBankName,DestinationBankId = DestBankName, TransId = transid, UserId = SourceAccNum,DestinationId = DestAccNum, Amount = amount, On = DateTime.Now, Type = TransactionType.Debit, Balance = srcAccount.Balance });
            destAccount.TransactionHistory.Add(new Transaction { BankId = DestBankName , DestinationBankId = SourceBankName, TransId = transid, UserId = DestAccNum, DestinationId = SourceAccNum, Amount = amount, On = DateTime.Now, Type = TransactionType.Credit ,Balance = destAccount.Balance});
            return "Transferred " + amount;
        }
    }
}