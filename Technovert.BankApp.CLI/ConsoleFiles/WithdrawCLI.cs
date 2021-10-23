using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class WithdrawCLI
    {
        public void withdraw(string BankName)
        {
            string  AccId ;
            decimal amt = 0;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            WithdrawAmount withdrawAmount = new WithdrawAmount();

            try
            {
                Bank bank = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId=inputsValidation.CommonValidation(AccId, "AccId");

                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();
                password=inputsValidation.CommonValidation(password, "password");

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                try
                {
                    Account acc = validationService.AccountValidity(BankName, AccId, password);
                    inputsValidation.TransactionType("Withdraw");
                    while (true)
                    {
                        try
                        {
                            amt = inputsValidation.decimalInputsValidation(amt);
                            break;
                        }
                        catch (AmountFormatException e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                    }
                    System.Console.WriteLine(withdrawAmount.Withdraw(bank, acc, amt));
                }
                catch (AccNotAvailableException e)
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