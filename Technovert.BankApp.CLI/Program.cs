using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Services;
using System.Collections.Generic;
using Technovert.BankApp.CLI.ConsoleFiles;

namespace Technovert.BankApp.CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StandardMessages.WelcomeMessage();
            InputsValidation inputsValidation = new InputsValidation();
            int count = 0;

            Console.WriteLine("Enter the bank name");
            string BankName = inputsValidation.UserInputString();
            BankName = inputsValidation.CommonValidation(BankName, "BankName");
            Console.WriteLine("Choose option to login as 1.account holder\n 2.bank staff");
            LoginType type = (LoginType)Enum.Parse(typeof(LoginType), System.Console.ReadLine());
            
            switch (type)
            {
                case LoginType.AccountHolder:
                    AccountHolderCLI accountHolderCLI = new AccountHolderCLI();
                    accountHolderCLI.AccHolder(BankName);
                    break;
                case LoginType.BankStaff:
                    BankStaffCLI bankStaffCLI = new BankStaffCLI();
                    bankStaffCLI.BankStaffcli(BankName);
                    break;
            }
               
        }
    }
}