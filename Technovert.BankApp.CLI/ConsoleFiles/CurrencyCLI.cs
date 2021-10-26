using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Services;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class CurrencyCLI
    {
        InputsValidation inputsValidation = new InputsValidation();
        public void Currency()
        {
            foreach (KeyValuePair<string, decimal> ele in DataStore.currency)
            {
                Console.WriteLine(ele.Key);
            }
        }
        public string CurrencyValidation()
        {
            Console.WriteLine("Enter the currency type");
            string option = inputsValidation.UserInputString();
            while (!(DataStore.currency.ContainsKey(option)))
            {
                Console.WriteLine("Inavlid, Enter the existing currency type");
                option = inputsValidation.UserInputString();
            }
            return option;
        }
    }
}
