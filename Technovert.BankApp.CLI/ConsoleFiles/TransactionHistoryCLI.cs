using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Services;
using DatabaseBank;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class TransactionHistoryCLI
    {
        SQLCommands sQLCommands = new SQLCommands();
        public void transactionHistoryAccountHolder(string BankName)
        {
            string AccId;
            
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            TransHistoryService transHistoryService = new TransHistoryService();

            try
            {
                validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.CommonValidation(AccId, "AccId");
                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();
                password = inputsValidation.CommonValidation(password, "password");
                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                try
                {
                    validationService.AccountValidity(BankName, AccId, password);
                    sQLCommands.SelectTransactionHistory(AccId);
                    /*List<Transaction> list = transHistoryService.TransHistory(acc);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine("Transaction Id " + list[i].TransId + " AccId : " + list[i].UserId + "  Type : " + list[i].Type + "  Amount : " + list[i].Amount + "  Time : " + list[i].On + " Available Balance " + list[i].Balance);
                    }*/
                }
                catch (AccountNotAvailableException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
            catch (BankNotAvailableException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }


        public void transactionHistoryBankStaff(string BankName)
        {
            string AccId;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            TransHistoryService transHistoryService = new TransHistoryService();

            try
            {
                validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.CommonValidation(AccId, "AccId");


                try
                {
                    validationService.UpdateorDeleteAccountValidity(BankName, AccId);
                    sQLCommands.SelectTransactionHistory(AccId);
                    /*List<Transaction> list = transHistoryService.TransHistory(acc);
                    for (int i = 0; i < list.Count; i++)
                    {
                        System.Console.WriteLine("Transaction Id " + list[i].TransId + " AccId : " + list[i].UserId + "  Type : " + list[i].Type + "  Amount : " + list[i].Amount + "  Time : " + list[i].On + " Available Balance " + list[i].Balance);
                    }*/
                }
                catch (AccountNotAvailableException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
            catch (BankNotAvailableException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}