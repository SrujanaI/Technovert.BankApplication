using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Services;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class CurrencyCLI
    {
        public void Currency()
        {
            for (int i = 0; i < DataStore.currency.Count; i++)
            {
                Console.WriteLine(DataStore.currency.ElementAt(i).Key);
            }
        }
    }
}
