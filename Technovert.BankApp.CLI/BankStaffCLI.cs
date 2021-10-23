using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.CLI.ConsoleFiles;
using Technovert.BankApp.Services.Services;


namespace Technovert.BankApp.CLI
{
    public class BankStaffCLI
    {
        public void BankStaffcli(string BankName)
        {
            ValidationService validationService = new ValidationService();
            BankStaffOptionSelection bankStaffOptionSelection = (BankStaffOptionSelection)Enum.Parse(typeof(BankStaffOptionSelection), Console.ReadLine());
            switch (bankStaffOptionSelection)
            {
                case BankStaffOptionSelection.Create:
                    CreateAccountCLI createAccountCLI = new CreateAccountCLI();
                    createAccountCLI.create(BankName);
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
                    CurrencyCLI.currency.Add(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()));
                    break;
            }
        }
    }
}
