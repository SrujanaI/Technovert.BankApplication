using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;

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

                System.Console.WriteLine("Enter your CIF number");
                string cif = System.Console.ReadLine();
                try
                {
                    Account acc = validationService.DepositAccountValidity(BankName, AccId, cif);
                    inputsValidation.TransactionType("deposit");
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
                    System.Console.WriteLine(depositAmount.deposit(b.BankId, acc, amount));
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