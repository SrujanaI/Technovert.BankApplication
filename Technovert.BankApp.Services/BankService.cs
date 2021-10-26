using System;
using System.Linq;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Services
{
    public class BankService
    {
        Random ran = new Random();

        String b = "1234567890";

        int length = 11;

        String random = "";
        public void AddBank(string name)
        {
            if (DataStore.Banks.Any(m => m.BankName == name))
            {
                throw new DuplicateBankNameException();
            }
            Bank bank = new Bank
            {
                BankId = this.GenerateBankId(name), 
                BankName = name,
                CreatedOn = DateTime.Now
                
            };
            DataStore.Banks.Add(bank);
        }
        public Account CreateAccount(string BankName, string name, string Password, string mobile, string gender)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (bank.AccLists.Any(m => m.AccName == name))
            {
                throw new DuplicateUserNameException();
            }
            string id = this.GenerateUserId(name);
            bank.AccLists.Add(new Account { AccId = id, AccName = name,Balance = 0, Password = Password, Mobile = mobile, UpdatedOn= DateTime.Now, Gender = gender, CreatedBy = name, CreatedOn = DateTime.Now, CIF=GenerateCIF()});
            Account a = bank.AccLists.Single(m => m.AccId == id);
            string transid = "TXN" + bank.BankId + a.AccId + DateTime.Now;
            a.TransactionHistory.Add(new Transaction { TransId = transid , UserId = id, Amount = 0, On = DateTime.Now, Type = TransactionType.Create, Balance = 0 });
            return a;
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
            BankStaff a = bank.bankStaff.Single(m => m.StaffId == id);
            return a;
        }
        public string GenerateBankId(string BankName)
        {
            return $"{BankName.Substring(0,3)}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
        }
        public string GenerateUserId(string AccName)
        {
            return $"{AccName.Substring(0, 3)}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
        }
        public string GenerateCIF()
        {
            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(10);
                random = random + b.ElementAt(a);
            }
            return random;
        }
    }
}