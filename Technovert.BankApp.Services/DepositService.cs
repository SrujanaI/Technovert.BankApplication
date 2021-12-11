using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Newtonsoft.Json;
using System.IO;
using DatabaseBank;

namespace Technovert.BankApp.Services
{
    public class DepositService
    {

        public bool Deposit(string BankId, string AccId, decimal amt)
        {
            SQLCommands sQLCommands = new SQLCommands();
            StatusService status = new StatusService();
            /*AccountStatus accStatus = status.Status(account);
            if (accStatus == AccountStatus.Closed)
            {
                throw new AccountClosedException("Your Account Is Closed");
            }*/
            string transid = "TXN" + BankId + AccId + DateTime.Now;
            
            sQLCommands.UpdateAccount(AccId, amt, DateTime.Now);
            sQLCommands.InsertTransaction(transid, AccId, BankId, Convert.ToDecimal(sQLCommands.SelectAccountProperty(AccId, "Balance")) + amt, DateTime.Now, amt, "", "");
            return true;
        }
            
    }
}