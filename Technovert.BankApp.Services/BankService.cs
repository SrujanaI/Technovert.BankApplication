using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.Services
{
    public class BankService
    {
        public void AddBank(string name)
        {
            if (DataStore.Banks.Any(m => m.Name == name))
            {
                throw new DuplicateBankNameException();
            }
            Bank bank = new Bank
            {
                BankId = this.GenerateBankId(name), 
                Name = name,
                CreatedOn = DateTime.Now
                
            };
            DataStore.Banks.Add(bank);
        }
        public string CreateAccount(string BankName, string name, string Password, string mobile, string gender)
        {
            Bank bank = DataStore.Banks.Single(m => m.Name == BankName);
            if (bank.AccLists.Any(m => m.Name == name))
            {
                throw new DuplicateUserNameException();
            }
            string id = this.GenerateUserId(name);
            bank.AccLists.Add(new Account { UserId = id, Name = name,Balance = 0, Password = Password, Mobile = mobile, UpdatedOn= DateTime.Now, Gender = gender, CreatedBy = name, CreatedOn = DateTime.Now});
            Account a = bank.AccLists.Single(m => m.UserId == id);
            string transid = "TXN" + bank.BankId + a.UserId + DateTime.Now;
            a.TransactionHistory.Add(new Transaction { TransId = transid , UserId = id, Amount = 0, On = DateTime.Now, Type = TransactionType.Create, Balance = 0 });
            return id;
        }
        public string GenerateBankId(string BankName)
        {
            return $"{BankName.Substring(0,3)}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
        }
        public string GenerateUserId(string AccName)
        {
            return $"{AccName.Substring(0, 3)}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
        }
    }
}