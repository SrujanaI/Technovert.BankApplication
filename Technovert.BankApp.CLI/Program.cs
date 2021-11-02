using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using System.Collections.Generic;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Models.Exceptions;
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
            string BankName;

            while (count == 0)
            {
                Console.WriteLine("Choose option to login as 1.account holder\n 2.bank staff\n 3.Exit");
                UserType type = (UserType)Enum.Parse(typeof(UserType), System.Console.ReadLine());
                switch (type)
                {
                    case UserType.AccountHolder:
                        Console.WriteLine("Select bank name from available banks");//for loop
                        //for (int i = 0; i < DataStore.Banks.Count; i++) Console.WriteLine(DataStore.Banks[i]+ " ");
                        foreach (Bank i in DataStore.Banks)
                        {
                            Console.WriteLine(i.BankName);
                        }
                        Console.WriteLine("Enter the bank name");
                        BankName = inputsValidation.UserInputString();
                        while (!(DataStore.Banks.Any(m => m.BankName == BankName)))
                        {
                            Console.WriteLine("Select bank name from available banks" + DataStore.Banks);
                            Console.WriteLine("Enter the bank name");
                            BankName = inputsValidation.UserInputString();
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