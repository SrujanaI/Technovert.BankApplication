using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public class InvalidSizeException:Exception
    {
        public InvalidSizeException(string type, int val) : base($"Please Enter {type} of Size atleast {val} characters ")
        {
        }
    }
}
