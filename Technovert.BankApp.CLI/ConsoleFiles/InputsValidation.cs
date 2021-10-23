using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class InputsValidation
    {
        public decimal decimalInputsValidation(decimal amt)
        {
            var num = System.Console.ReadLine();
            if (!decimal.TryParse(num, out amt))
            {
                throw new AmountFormatException();
                /*ConsoleFiles.WriteLine(AmountFormatException.Exception());
                num = ConsoleFiles.ReadLine();*/
            }
            return amt;
        }
        public bool BankNameValidation(string BankName, string type)
        {
            if(BankName == "")
            {
                throw new NullValueException(type);
            }
            if(BankName.Length < 4)
            {
                throw new InvalidSizeException(type,4);
            }
            return true;
        }
        public bool MobileNumValidation(string Mobile)
        {
            if(Mobile == "")
            {
                throw new NullValueException("Mobile");
            }
            if(Mobile.Length > 10 || Mobile.Length < 10)
            {
                throw new InvalidSizeException("Mobile",10);
            }
            return true;
        }
        public string GenderValidation(string Gender)
        {
            if (Gender == "")
            {
                throw new NullValueException("Gender");
            }
            while (Gender != "Male" || Gender != "Female" || Gender != "Other" )
            {
                if (Gender == "Male" || Gender == "Female" || Gender == "Other")
                    break;
                System.Console.WriteLine("Please Enter Valid Gender type ( Male, Female, Other ) ");
                Gender = System.Console.ReadLine();
            }
            return Gender;
        }

        public bool AccountIdValidation(string AccId)
        {
            if(AccId == "")
            {
                throw new NullValueException("AccId");
            }
            return true;
        }

        public string CommonValidation(string s,string type)
        {
            while (true)
            {
                try
                {
                    if (type == "AccId")
                    {
                        if(AccountIdValidation(s)) return s;
                    }
                    if (type == "BankName")
                    {
                        if (BankNameValidation(s, type)) return s;
                    }
                    if (type == "Mobile")
                    {
                        if (MobileNumValidation(s)) return s;
                    }
                    if (type == "password")
                    {
                        if (BankNameValidation(s, type)) return s;
                    }
                    if(type=="Account Name")
                    {
                        if (BankNameValidation(s, type)) return s;
                    }
                }
                catch (InvalidSizeException e)
                {
                    System.Console.WriteLine(e.Message);
                    s = UserInputString();
                }
                catch (NullValueException e)
                {
                    System.Console.WriteLine(e.Message);
                    s = UserInputString();
                }
            }
        }

        public void TransactionType(string type)
        {
            System.Console.WriteLine($"Enter amount to {type}");
        }

        public string UserInputString()
        {
            return System.Console.ReadLine();
        }

        public void EnterBankName(string type)
        {
            System.Console.WriteLine($"Please Enter {type} BankName : ");
        }

        public void EnterAccNum(string type)
        {
            System.Console.WriteLine($"Please Enter {type} Account Id : ");
        }
        public void EnterAccHolderName()
        {
            System.Console.WriteLine("Please Enter your Name : ");
        }

        public void EnterPassword()
        {
            System.Console.WriteLine("Please Enter your Password : ");
        }
    }
}