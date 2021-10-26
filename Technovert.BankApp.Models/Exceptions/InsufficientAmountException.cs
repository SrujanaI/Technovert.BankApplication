using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public class InsufficientAmountException:Exception
    {
        public InsufficientAmountException():base("Available balance is less than required") { }
    }
}
