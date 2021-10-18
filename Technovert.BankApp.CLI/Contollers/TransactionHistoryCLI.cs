using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI
{
    internal class TransactionHistoryCLI
    {
        public void transactionHistory()
        {
            string AccId ;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            TransHistoryService transHistoryService = new TransHistoryService();

            inputsValidation.EnterBankName("your");
            string BankName = inputsValidation.UserInputString();
            BankName = inputsValidation.BankNameValidation(BankName, "Bank Name");
            
            if (validationService.BankAvailability(BankName))
            {
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.AccountIdValidation(AccId);
                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                if (validationService.AccountValidity(BankName, AccId, password))
                {
                    List<Transaction> list = transHistoryService.TransHistory(BankName, AccId);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine( "Transaction Id " + list[i].TransId + " UserId : " + list[i].UserId + "  Type : " + list[i].Type + "  Amount : " + list[i].Amount + "  Time : " + list[i].On + " Available Balance " + list[i].Balance);
                    }
                }
                else
                {
                    Console.WriteLine("Entered wrong account details");
                }
            }
            else
            {
                Console.WriteLine("Bank name doesn't exist");
            }
        }
    }
}