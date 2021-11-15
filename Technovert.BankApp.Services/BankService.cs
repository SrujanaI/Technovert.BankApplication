using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Newtonsoft.Json.Linq;

namespace Technovert.BankApp.Services
{
    public class BankService
    {

        public bool AddBank(string name)
        {
            /*Object data = JObject.Parse(@"C: \Users\DELL\Downloads\Technovert.BankApplication\bank.json");
            //var s = data.SelectToken("BankName").Value<string>();
            //var obj = JSON.parse(@"C: \Users\DELL\Downloads\Technovert.BankApplication\bank.json");
            //var length = Object.Keys(data).length;

            var countKey = Object.keys(data).length;

            int i = 0;
            while (i < data) {
                

                if (name == data[i].BankName) return false;
                i++;
            }*/


            
            if (DataStore.Banks.Any(m => m.BankName == name))
            {
                //throw new DuplicateBankNameException();
                return false;
            }
            Bank bank = new Bank
            {
                Id = this.GenerateBankId(name),
                BankName = name,
                CreatedOn = DateTime.Now

            };
            string json = JsonConvert.SerializeObject(bank);
            File.AppendAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\bank.json", json);
            
            DataStore.Banks.Add(bank);//return
            return true;
        }
        public Account CreateAccount(string BankName, string name, string Password, string mobile, string gender)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (bank.AccLists.Any(m => m.AccName == name))
            {
                throw new DuplicateUserNameException();
            }
            string id = this.GenerateUserId(name);
            bank.AccLists.Add(new Account { AccId = id, AccName = name, Balance = 0, Password = Password, Mobile = mobile, UpdatedOn = DateTime.Now, Gender = gender, CreatedBy = name, CreatedOn = DateTime.Now, CIF = GenerateCIF() });
            Account account = bank.AccLists.Single(m => m.AccId == id);
            string transid = "TXN" + bank.Id + account.AccId + DateTime.Now;
            account.TransactionHistory.Add(new Transaction { TransId = transid, UserId = id, Amount = 0, On = DateTime.Now, Type = TransactionType.Create, Balance = 0 });

            string json = JsonConvert.SerializeObject(account);
            File.AppendAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\accountHolder.json", json);
            return account;
        }

        public BankStaff CreateAccountBankStaff(string BankName, string name, string Password, string mobile)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (bank.bankStaff.Any(m => m.StaffName == name))
            {
                throw new DuplicateUserNameException();
            }
            string id = this.GenerateUserId(name);
            bank.bankStaff.Add(new BankStaff { StaffId = id, StaffName = name, password = Password, Mobile = mobile });
            BankStaff bankStaff = bank.bankStaff.Single(m => m.StaffId == id);
            string json = JsonConvert.SerializeObject(bankStaff);
            File.AppendAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\bankStaff.json", json);
            return bankStaff;
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