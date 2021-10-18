using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;

namespace Technovert.BankApp.CLI
{
    public class TransactionTypesEnum
    {
        internal void TypeOfTransaction()
        {
            Console.WriteLine("Enter Transaction type");
            StandardMessages.TransactionOptions();
            TransactionType Option = (TransactionType)Enum.Parse(typeof(TransactionType), Console.ReadLine());
            switch (Option)
            {
                case TransactionType.Deposit:
                    DepositCLI depositCLI = new DepositCLI();
                    depositCLI.deposit();
                    break;
                case TransactionType.Withdraw:
                    WithdrawCLI withdrawCLI = new WithdrawCLI();
                    withdrawCLI.withdraw();
                    break;
                case TransactionType.Transfer:
                    TransferCLI transferCLI = new TransferCLI();
                    transferCLI.transfer();
                    break;
            }
        }
    }
}