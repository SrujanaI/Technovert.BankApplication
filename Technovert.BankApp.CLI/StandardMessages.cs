using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.CLI
{
    internal class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello, Welcome!!");
        }
        public static void Options()
        {
            Console.WriteLine("1.Create Account\n2.Transaction Type\n3.Transaction History\n4.Exit");
            Console.WriteLine("Enter your required option");
        }
        public static void TransactionOptions()
        {
            Console.WriteLine("1.Deposit\n2.Withdraw\n3.Transfer");
            Console.WriteLine("Enter your required option");
        }
        public static void AmountInformation(string s)
        {
            Console.WriteLine($"Enter amount you want to { s }");
        }
        public static void InavlidInformation()
        {
            Console.WriteLine("Entered wrong account details");
        }
        public static void ExitMessage()
        {
            Console.WriteLine("Thank you");
        }
        public static void Data(string s)
        {
            Console.WriteLine($"Enter { s } again");
        }
    }
}