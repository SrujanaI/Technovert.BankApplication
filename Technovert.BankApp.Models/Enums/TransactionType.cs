using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models
{
    public enum TransactionType
    {
        Create = 0,
        Deposit,
        Withdraw,
        Transfer,
        Credit,
        Debit,
        Revert
    }

}