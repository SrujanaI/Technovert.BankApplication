using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.CLI.ConsoleFiles;

namespace Technovert.BankApp.CLI
{
    public class AccountHolderCLI
    {
        public void AccHolder(string BankName)
        {
            int count = 0;
            while (count == 0)
            {
                StandardMessages.Options();
                OptionSelection Option = (OptionSelection)Enum.Parse(typeof(OptionSelection), System.Console.ReadLine());
                switch (Option)
                {
                    case OptionSelection.CreateAccount:
                        CreateAccountCLI createAccountCLI = new CreateAccountCLI();
                        createAccountCLI.create(BankName);
                        break;
                    case OptionSelection.TypeOfTransaction:
                        TransactionTypesEnum transTypes = new TransactionTypesEnum();
                        transTypes.TypeOfTransaction(BankName);
                        break;
                    case OptionSelection.TransactionHistory:
                        TransactionHistoryCLI transactionHistoryCLI = new TransactionHistoryCLI();
                        transactionHistoryCLI.transactionHistory(BankName);
                        break;
                    case OptionSelection.Exit:
                        System.Console.WriteLine("Thank You!!");
                        count = 1;
                        break;
                    default:
                        System.Console.WriteLine("Enter valid number from 1-4");
                        break;
                }
            }
        }
    }
}
