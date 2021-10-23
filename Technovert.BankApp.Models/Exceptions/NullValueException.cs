using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models.Exceptions
{
    public class NullValueException:Exception
    {
        public NullValueException(string type):base($"You didn't enter anything, Please Enter a Valid {type}")
        {
        }
    }
}