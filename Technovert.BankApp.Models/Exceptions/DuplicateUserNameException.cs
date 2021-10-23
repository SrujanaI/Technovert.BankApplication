using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models.Exceptions
{
    public class DuplicateUserNameException : Exception
    {
        public DuplicateUserNameException():base("BankName Already Exists! Continue Creating your Account "){
        }
    }
}