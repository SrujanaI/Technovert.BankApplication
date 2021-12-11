using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using System.Collections.Generic;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.CLI.ConsoleFiles;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DatabaseBank;

namespace Technovert.BankApp.CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StandardMessages.WelcomeMessage();
            InputsValidation inputsValidation = new InputsValidation();
            SQLCommands sQLCommands = new SQLCommands();
            int count = 0;
            string BankName;

            while (count == 0)
            {
                Console.WriteLine("Choose option to login as 1.account holder\n 2.bank staff\n 3.Exit");
                UserType type = (UserType)Enum.Parse(typeof(UserType), System.Console.ReadLine());
                switch (type)
                {
                    case UserType.AccountHolder:
                        Console.WriteLine("Select bank name from available banks");
                        sQLCommands.SelectBank();
                        bool value = false;
                        Console.WriteLine("Enter the bank name");
                        BankName = inputsValidation.UserInputString();
                        while (!value)
                        {
                            if (sQLCommands.CheckBankAvailability(BankName))
                            {
                                value = true;
                            }
                            else
                            {
                                Console.WriteLine("Select bank name from available banks");
                                sQLCommands.SelectBank();
                                Console.WriteLine("Enter the bank name");
                                BankName = inputsValidation.UserInputString();
                            }
                        }
                        AccountHolderCLI accountHolderCLI = new AccountHolderCLI();
                        accountHolderCLI.AccHolder(BankName);
                        break;
                    case UserType.BankStaff:

                        BankService bankService = new BankService();
                        BankStaffCLI bankStaffCLI = new BankStaffCLI();

                        Console.WriteLine("Enter the bank name");
                        BankName = inputsValidation.UserInputString();

                        bankStaffCLI.BankStaffcli(BankName);
                        break;
                    case UserType.Exit:
                        Console.WriteLine("Thank You!!");
                        count = 1;
                        break;
                    default:
                        Console.WriteLine("Enter valid number from 1-3");
                        break;
                }
            }
        }


    }

}