using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Newtonsoft.Json.Linq;
using DatabaseBank;

namespace Technovert.BankApp.Services
{
    public class BankService
    {
        SQLCommands sQLCommands = new SQLCommands();
        public bool AddBank(string name)
        { 
            if (sQLCommands.CheckBankAvailability(name))
            {
                return false;
            }
            
            Bank bank = new Bank
            {
                Id = this.GenerateBankId(name),
                BankName = name,
                CreatedOn = DateTime.Now

            };
            sQLCommands.InsertBank(bank.Id,bank.BankName,bank.CreatedOn);
            
            DataStore.Banks.Add(bank);
            
            return true;
        }
        public Tuple<string,string> CreateAccount(string BankName, string name, string Password, string mobile, string gender)
        {
            string id, CIF;
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                string BankId = sQLCommands.SelectBankProperty(BankName,"Id");
                if (sQLCommands.CheckNewAccountAvailability(name))
                {
                    throw new DuplicateUserNameException();
                }
                else
                {
                    id = this.GenerateUserId(name);
                    CIF = GenerateCIF();
                    
                    sQLCommands.InsertAccount(id, name, 0, Password, mobile, DateTime.Now, gender, name, DateTime.Now, CIF);
                    string transid = "TXN" + BankId + id + DateTime.Now;
                    sQLCommands.InsertTransaction(transid, id, BankId, 0, DateTime.Now, 0, "", "");
                }
            }
            else
            {
                throw new NullValueException("bank");
            }
            return Tuple.Create(id,CIF);
            
            
        }

        public string CreateAccountBankStaff(string BankName, string name, string Password, string mobile)
        {
            string id;
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                string BankId = sQLCommands.SelectBankProperty(BankName,"Id");
                if (sQLCommands.CheckNewAccountAvailability(name))
                {
                    throw new DuplicateUserNameException();
                }
                else
                {
                    id = this.GenerateUserId(name);
                    //AccId = id, AccName = name, Balance = 0, Password = Password, Mobile = mobile, UpdatedOn = DateTime.Now, Gender = gender, CreatedBy = name, CreatedOn = DateTime.Now, CIF = GenerateCIF();
                    sQLCommands.InsertBankStaff(id, name, Password, mobile);
                    
                }
            }
            else
            {
                throw new NullValueException("bank");
            }
            return id;


        }
        private string GenerateBankId(string BankName)
        {
            return $"{BankName.Substring(0, 3)}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
        }
        private string GenerateUserId(string AccName)
        {
            return $"{AccName.Substring(0, 3)}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
        }
        private string GenerateCIF()
        {
            String validnum = "1234567890";
            Random random = new Random();

            int length = 11;
            String text = "";
            for (int i = 0; i < length; i++)
            {
                int num = random.Next(10);
                text = text + validnum.ElementAt(num);
            }
            return text;
        }
    }
}