using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models.Enums;

namespace Technovert.BankApp.Services.ServiceFiles
{
    public class ValidationService
    {
        public Bank BankAvailability(string name)
        {
            if(!(DataStore.Banks.Any(m => m.BankName == name))){
                throw new BankNotAvailableException();
                //throw new Exception("Bank not available");
            }
            Bank b = DataStore.Banks.Single(m => m.BankName == name);
            return b;
        }
        public Account AccountValidity(string BankName, string AccId, string password)
        {
            Bank b = DataStore.Banks.Single(m => m.BankName == BankName);
            if(!(b.AccLists.Any(m => (m.AccId == AccId) && (m.Password == password)))){
                //throw new Exception("Account not available");
                throw new AccNotAvailableException();
            }
            Account a = b.AccLists.Single(m => (m.AccId == AccId) && (m.Password == password));
            return a;
        }
        public Account UpdateorDeleteAccountValidity(string BankName, string AccId)
        {
            Bank b = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(b.AccLists.Any(m => (m.AccId == AccId) )))
            {
                //throw new Exception("Account not available");
                throw new AccNotAvailableException();
            }
            Account a = b.AccLists.Single(m => (m.AccId == AccId));
            return a;
        }
        public Account DepositAccountValidity(string BankName, string AccId, string cif)
        {
            Bank b = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(b.AccLists.Any(m => (m.AccId == AccId) && (m.CIF == cif))))
            {
                //throw new Exception("Account not available");
                throw new AccNotAvailableException();
            }
            Account a = b.AccLists.Single(m => (m.AccId == AccId) && (m.CIF==cif));
            return a;
        }
        public Account DesAccountValidity(string BankName, string AccId)
        {
            Bank b = DataStore.Banks.Single(m => m.BankName == BankName);
            if(!(b.AccLists.Any(m => (m.AccId == AccId))))
            {
                throw new AccNotAvailableException();
            }
            Account a = b.AccLists.Single(m => (m.AccId == AccId));
            return a;
        }
    }
}