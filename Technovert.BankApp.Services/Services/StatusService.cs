using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Models;


namespace Technovert.BankApp.Services
{
    public class StatusService
    {
        public void Status(Account account)
        {
            
            DateTime launchDate = new DateTime(account.UpdatedOn.Year, account.UpdatedOn.Month, account.UpdatedOn.Day, account.UpdatedOn.Hour,account.UpdatedOn.Minute, account.UpdatedOn.Second);
            DateTime current = DateTime.Now;
            TimeSpan diff = current - launchDate;
           

            if (diff.Days < 60)
            {
                account.Status = AccountStatus.Active;
            }
            else if(diff.Days >= 60 && diff.Days < 90)
            {
                account.Status = AccountStatus.PartiallyActive;
            }
            else if(diff.Days >= 90 && diff.Days < 1000)
            {
                account.Status = AccountStatus.InActive;
            }
            else if(diff.Days >= 1000)
            {
                account.Status = AccountStatus.Closed;
                
            }

        }
    }
}
