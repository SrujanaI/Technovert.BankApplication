﻿using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using System.Linq;
using DatabaseBank;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class RevertCLI
    {
        SQLCommands sQLCommands = new SQLCommands();
        InputsValidation inputsValidation = new InputsValidation();
        public bool Revert(string BankName)
        {
            string AccId,TransId;
            if (sQLCommands.CheckBankAvailability(BankName))
            {
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.CommonValidation(AccId, "AccId");
                if (sQLCommands.CheckAccountAvailability(AccId))
                {
                    Console.WriteLine("Enter Transaction Id : ");
                    TransId = inputsValidation.UserInputString();
                    Tuple<string,decimal> tp= sQLCommands.SelectRevertTransaction(TransId);

                    sQLCommands.UpdateAccount(AccId, tp.Item2, DateTime.Now);
                    sQLCommands.UpdateAccount(tp.Item1, (-1 * tp.Item2), DateTime.Now);

                    Console.WriteLine("Revert Transaction is successful");
                }
                else
                {
                    throw new AccountNotAvailableException();
                }
            }
            else
            {
                throw new BankNotAvailableException();
            }
            return true;
        }
            /*ValidationService validationService = new ValidationService();
            InputsValidation inputsValidation = new InputsValidation();
            string Id;

            try
            {

                Bank bank = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                Id = inputsValidation.UserInputString();
                Id = inputsValidation.CommonValidation(Id, "AccId");

                string TransId;
                Console.WriteLine("Enter Transaction Id : ");
                TransId = inputsValidation.UserInputString();



                if (bank.AccLists.Any(m => m.AccId == Id))
                {
                    Account account = bank.AccLists.Single(m => m.AccId == Id);
                    if (account.TransactionHistory.Any(m => m.TransId == TransId))
                    {
                        Transaction transaction = account.TransactionHistory.Single(m => m.TransId == TransId);
                        if (DataStore.Banks.Any(m => m.Id == transaction.DestinationBankId))
                        {
                            Bank destinationBank = DataStore.Banks.Single(m => m.Id == transaction.DestinationBankId);
                            if (bank.AccLists.Any(m => m.AccId == transaction.DestinationId))
                            {
                                Account destinationaccount = bank.AccLists.Single(m => m.AccId == transaction.DestinationId);
                                destinationaccount.Balance -= transaction.Amount;
                                account.Balance += transaction.Amount;
                                account.TransactionHistory.Add(new Transaction { BankId = bank.Id, DestinationBankId = destinationBank.Id, TransId = transaction.TransId, UserId = account.AccId, DestinationId = destinationaccount.AccId, Amount = transaction.Amount, On = DateTime.Now, Type = TransactionType.Revert, Balance = account.Balance });
                                destinationaccount.TransactionHistory.Add(new Transaction { BankId = destinationBank.Id, DestinationBankId = bank.Id, TransId = transaction.TransId, UserId = destinationaccount.AccId, DestinationId = account.AccId, Amount = transaction.Amount, On = DateTime.Now, Type = TransactionType.Revert, Balance = destinationaccount.Balance });

                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }

                }

                else
                {
                    return false;
                }
                return true;

            }
            catch (BankNotAvailableException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }


        }*/
    }
}
