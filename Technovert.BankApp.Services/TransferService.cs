using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using DatabaseBank;

namespace Technovert.BankApp.Services
{
    public class TransferService
    {
        public bool Transfer(string sourceBankName, string sourceAccountId, decimal amount, string destBankName, string destAccountId)
        {
            decimal charges;
            SQLCommands sQLCommands = new SQLCommands();
            StatusService status = new StatusService();
            /*AccountStatus sourceStatus = status.Status(sourceAccount);
            AccountStatus destStatus = status.Status(destAccount);
            if (sourceStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Source Account Is Closed");
            }
            if (destStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Deposit Account Is Closed");
            }*/
            if (sourceBankName == destBankName)
            {
                charges = Convert.ToDecimal(sQLCommands.SelectBankProperty(sourceBankName, "IMPSSameBank")) * amount;
            }
            else
            {
                charges = Convert.ToDecimal(sQLCommands.SelectBankProperty(sourceBankName, "IMPSSameBank")) * amount + Convert.ToDecimal(sQLCommands.SelectBankProperty(sourceBankName, "RTGS")) * amount;
            }
            if ((amount + charges) > Convert.ToDecimal(sQLCommands.SelectAccountProperty(sourceAccountId,"Balance")))
            {
                throw new Exception("Available amount is " + Convert.ToDecimal(sQLCommands.SelectAccountProperty(sourceAccountId, "Balance")));
            }

            string transid = "TXN" + sQLCommands.SelectBankProperty(sourceBankName,"Id") + sQLCommands.SelectAccountProperty(sourceAccountId, "Id") + DateTime.Now;
            sQLCommands.UpdateAccount(sQLCommands.SelectAccountProperty(sourceAccountId, "Id"), -(amount+charges), DateTime.Now);
            sQLCommands.InsertTransaction(transid, sQLCommands.SelectAccountProperty(sourceAccountId, "Id"), sQLCommands.SelectBankProperty(sourceBankName, "Id"), Convert.ToDecimal(sQLCommands.SelectAccountProperty(sourceAccountId, "Balance")) - (amount+charges), DateTime.Now, amount, sQLCommands.SelectAccountProperty(destAccountId, "Id"), sQLCommands.SelectBankProperty(destBankName, "Id"));
            transid = "TXN" + sQLCommands.SelectBankProperty(destBankName, "Id") + sQLCommands.SelectAccountProperty(destAccountId, "Id") + DateTime.Now;
            sQLCommands.UpdateAccount(sQLCommands.SelectAccountProperty(destAccountId, "Id"), amount, DateTime.Now);
            sQLCommands.InsertTransaction(transid, sQLCommands.SelectAccountProperty(destAccountId, "Id"), sQLCommands.SelectBankProperty(destBankName, "Id"), Convert.ToDecimal(sQLCommands.SelectAccountProperty(destAccountId, "Balance")) + amount, DateTime.Now, amount, sQLCommands.SelectAccountProperty(sourceAccountId, "Id"), sQLCommands.SelectBankProperty(sourceBankName, "Id"));


            return true;
        }
    }
}