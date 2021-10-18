using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models.Exceptions
{
    public static class NullValueException
    {
        public static string Exception()
        {
            return "You Didn't enter any name , Please Enter a Valid Name";
        }
    }
}