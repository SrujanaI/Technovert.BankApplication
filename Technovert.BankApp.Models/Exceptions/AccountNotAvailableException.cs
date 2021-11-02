using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public class AccountNotAvailableException : Exception
    {
        public AccountNotAvailableException() : base("Account not available")
        {
        }
    }
}
