using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.Services
{
    public class ValidationService
    {
        public bool BankAvailability(string name)
        {
            return DataStore.Banks.Any(m => m.Name == name);
        }
        public bool AccountValidity(string BankName, string AccId, string password)
        {
            Bank b = DataStore.Banks.Single(m => m.Name == BankName);
            return (b.AccLists.Any(m => (m.UserId == AccId) && (m.Password == password)));
        }
        public bool DesAccountValidity(string BankName, string AccId)
        {
            Bank b = DataStore.Banks.Single(m => m.Name == BankName);
            return (b.AccLists.Any(m => (m.UserId == AccId) ));
        }
    }
}