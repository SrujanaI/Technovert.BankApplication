﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Services.Services
{
    public class WithdrawAmount
    {
        public string Withdraw(Bank bank, Account acc, decimal amt)
        {
            StatusService status = new StatusService();
            AccountStatus s=status.Status(acc);
            if (s == AccountStatus.Closed)
            {
                return "Account Doesnot exist or closed";
            }
            if (amt > acc.Balance)
            {
                return "Availabe Balance is " + amt;
            }
            acc.Balance = acc.Balance - amt;
            acc.UpdatedOn = DateTime.Now;
            acc.UpdatedBy = acc.AccId;
            string transid = "TXN" + bank.BankId + acc.AccId + DateTime.Now;
            acc.TransactionHistory.Add(new Transaction { BankId = bank.BankId,TransId = transid,UserId = acc.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Withdraw, Balance = acc.Balance }) ;
            return amt + " is Withdrawn";
        }
    }
}