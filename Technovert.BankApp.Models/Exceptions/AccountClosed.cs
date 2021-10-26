using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public class AccountClosedException:Exception
    {
        public AccountClosedException(string s):base($"{s} Account Is Closed"){
        }
    }
}
