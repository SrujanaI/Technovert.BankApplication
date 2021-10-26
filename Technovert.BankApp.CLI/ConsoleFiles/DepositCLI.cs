using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services.ServiceFiles;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Services;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class DepositCLI
    {
        public void deposit(string BankName)
        {
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();
            

            string AccId;
            decimal amount = 0;
            
            try
            {
                Bank b=validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId=inputsValidation.CommonValidation(AccId,"AccId");
                
                Console.WriteLine("Enter your CIF number");
                string cif = System.Console.ReadLine();
                try
                {
                    CurrencyCLI currencyCLI = new CurrencyCLI();
                    currencyCLI.Currency();
                    Account acc = validationService.DepositAccountValidity(BankName, AccId, cif);
                    
                    
                    while (true)
                    {
                        try
                        {
                            string option = currencyCLI.CurrencyValidation();
                            inputsValidation.TransactionType("deposit");
                            amount = inputsValidation.decimalInputsValidation(amount);
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
                        if (depositAmount.deposit(b.BankId, acc, amount)) Console.WriteLine("Deposited amount");
                        else Console.WriteLine("Depositing money failed");
                    }
                    catch(AccountClosedException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (AccNotAvailableException e)
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