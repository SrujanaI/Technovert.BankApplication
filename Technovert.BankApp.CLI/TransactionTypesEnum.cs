using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using Technovert.BankApp.CLI.ConsoleFiles;

namespace Technovert.BankApp.CLI
{
    public class TransactionTypesEnum
    {
        internal void TypeOfTransaction(string BankName)
        {
            System.Console.WriteLine("Enter Transaction type");
            StandardMessages.TransactionOptions();
            TransactionType Option = (TransactionType)Enum.Parse(typeof(TransactionType), System.Console.ReadLine());
            switch (Option)
            {
                case TransactionType.Deposit:
                    DepositCLI depositCLI = new DepositCLI();
                    depositCLI.Deposit(BankName);
                    break;
                case TransactionType.Withdraw:
                    WithdrawCLI withdrawCLI = new WithdrawCLI();
                    withdrawCLI.Withdraw(BankName);
                    break;
                case TransactionType.Transfer:
                    TransferCLI transferCLI = new TransferCLI();
                    transferCLI.Transfer(BankName);
                    break;
            }
        }
    }
}