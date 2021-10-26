using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Models.Exceptions;
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
            string BankName;
            
            while (count == 0)
            {
                Console.WriteLine("Choose option to login as 1.account holder\n 2.bank staff\n 3.Exit");
                LoginType type = (LoginType)Enum.Parse(typeof(LoginType), System.Console.ReadLine());
                switch (type)
                {
                    case LoginType.AccountHolder:
                        Console.WriteLine("Select bank name from available banks");//for loop
                        //for (int i = 0; i < DataStore.Banks.Count; i++) Console.WriteLine(DataStore.Banks[i]+ " ");
                        foreach (Bank i in DataStore.Banks)
                        {
                            Console.WriteLine(i.BankName);
                        }
                        Console.WriteLine("Enter the bank name");
                        BankName = inputsValidation.UserInputString();
                        while(!(DataStore.Banks.Any(m => m.BankName == BankName)))
                        {
                            Console.WriteLine("Select bank name from available banks" + DataStore.Banks);
                            Console.WriteLine("Enter the bank name");
                            BankName = inputsValidation.UserInputString();
                        }
                        AccountHolderCLI accountHolderCLI = new AccountHolderCLI();
                        accountHolderCLI.AccHolder(BankName);
                        break;
                    case LoginType.BankStaff:
                        Console.WriteLine("Enter the bank name");
                        BankName = inputsValidation.UserInputString();
                        BankName = inputsValidation.CommonValidation(BankName, "BankName");
                        BankService bankService = new BankService();
                        BankStaffCLI bankStaffCLI = new BankStaffCLI();
                        try
                        {
                            bankService.AddBank(BankName);
                        }
                        catch (DuplicateBankNameException e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                        bankStaffCLI.BankStaffcli(BankName);
                        break;
                    case LoginType.Exit:
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