using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models;


namespace Technovert.BankApp.Services
{
    public class StatusService
    {
        public AccountStatus Status(Account account)
        {

            DateTime launchDate = account.UpdatedOn;
            DateTime current = DateTime.Now;
            TimeSpan diff = current - launchDate;


            if (diff.Days < 2000)
            {
                return AccountStatus.Active;
            }
            /*else if (diff.Days >= 90 && diff.Days < 1000)
            {
                return AccountStatus.InActive;
            }*/
            else
            {
                return AccountStatus.Closed;
            }
        }
    }
}