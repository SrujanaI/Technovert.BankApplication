using System;
using System.Collections.Generic;
using System.Linq;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class DeleteAccountCLI
    {
        public void DeleteAcc(string BankName)
        {
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();
            string AccId;

            try
            {
                Bank b = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                using (StreamReader reader = new StreamReader(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json"))
                {
                    try
                    {
                        string json = reader.ReadToEnd();
                        reader.Close();
                        var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                        foreach (Bank ba in list)
                        {
                            if (ba.BankName == BankName)
                            {
                                Account ac = ba.AccLists.Single(m => m.AccId == AccId);
                                ba.AccLists.Remove(ac);
                            }
                        }
                        json = JsonConvert.SerializeObject(list);
                        File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json", json);
                    }
                    /*try
                    {
                        Account account = validationService.UpdateorDeleteAccountValidity(BankName, AccId);
                        b.AccLists.Remove(account);
                    }*/
                    catch (AccountNotAvailableException e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                }

            }
            catch (BankNotAvailableException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}