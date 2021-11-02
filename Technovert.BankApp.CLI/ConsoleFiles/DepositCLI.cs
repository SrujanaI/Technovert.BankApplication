using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;


namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class DepositCLI
    {
        public void Deposit(string BankName)
        {
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();


            string AccId;
            decimal amount = 0;

            try
            {
                Bank bank = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.CommonValidation(AccId, "AccId");

                Console.WriteLine("Enter your CIF number");
                string CIF = Console.ReadLine();
                try
                {
                    CurrencyCLI currencyCLI = new CurrencyCLI();
                    currencyCLI.Currency();
                    Account account = validationService.DepositAccountValidity(BankName, AccId, CIF);


                    while (true)
                    {
                        try
                        {
                            string option = currencyCLI.CurrencyValidation();
                            inputsValidation.TransactionType("deposit");
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
                        if (depositAmount.Deposit(bank.Id, account, amount))
                            Console.WriteLine("Deposited amount");
                        else
                            Console.WriteLine("Depositing money failed");
                    }
                    catch (AccountClosedException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (AccountNotAvailableException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            catch (BankNotAvailableException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}