using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI
{
    internal class CreateAccountCLI
    {
        public void create()
        {
            BankService bankService = new BankService();
            InputsValidation inputsValidation = new InputsValidation();
            inputsValidation.EnterBankName("your");
            
            string BankName = inputsValidation.UserInputString();
            
            BankName = inputsValidation.BankNameValidation(BankName,"BankName");

            try
            {
                bankService.AddBank(BankName);
            }
            catch (DuplicateBankNameException e)
            {
                Console.WriteLine(e.Exception());
            }

            inputsValidation.EnterAccHolderName();
            
            string AccHolderName = inputsValidation.UserInputString();
            AccHolderName = inputsValidation.BankNameValidation(AccHolderName, "Account Name");
            inputsValidation.EnterPassword();
            string password = inputsValidation.UserInputString();

            
            password = inputsValidation.BankNameValidation(password, "password");
            PasswordEncryption passwordEncryption = new PasswordEncryption();
            password = passwordEncryption.EncryptPlainTextToCipherText(password);
            //Console.WriteLine(password);
            Console.WriteLine("Please Enter your mobile number : ");
            string mobile = inputsValidation.UserInputString();
            mobile = inputsValidation.MobileNumValidation(mobile);
            Console.WriteLine("Please Specify your Gender : ");
            string gender = inputsValidation.UserInputString();
            gender = inputsValidation.GenderValidation(gender);

            try
            {
                string id = bankService.CreateAccount(BankName, AccHolderName, password, mobile, gender);
                Console.WriteLine("Account created with Account Number : " + id);

            }
            catch (DuplicateUserNameException e)
            {
                Console.WriteLine(e.Exception());
            }
        }
    }
}
