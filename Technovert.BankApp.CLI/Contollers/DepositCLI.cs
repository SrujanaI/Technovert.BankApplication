using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.CLI
{
    internal class DepositCLI
    {
        public void deposit()
        {
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();
            inputsValidation.EnterBankName("your");
           
            string BankName = inputsValidation.UserInputString();
            BankName = inputsValidation.BankNameValidation(BankName, "Bank Name");

            string AccId ;
            decimal amt = 0;
            if (validationService.BankAvailability(BankName))
            {
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.AccountIdValidation(AccId);

                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();
                inputsValidation.BankNameValidation(password, "password");

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                
                if (validationService.AccountValidity(BankName, AccId, password))
                {

                    inputsValidation.TransactionType("deposit");
                    amt = inputsValidation.decimalInputsValidation(amt);
                    Console.WriteLine(depositAmount.deposit(BankName, AccId, amt));
                }
                else
                {
                    Console.WriteLine("Entered wrong details");
                }
            }
            else
            {
                Console.WriteLine("Entered wrong details");
            }
        }
    }
}