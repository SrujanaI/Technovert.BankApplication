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
    internal class WithdrawCLI
    {
        public void Withdraw(string BankName)
        {
            string AccId;
            decimal amount = 0;
            InputsValidation inputsValidation = new InputsValidation();
            ValidationService validationService = new ValidationService();
            WithdrawAmount withdrawAmount = new WithdrawAmount();

            try
            {
                Bank bank = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.CommonValidation(AccId, "AccId");

                inputsValidation.EnterPassword();
                string password = inputsValidation.UserInputString();
                password = inputsValidation.CommonValidation(password, "password");

                PasswordEncryption passwordEncryption = new PasswordEncryption();
                password = passwordEncryption.EncryptPlainTextToCipherText(password);

                CurrencyCLI currencyCLI = new CurrencyCLI();
                currencyCLI.Currency();

                try
                {
                    Account account = validationService.AccountValidity(BankName, AccId, password);

                    while (true)
                    {
                        try
                        {
                            string option = currencyCLI.CurrencyValidation();
                            inputsValidation.TransactionType("Withdraw");
                            amount = inputsValidation.DecimalInputsValidation(amount);
                            amount = amount * DataStore.currency[option];

                            break;
                        }
                        catch (AmountFormatException e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                    }
                    try
                    {
                        if (withdrawAmount.Withdraw(bank, account, amount)) Console.WriteLine("Withdraw is successful");
                    }
                    catch (AccountClosedException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (InsufficientAmountException e)
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