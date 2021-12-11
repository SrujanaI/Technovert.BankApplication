using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DatabaseBank;

namespace Technovert.BankApp.Services
{
    public class ValidationService
    {
        SQLCommands sQLCommands = new SQLCommands();
        public void BankAvailability(string BankName)
        {
            if (!(sQLCommands.CheckBankAvailability(BankName)))
            {
                throw new BankNotAvailableException();
            }
            
        }
        public void AccountValidity(string BankName, string AccId, string password)
        {
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                if (!(sQLCommands.CheckAccountAvailability(AccId)))
                {
                    throw new AccountNotAvailableException();
                }
            }
            else
            {
                throw new BankNotAvailableException();
            }
            
        }
        public void UpdateorDeleteAccountValidity(string BankName, string AccId)
        {
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                if (!(sQLCommands.CheckAccountAvailability(AccId)))
                {
                    throw new AccountNotAvailableException();
                }
            }
            else
            {
                throw new BankNotAvailableException();
            }
            
        }
        public void DepositAccountValidity(string BankName, string AccId, string cif)
        {
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                if (!(sQLCommands.CheckAccountAvailability(AccId)))
                {
                    throw new AccountNotAvailableException();
                }
            }
            else
            {
                throw new BankNotAvailableException();
            }
            
            }
        public void DesAccountValidity(string BankName, string AccId)
        {
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                if (!(sQLCommands.CheckAccountAvailability(AccId)))
                {
                    throw new AccountNotAvailableException();
                }
            }
            else
            {
                throw new BankNotAvailableException();
            }
            
        }
        /*public void UpdateMobile(string Mobile, string BankName, string AccId)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json"))
                {
                    string json = reader.ReadToEnd();
                    reader.Close();
                    var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                    foreach (var ba in list)
                    {
                        if (ba.BankName == BankName)
                        {
                            Account ac = ba.AccLists.SingleOrDefault(m => m.AccId == AccId);
                            ac.Mobile = Mobile;
                        }
                    }
                    saveJson(list);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }

        }
        
        public void saveJson(List<Bank> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services\Bank.json", json);
        }*/
    }
}