using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class CreateAccountCLI
    {
        public void CreateAccountHolder(string BankName)
        {
            BankService bankService = new BankService();
            InputsValidation inputsValidation = new InputsValidation();

            inputsValidation.EnterAccHolderName();

            string AccHolderName = inputsValidation.UserInputString();
            AccHolderName = inputsValidation.CommonValidation(AccHolderName, "Account Name");

            inputsValidation.EnterPassword();
            string password = inputsValidation.UserInputString();
            password = inputsValidation.CommonValidation(password, "password");

            PasswordEncryption passwordEncryption = new PasswordEncryption();
            password = passwordEncryption.EncryptPlainTextToCipherText(password);
            //ConsoleFiles.WriteLine(password);
            Console.WriteLine("Please Enter your mobile number : ");
            string mobile = inputsValidation.UserInputString();
            mobile = inputsValidation.CommonValidation(mobile, "Mobile");

            Console.WriteLine("Please Specify your Gender : ");
            string gender = inputsValidation.UserInputString();
            gender = inputsValidation.GenderValidation(gender);

            try
            {
                Tuple<string,string> account = bankService.CreateAccount(BankName, AccHolderName, password, mobile, gender);

                Console.WriteLine("Account created with Account Id : " + account.Item1 + ", CIF : " + account.Item2);

            }
            catch (DuplicateUserNameException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void createBankStaff(string BankName)
        {
            BankService bankService = new BankService();
            InputsValidation inputsValidation = new InputsValidation();


            inputsValidation.EnterAccHolderName();

            string AccHolderName = inputsValidation.UserInputString();
            AccHolderName = inputsValidation.CommonValidation(AccHolderName, "Account Name");

            inputsValidation.EnterPassword();
            string password = inputsValidation.UserInputString();
            password = inputsValidation.CommonValidation(password, "password");

            PasswordEncryption passwordEncryption = new PasswordEncryption();
            password = passwordEncryption.EncryptPlainTextToCipherText(password);
            //ConsoleFiles.WriteLine(password);
            System.Console.WriteLine("Please Enter your mobile number : ");
            string mobile = inputsValidation.UserInputString();
            mobile = inputsValidation.CommonValidation(mobile, "Mobile");


            try
            {
                string StaffId = bankService.CreateAccountBankStaff(BankName, AccHolderName, password, mobile);

                Console.WriteLine("Account created with Account Id : " + StaffId);

            }
            catch (DuplicateUserNameException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

    }
}