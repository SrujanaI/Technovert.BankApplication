using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI
{
    internal class WithdrawCLI
    {
        public void withdraw()
        {
            string  AccId ;
            decimal amt = 0;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            WithdrawAmount withdrawAmount = new WithdrawAmount();

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
                    inputsValidation.TransactionType("Withdraw");
                    amt = inputsValidation.decimalInputsValidation(amt);
                    Console.WriteLine(withdrawAmount.Withdraw(BankName, AccId, amt));
                }
            }
        }
    }
}