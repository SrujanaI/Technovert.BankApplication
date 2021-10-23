using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.Services
{
    public static class DataStore
    {
        public static List<Bank> Banks = new List<Bank>();

        public static Dictionary<string, decimal> currency = new Dictionary<string, decimal>() { { "INR", 1 } };
    }
}