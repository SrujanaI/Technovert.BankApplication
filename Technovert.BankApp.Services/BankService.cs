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

namespace Technovert.BankApp.Services
{
    public class BankService
    {
        
        public bool AddBank(string name)
        {
            
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

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            var path = Path.Combine(directory, "../Bank.json");
            DataStore.Banks.Add(bank);
            string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(path, json);//return
            if (File.Exists(path))
            {
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);

                using (StreamReader sr = new StreamReader(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services/Bank.json"))
                {
                    int i = 0;
                    while (i < list.Count)
                    {
                        Console.WriteLine(list[i].Id);
                        i++;
                    }

                }

            }
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

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            var path = Path.Combine(directory, "../Bank.json");
            string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(path, json);
            Account account = bank.AccLists.Single(m => m.AccId == id);
            string transid = "TXN" + bank.Id + account.AccId + DateTime.Now;
            account.TransactionHistory.Add(new Transaction { TransId = transid, UserId = id, Amount = 0, On = DateTime.Now, Type = TransactionType.Create, Balance = 0 });
            json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(@"C:\Users\DELL\Downloads\Technovert.BankApplication\Technovert.BankApp.Services/Bank.json", json);
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
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            var path = Path.Combine(directory, "../Bank.json");
            string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(path, json);
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