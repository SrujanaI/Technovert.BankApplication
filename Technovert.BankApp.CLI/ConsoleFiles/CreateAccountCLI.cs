using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class CreateAccountCLI
    {
        public void create(string BankName)
        {
            BankService bankService = new BankService();
            InputsValidation inputsValidation = new InputsValidation();
            try
            {
                bankService.AddBank(BankName);
            }
            catch (DuplicateBankNameException e)
            {
                System.Console.WriteLine(e.Message);
            }

            inputsValidation.EnterAccHolderName();
            
            string AccHolderName = inputsValidation.UserInputString();
            AccHolderName=inputsValidation.CommonValidation(AccHolderName, "Account Name");

            inputsValidation.EnterPassword();
            string password = inputsValidation.UserInputString();
            password=inputsValidation.CommonValidation(password, "password");

            PasswordEncryption passwordEncryption = new PasswordEncryption();
            password = passwordEncryption.EncryptPlainTextToCipherText(password);
            //ConsoleFiles.WriteLine(password);
            System.Console.WriteLine("Please Enter your mobile number : ");
            string mobile = inputsValidation.UserInputString();
            mobile=inputsValidation.CommonValidation(mobile, "Mobile");

            System.Console.WriteLine("Please Specify your Gender : ");
            string gender = inputsValidation.UserInputString();
            gender = inputsValidation.GenderValidation(gender);

            try
            {
                Account account= bankService.CreateAccount(BankName, AccHolderName, password, mobile, gender);

                System.Console.WriteLine("Account created with Account Id : " + account.AccId + ", CIF : "+ account.CIF);

            }
            catch (DuplicateUserNameException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
