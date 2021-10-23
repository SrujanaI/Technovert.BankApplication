using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public class BankNotAvailableException : Exception
    {
        public BankNotAvailableException() : base("Bank not avaialble")
        {
        }
    }
}
