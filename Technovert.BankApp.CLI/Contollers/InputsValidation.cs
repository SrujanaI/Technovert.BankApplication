using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI
{
    internal class InputsValidation
    {
        public decimal decimalInputsValidation(decimal amt)
        {
            var num = Console.ReadLine();
            while (!decimal.TryParse(num, out amt))
            {
                Console.WriteLine(AmountFormatException.Exception());
                num = Console.ReadLine();
            }
            return amt;
        }
        public string BankNameValidation(string BankName, string type)
        {
            while (BankName == "")
            {
                Console.WriteLine(NullValueException.Exception());
                BankName = Console.ReadLine();
            }
            while(BankName.Length < 4)
            {
                
                Console.WriteLine(InvalidSizeException.Exception(type));
                BankName = Console.ReadLine();
            }
            return BankName;
        }
        public string MobileNumValidation(string Mobile)
        {
            while (Mobile == "")
            {
                Console.WriteLine(NullValueException.Exception());
                Mobile = Console.ReadLine();
            }
            while (Mobile.Length > 10 || Mobile.Length < 10)
            {

                Console.WriteLine("Please Enter 10 digit mobile number : ");
                Mobile = Console.ReadLine();
            }
            return Mobile;
        }
        public string GenderValidation(string Gender)
        {
            while (Gender == "")
            {
                Console.WriteLine(NullValueException.Exception());
                Gender = Console.ReadLine();
            }
            while (Gender != "Male" || Gender != "Female" || Gender != "Other" )
            {

                Console.WriteLine("Please Enter Valid Gender type ( Male, Female, Other ) ");
                Gender = Console.ReadLine();
                if (Gender == "Male" || Gender == "Female" || Gender == "Other")
                    break;
                    
            }
            return Gender;
        }



        public string AccountIdValidation(string AccId)
        {
            while (AccId == "")
            {
                Console.WriteLine(NullValueException.Exception());
                AccId = Console.ReadLine();
            }
           
            return AccId;
        }

        public void TransactionType(string type)
        {
            Console.WriteLine($"Enter amount to {type}");
        }

        public string UserInputString()
        {
            return Console.ReadLine();
        }

        public void EnterBankName(string type)
        {
            Console.WriteLine($"Please Enter {type} Bank Name : ");
        }

        public void EnterAccNum(string type)
        {
            Console.WriteLine($"Please Enter {type} Account Id : ");
        }
        public void EnterAccHolderName()
        {
            Console.WriteLine("Please Enter your Name : ");
        }

        public void EnterPassword()
        {
            Console.WriteLine("Please Enter your Password : ");
        }
    }
}