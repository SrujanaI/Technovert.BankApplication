using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using System.Collections.Generic;

namespace Technovert.BankApp.CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StandardMessages.WelcomeMessage();
            int count = 0;
            while (count == 0)
            {
                StandardMessages.Options();
                OptionSelection Option = (OptionSelection)Enum.Parse(typeof(OptionSelection), Console.ReadLine());
                switch (Option)
                {
                    case OptionSelection.CreateAccount:
                        CreateAccountCLI createAccountCLI = new CreateAccountCLI();
                        createAccountCLI.create();
                        break;
                    case OptionSelection.TypeOfTransaction:
                        TransactionTypesEnum transTypes = new TransactionTypesEnum();
                        transTypes.TypeOfTransaction();
                        break;
                    case OptionSelection.TransactionHistory:
                        TransactionHistoryCLI transactionHistoryCLI = new TransactionHistoryCLI();
                        transactionHistoryCLI.transactionHistory();
                        break;
                    case OptionSelection.Exit:
                        Console.WriteLine("Thank You!!");
                        count = 1;
                        break;
                }
            }      
        }
    }
}