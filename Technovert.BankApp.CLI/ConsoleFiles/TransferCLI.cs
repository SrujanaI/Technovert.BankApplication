using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services.Services;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class TransferCLI
    {
        public void transfer(string SourceBankName)
        {
            string SourceAccNum , DestAccNum ;
            decimal amount = 0;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            TransferService transferService = new TransferService();

            inputsValidation.EnterBankName("Receiver");
            string DestBankName = inputsValidation.UserInputString();
            DestBankName=inputsValidation.CommonValidation(DestBankName, "Destination Bank BankName");
            try
            {
                Bank sourceBank = validationService.BankAvailability(SourceBankName);
                Bank destBank = validationService.BankAvailability(DestBankName);
                inputsValidation.EnterAccNum("your");
                SourceAccNum = inputsValidation.UserInputString();
                SourceAccNum=inputsValidation.CommonValidation(SourceAccNum, "SourceAccNum");
                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();
                password=inputsValidation.CommonValidation(password, "password");

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                inputsValidation.EnterAccNum("Receiver");
                DestAccNum = inputsValidation.UserInputString();
                DestAccNum=inputsValidation.CommonValidation(DestAccNum, "DestAccNum");

                try
                {
                    Account sourceAccount = validationService.AccountValidity(SourceBankName, SourceAccNum, password);
                    Account destAccount = validationService.DesAccountValidity(DestBankName, DestAccNum);
                    inputsValidation.TransactionType("transfer");
                    while (true)
                    {
                        try
                        {
                            amount = inputsValidation.decimalInputsValidation(amount);
                            break;
                        }
                        catch (AmountFormatException e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                    }
                    System.Console.WriteLine(transferService.Transfer(sourceBank, sourceAccount, amount, destBank, destAccount));
                }
                catch(AccNotAvailableException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
            catch(BankNotAvailableException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}