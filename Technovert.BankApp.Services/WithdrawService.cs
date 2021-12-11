using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using System.IO;
using Newtonsoft.Json;
using DatabaseBank;

namespace Technovert.BankApp.Services
{
    public class WithdrawAmount
    {
        public bool Withdraw(string BankName, string AccId, decimal amt)
        {
            SQLCommands sQLCommands = new SQLCommands();
            StatusService status = new StatusService();
            /*AccountStatus s = status.Status(acc);
            if (s == AccountStatus.Closed)
            {
                throw new AccountClosedException("Your Account Is Closed");
                *//*return "Account Doesnot exist or closed"*//*
            }*/
            string transid = "TXN" + sQLCommands.SelectBankProperty(BankName, "Id") + sQLCommands.SelectAccountProperty(AccId,"Id") + DateTime.Now;
            sQLCommands.UpdateAccount(sQLCommands.SelectAccountProperty(AccId, "Id"), (-1*amt), DateTime.Now);
            sQLCommands.InsertTransaction(transid, sQLCommands.SelectAccountProperty(AccId, "Id"), sQLCommands.SelectBankProperty(BankName, "Id"), Convert.ToDecimal(sQLCommands.SelectAccountProperty(AccId,"Balance")) - amt, DateTime.Now, amt, "", "");
            return true;
            
        }
    }
}