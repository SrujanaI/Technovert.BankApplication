using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.CLI.ConsoleFiles;
using Technovert.BankApp.Services;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class BankStaffCLI
    {
        public void BankStaffcli(string BankName)
        {
            ValidationService validationService = new ValidationService();
            InputsValidation inputsValidation = new InputsValidation();
            BankService bankService = new BankService();
            int count = 0;
            while (count == 0)
            {
                Console.WriteLine(" 0.Create Bank\n 1.Create Account\n 2.Update User Account\n 3.Delete User Account\n 4.Add Currency\n 5.Transaction History\n 6.Revert Transaction\n 7.Exit");
                BankStaffOptions bankStaffOptionSelection = (BankStaffOptions)Enum.Parse(typeof(BankStaffOptions), Console.ReadLine());
                switch (bankStaffOptionSelection)
                {
                    case BankStaffOptions.CreateBank:
                        bool b = (bankService.AddBank(BankName));
                        if (b)
                        {
                            Console.WriteLine("Bank Created Successfully");
                        }

                        while (!b)
                        {
                            Console.WriteLine("Already Bank Name exists!.. Enter the new bank name");
                            BankName = inputsValidation.UserInputString();
                            BankName = inputsValidation.CommonValidation(BankName, "BankName");
                            b = (bankService.AddBank(BankName));


                            if (b)
                            {
                                Console.WriteLine("Bank Created Successfully");
                            }

                        }
                        break;
                    case BankStaffOptions.CreateAccount:
                        CreateAccountCLI createAccountCLI = new CreateAccountCLI();
                        createAccountCLI.createBankStaff(BankName);
                        break;
                    case BankStaffOptions.UpdateAccount:
                        UpdateAccountCLI updateAccountCLI = new UpdateAccountCLI();
                        updateAccountCLI.UpdateAcc(BankName);
                        break;
                    case BankStaffOptions.Delete:
                        DeleteAccountCLI deleteAccountCLI = new DeleteAccountCLI();
                        deleteAccountCLI.DeleteAcc(BankName);
                        break;
                    case BankStaffOptions.AddCurrency:
                        Console.WriteLine("Enter currency type and it's factor to convert to INR");
                        DataStore.currency.Add(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()));
                        break;
                    case BankStaffOptions.TransactionHistory:
                        TransactionHistoryCLI transactionHistoryCLI = new TransactionHistoryCLI();
                        transactionHistoryCLI.transactionHistoryBankStaff(BankName);
                        break;
                    case BankStaffOptions.Revert:
                        RevertCLI revertCLI = new RevertCLI();
                        if (revertCLI.Revert(BankName))
                        {
                            Console.WriteLine("Successful!!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Details");
                        }

                        break;
                    case BankStaffOptions.Exit:
                        System.Console.WriteLine("Thank You!!");
                        count = 1;
                        break;
                    default:
                        Console.WriteLine("Choose correct opiton");
                        break;
                }
            }
        }
    }
}