using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI
{
    internal class TransferCLI
    {
        public void transfer()
        {
            string SourceAccNum , DestAccNum ;
            decimal amt = 0;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            TransferService transferService = new TransferService();

            inputsValidation.EnterBankName("Sender");
            string SourceBankName = inputsValidation.UserInputString();
            SourceBankName = inputsValidation.BankNameValidation(SourceBankName, "Source Bank Name");

            inputsValidation.EnterBankName("Receiver");
            string DestBankName = inputsValidation.UserInputString();
            DestBankName = inputsValidation.BankNameValidation(DestBankName, "Destination Bank Name");

            if (validationService.BankAvailability(SourceBankName) && validationService.BankAvailability(DestBankName))
            {
                inputsValidation.EnterAccNum("your");
                SourceAccNum = inputsValidation.UserInputString();
                SourceAccNum = inputsValidation.AccountIdValidation(SourceAccNum);
                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                inputsValidation.EnterAccNum("Receiver");
                DestAccNum = inputsValidation.UserInputString();
                DestAccNum = inputsValidation.AccountIdValidation(DestAccNum);
                if (validationService.AccountValidity(SourceBankName, SourceAccNum, password) && validationService.DesAccountValidity(DestBankName, DestAccNum))
                {
                    inputsValidation.TransactionType("transfer");
                    amt = inputsValidation.decimalInputsValidation(amt);
                    Console.WriteLine(transferService.Transfer(SourceBankName, SourceAccNum, amt, DestBankName, DestAccNum));
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