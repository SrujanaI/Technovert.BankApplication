using System;
using System.Collections.Generic;
using System.Text;

namespace Technovert.BankApp.Models.Exceptions
{
    public static class InvalidSizeException
    {
        public static string  Exception(string type)
        {
            return $"Please Enter {type} of Size atleast 4 characters ";
        }
    }
}
