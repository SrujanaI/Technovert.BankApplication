using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.CLI.ConsoleFiles;
using Technovert.BankApp.Services.ServiceFiles;
using Technovert.BankApp.Services;


namespace Technovert.BankApp.CLI
{
    public class BankStaffCLI
    {
        public void BankStaffcli(string BankName)
        {
            ValidationService validationService = new ValidationService();
            int count = 0;
            while (count == 0)
            {
                Console.WriteLine("1.Create Account\n 2.Update User Account\n 3.Delete User Account\n 4.Add Currency\n 5.Transaction History\n 6.Revert Transaction\n 7.Exit"); 
                BankStaffOptionSelection bankStaffOptionSelection = (BankStaffOptionSelection)Enum.Parse(typeof(BankStaffOptionSelection), Console.ReadLine());
                switch (bankStaffOptionSelection)
                {
                    case BankStaffOptionSelection.Create:
                        CreateAccountCLI createAccountCLI = new CreateAccountCLI();
                        createAccountCLI.createBankStaff(BankName);
                        break;
                    case BankStaffOptionSelection.UpdateAccount:
                        UpdateAccountCLI updateAccountCLI = new UpdateAccountCLI();
                        updateAccountCLI.UpdateAcc(BankName);
                        break;
                    case BankStaffOptionSelection.Delete:
                        DeleteAccountCLI deleteAccountCLI = new DeleteAccountCLI();
                        deleteAccountCLI.DeleteAcc(BankName);
                        break;
                    case BankStaffOptionSelection.AddCurrency:
                        Console.WriteLine("Enter currency type and it's factor to convert to INR");
                        DataStore.currency.Add(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()));
                        break;
                    case BankStaffOptionSelection.TransactionHistory:
                        TransactionHistoryCLI transactionHistoryCLI = new TransactionHistoryCLI();
                        transactionHistoryCLI.transactionHistoryBankStaff(BankName);
                        break;
                    case BankStaffOptionSelection.Revert:

                        break;
                    case BankStaffOptionSelection.Exit:
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
