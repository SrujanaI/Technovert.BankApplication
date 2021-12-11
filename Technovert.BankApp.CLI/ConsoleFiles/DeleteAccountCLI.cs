using System;
using System.Collections.Generic;
using System.Linq;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DatabaseBank;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class DeleteAccountCLI
    {
        public void DeleteAcc(string BankName)
        {
            SQLCommands sQLCommands = new SQLCommands();
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();
            string AccountId;


            if (sQLCommands.CheckBankAvailability(BankName))
            {
                string BankId = sQLCommands.SelectBankProperty(BankName, "Id");
                inputsValidation.EnterAccNum("your");
                AccountId = inputsValidation.UserInputString();
                if (sQLCommands.CheckAccountAvailability(AccountId))
                {
                    sQLCommands.DeleteAccount(AccountId);
                }
                else
                {
                    Console.WriteLine("Account not available");
                }
            }
            else
            {
                throw new NullValueException("bank");
            }

        }
    }
}