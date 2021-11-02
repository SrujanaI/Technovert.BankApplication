using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.Services
{
    public class ValidationService
    {
        public Bank BankAvailability(string name)
        {
            if (!(DataStore.Banks.Any(m => m.BankName == name)))
            {
                throw new BankNotAvailableException();
                //throw new Exception("Bank not available");
            }
            Bank bank = DataStore.Banks.Single(m => m.BankName == name);
            return bank;
        }
        public Account AccountValidity(string BankName, string AccId, string password)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId) && (m.Password == password))))
            {
                //throw new Exception("Account not available");
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId) && (m.Password == password));
            return account;
        }
        public Account UpdateorDeleteAccountValidity(string BankName, string AccId)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId))))
            {
                //throw new Exception("Account not available");
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId));
            return account;
        }
        public Account DepositAccountValidity(string BankName, string AccId, string cif)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId) && (m.CIF == cif))))
            {
                //throw new Exception("Account not available");
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId) && (m.CIF == cif));
            return account;
        }
        public Account DesAccountValidity(string BankName, string AccId)
        {
            Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId))))
            {
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId));
            return account;
        }
    }
}