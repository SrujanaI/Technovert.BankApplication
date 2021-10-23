using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public class AccNotAvailableException : Exception
    {
        public AccNotAvailableException() : base("Account not available")
        {
        }
    }
}
