using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class TransferCLI
    {
        public void Transfer(string SourceBankName)
        {
            string SourceAccNum, DestAccNum;
            decimal amount = 0;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            TransferService transferService = new TransferService();

            inputsValidation.EnterBankName("Receiver");
            string DestBankName = inputsValidation.UserInputString();

            try
            {
                Bank sourceBank = validationService.BankAvailability(SourceBankName);
                Bank destBank = validationService.BankAvailability(DestBankName);

                inputsValidation.EnterAccNum("your");
                SourceAccNum = inputsValidation.UserInputString();
                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                inputsValidation.EnterAccNum("Receiver");
                DestAccNum = inputsValidation.UserInputString();

                CurrencyCLI currencyCLI = new CurrencyCLI();
                currencyCLI.Currency();

                try
                {
                    Account sourceAccount = validationService.AccountValidity(SourceBankName, SourceAccNum, password);
                    Account destAccount = validationService.DesAccountValidity(DestBankName, DestAccNum);
                    while (true)
                    {
                        try
                        {
                            string option = currencyCLI.CurrencyValidation();
                            inputsValidation.TransactionType("transfer");
                            amount = inputsValidation.DecimalInputsValidation(amount);
                            amount = amount * DataStore.currency[option];

                            break;
                        }
                        catch (AmountFormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    try
                    {
                        if (transferService.Transfer(sourceBank, sourceAccount, amount, destBank, destAccount))
                        {
                            Console.WriteLine("Transfer Successfull");
                        }
                        else
                        {
                            Console.WriteLine("Transfer Failed");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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