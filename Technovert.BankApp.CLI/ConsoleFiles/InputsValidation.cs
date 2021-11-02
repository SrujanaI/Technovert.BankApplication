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
        public decimal DecimalInputsValidation(decimal amt)
        {
            var num = Console.ReadLine();
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
            if (BankName == "")
            {
                throw new NullValueException($"You didn't enter anything, Please Enter a Valid {type}");
            }
            if (BankName.Length < 4)
            {
                throw new InvalidSizeException($"Please Enter {type} of Size atleast 4 characters ");
            }
            return true;
        }
        public bool MobileNumValidation(string Mobile)
        {
            if (Mobile == "")
            {
                throw new NullValueException("You didn't enter anything, Please Enter a Valid Mobile");
            }
            if (Mobile.Length > 10 || Mobile.Length < 10)
            {
                throw new InvalidSizeException("Please Enter Mobile of Size atleast 10 characters ");
            }
            return true;
        }
        public string GenderValidation(string Gender)
        {
            if (Gender == "")
            {
                throw new NullValueException("You didn't enter anything, Please Enter a Valid Gender");
            }
            while (Gender != "Male" || Gender != "Female" || Gender != "Other")
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
            if (AccId == "")
            {
                throw new NullValueException("You didn't enter anything, Please Enter a Valid Account Id");
            }
            return true;
        }

        public string CommonValidation(string s, string type)
        {
            while (true)
            {
                try
                {
                    if (type == "AccId")
                    {
                        if (AccountIdValidation(s)) return s;
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
                    if (type == "Account Name")
                    {
                        if (BankNameValidation(s, type)) return s;
                    }
                }
                catch (InvalidSizeException e)
                {
                    Console.WriteLine(e.Message);
                    s = UserInputString();
                }
                catch (NullValueException e)
                {
                    Console.WriteLine(e.Message);
                    s = UserInputString();
                }
            }
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
            Console.WriteLine($"Please Enter {type} BankName : ");
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