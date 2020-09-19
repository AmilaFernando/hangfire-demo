using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs
{
    public class HangfireJobs : IHangfireJobs
    {
        public void SendEmailNow(string userName)
        {
            Console.WriteLine($"Hi {userName}, This email is from Hangfire demo application");
        }

        public void ScheduleEmail(string userName)
        {
            Console.WriteLine($"Hi {userName}, This is a scheduled from Hangfire demo application");
        }

        public void ReccuringEmail(string userName)
        {
            Console.WriteLine($"Hi {userName}, This is a your weekly financial summary from Hangfire demo application");
        }

        public void ContinuationEmail(string userName)
        {
            Console.WriteLine($"Hi {userName}, Your transaction was successfull from Hangfire demo application");
        }


    }
}
